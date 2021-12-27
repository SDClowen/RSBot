#include <Windows.h>
#include <stdio.h>

#include <string>
#include <map>
#include <vector>

#include <iostream>
#include <sstream>
#include <fstream>

#include <iphlpapi.h>

#include "Common.h"
#include "Console.h"
#include "detours.h"
#include "PayloadHelper.h"

#pragma comment(lib, "IPHLPAPI.lib")
#pragma comment(lib, "ws2_32.lib")

using namespace std;

HMODULE g_Instance = NULL;
HANDLE g_Thread = NULL;

BYTE g_IsDebug;
string g_RedirectIP = "127.0.0.1";
WORD g_RedirectPort = 1500;

vector<string> g_RealGatewayAddresses;
WORD g_RealGatewayPort = 15779;

struct ExeSectionInfo
{
	DWORD codeStart;
	LPBYTE codePtr;
	DWORD codeSize;

	DWORD dataStart;
	LPBYTE dataPtr;
	DWORD dataSize;
} globalExeSectionInfo = { 0 };

BYTE peHeader[4096];

DWORD& codeStart = globalExeSectionInfo.codeStart;
DWORD& codeSize = globalExeSectionInfo.codeSize;
LPBYTE& codePtr = globalExeSectionInfo.codePtr;

DWORD& dataStart = globalExeSectionInfo.dataStart;
DWORD& dataSize = globalExeSectionInfo.dataSize;
LPBYTE& dataPtr = globalExeSectionInfo.dataPtr;

void User_Initialize();
void User_Deinitialize();

DWORD WINAPI InjectionThread(LPVOID lpParam);

void LoadConfig();

HMODULE WINAPI Detoured()
{
	return g_Instance;
}

namespace nsFramework
{
	LPVOID framework_gCleanupAddr = NULL;
	DWORD framework_entryPoint = 0;
	BYTE framework_resBytes[6] = { 0 };
	DWORD framework_ret_InitCleanup = 0;

	void Framework_Initialize()
	{
		User_Initialize();
	}

	void Framework_Deinitialize()
	{
		User_Deinitialize();
	}

	VOID framework_InitCleanup()
	{
		VirtualFreeEx(GetCurrentProcess(), framework_gCleanupAddr, 0, MEM_RELEASE);
		framework_gCleanupAddr = 0;
		WriteBytes(framework_entryPoint, framework_resBytes, 6);
		framework_ret_InitCleanup -= 5;
		Framework_Initialize();
	}

	__declspec(naked) VOID framework_codecave_initcleanup(VOID)
	{
		__asm pop framework_ret_InitCleanup
		__asm pushad
		framework_InitCleanup();
		__asm popad
		__asm push framework_ret_InitCleanup
		__asm ret
	}

	extern "C" __declspec(dllexport) VOID __cdecl Initialize(LPDWORD allocAddr, DWORD restoreAddr, LPBYTE origBytes)
	{
		g_Thread = OpenThread(THREAD_ALL_ACCESS, FALSE, GetCurrentThreadId());
		framework_gCleanupAddr = allocAddr;
		framework_entryPoint = restoreAddr;
		WriteBytes(framework_entryPoint, origBytes, 6);
		memcpy(framework_resBytes, origBytes, 6);
		CreateCodeCave(framework_entryPoint, 6, framework_codecave_initcleanup);
	}
}

namespace nsDetours
{
	LONG inject = 1;

	extern "C" BOOL(WINAPI * Real_QueryPerformanceCounter)(LARGE_INTEGER * lpPerformanceCount) = QueryPerformanceCounter;
	BOOL WINAPI User_QueryPerformanceCounter(LARGE_INTEGER* lpPerformanceCount)
	{
		BOOL result = Real_QueryPerformanceCounter(lpPerformanceCount);
		if (InterlockedCompareExchange(&inject, 0, 1) == 1)
		{
			InjectionThread(0);
		}
		return result;
	}

	extern "C" HANDLE(WINAPI * Real_CreateMutexA)(LPSECURITY_ATTRIBUTES lpMutexAttributes, BOOL bInitialOwner, LPCSTR lpName) = CreateMutexA;
	HANDLE WINAPI User_CreateMutexA(LPSECURITY_ATTRIBUTES lpMutexAttributes, BOOL bInitialOwner, LPCSTR lpName)
	{
		if (lpName && strcmp(lpName, "Silkroad Client") == 0)
		{
			char newName[128] = { 0 };
			_snprintf_s(newName, sizeof(newName), sizeof(newName) / sizeof(newName[0]) - 1, "Client_%d", 0xFFFFFFFF & __rdtsc());
			return Real_CreateMutexA(lpMutexAttributes, bInitialOwner, newName);
		}
		return Real_CreateMutexA(lpMutexAttributes, bInitialOwner, lpName);
	}

	extern "C" int (WINAPI * Real_bind)(SOCKET s, const struct sockaddr* name, int namelen) = bind;
	int WINAPI User_bind(SOCKET s, const struct sockaddr* name, int namelen)
	{
		if (name && namelen == 16)
		{
			sockaddr_in* inaddr = (sockaddr_in*)name;
			if (inaddr->sin_port == ntohs(15779))
			{
				return 0;
			}
		}
		return Real_bind(s, name, namelen);
	}

	extern "C" HANDLE(WINAPI * Real_CreateSemaphoreA)(LPSECURITY_ATTRIBUTES lpSemaphoreAttributes, LONG lInitialCount, LONG lMaximumCount, LPCSTR lpName) = CreateSemaphoreA;
	HANDLE WINAPI User_CreateSemaphoreA(LPSECURITY_ATTRIBUTES lpSemaphoreAttributes, LONG lInitialCount, LONG lMaximumCount, LPCSTR lpName)
	{
		if (lpName && strcmp(lpName, "Global\\Silkroad Client") == 0)
		{
			char newName[128] = { 0 };
			_snprintf_s(newName, sizeof(newName), sizeof(newName) / sizeof(newName[0]) - 1, "Client_%d", 0xFFFFFFFF & __rdtsc());
			return Real_CreateSemaphoreA(lpSemaphoreAttributes, lInitialCount, lMaximumCount, newName);
		}

		return Real_CreateSemaphoreA(lpSemaphoreAttributes, lInitialCount, lMaximumCount, lpName);
	}

	extern "C" DWORD(WINAPI * Real_GetAdaptersInfo)(PIP_ADAPTER_INFO pAdapterInfo, PULONG pOutBufLen) = GetAdaptersInfo;
	DWORD WINAPI User_GetAdaptersInfo(PIP_ADAPTER_INFO pAdapterInfo, PULONG pOutBufLen)
	{
		DWORD dwResult = Real_GetAdaptersInfo(pAdapterInfo, pOutBufLen);
		if (dwResult == ERROR_SUCCESS)
		{
			PIP_ADAPTER_INFO pAdapter = pAdapterInfo;
			srand(__rdtsc() & 0xFFFFFFFF);
			while (pAdapter)
			{
				for (UINT i = 1; i < pAdapter->AddressLength; i++)
				{
					printf("%.2X -> ", pAdapter->Address[i]);
					pAdapter->Address[i] = rand() % 256;
					printf("%.2X ", pAdapter->Address[i]);
				}
				printf("\n");
				pAdapter = pAdapter->Next;
			}
		}
		return dwResult;
	}

	// How many routes we have to work with
	size_t routeListCount = 16;

	// Custom detour routing structure
#pragma pack(push, 1)
	struct TDetourRoute
	{
		BYTE srcA;
		BYTE srcB;
		BYTE srcC;
		BYTE srcD;
		WORD srcPort;

		BYTE dstA;
		BYTE dstB;
		BYTE dstC;
		BYTE dstD;
		WORD dstPort;
	};
#pragma pack(pop)

	// Pointer to the route list
	TDetourRoute routeArray[16] = { 0 };
	TDetourRoute* routeList = routeArray;

	extern "C" int (WINAPI * Real_connect)(SOCKET, const struct sockaddr*, int) = connect;
	int WINAPI Detour_connect(SOCKET s, const struct sockaddr* name, int namelen)
	{
		// Store the real port
		WORD port = ntohs((*(WORD*)name->sa_data));

		// Breakup the IP into the parts
		BYTE a = name->sa_data[2];
		BYTE b = name->sa_data[3];
		BYTE c = name->sa_data[4];
		BYTE d = name->sa_data[5];

		struct sockaddr myname = { 0 };
		memcpy(&myname, name, sizeof(sockaddr));
		// Loop through the vector of routed addresses
		for (size_t x = 0; x < routeListCount; ++x)
		{
			const TDetourRoute& route = routeList[x];
			// If the port matches or the port doesn't matter
			if (route.srcPort == port || route.srcPort == -1)
			{
				// If the addresses match
				if (route.srcA != 255 && route.srcA != a)
					continue;
				if (route.srcB != 255 && route.srcB != b)
					continue;
				if (route.srcC != 255 && route.srcC != c)
					continue;
				if (route.srcD != 255 && route.srcD != d)
					continue;

				// Use the new address instead!
				myname.sa_data[2] = (char)route.dstA;
				myname.sa_data[3] = (char)route.dstB;
				myname.sa_data[4] = (char)route.dstC;
				myname.sa_data[5] = (char)route.dstD;

				// If the dst port is -1, use the original port
				(*(WORD*)myname.sa_data) = htons(route.dstPort == -1 ? port : route.dstPort);

				// Detoured connect in effect
				return Real_connect(s, &myname, namelen);
			}
		}
		// Regular connect
		return Real_connect(s, name, namelen);
	}
}

namespace nsPatch
{
	void Setup()
	{
		DetourRestoreAfterWith();
		DetourTransactionBegin();
		DetourUpdateThread(GetCurrentThread());

		DetourAttach(&(PVOID&)nsDetours::Real_QueryPerformanceCounter, nsDetours::User_QueryPerformanceCounter);

		DetourTransactionCommit();
	}

	static std::vector<std::string> TokenizeString(const std::string& str, const std::string& delim)
	{
		// http://www.gamedev.net/community/forums/topic.asp?topic_id=381544#TokenizeString
		using namespace std;
		vector<string> tokens;
		size_t p0 = 0, p1 = string::npos;
		while (p0 != string::npos)
		{
			p1 = str.find_first_of(delim, p0);
			if (p1 != p0)
			{
				string token = str.substr(p0, p1 - p0);
				tokens.push_back(token);
			}
			p0 = str.find_first_not_of(delim, p1);
		}
		return tokens;
	}

	void Install()
	{
		DetourRestoreAfterWith();
		DetourTransactionBegin();
		DetourUpdateThread(GetCurrentThread());

		//Multiclient
		DetourAttach(&(PVOID&)nsDetours::Real_CreateMutexA, nsDetours::User_CreateMutexA);
		DetourAttach(&(PVOID&)nsDetours::Real_bind, nsDetours::User_bind);
		DetourAttach(&(PVOID&)nsDetours::Real_GetAdaptersInfo, nsDetours::User_GetAdaptersInfo);
		DetourAttach(&(PVOID&)nsDetours::Real_CreateSemaphoreA, nsDetours::User_CreateSemaphoreA);

		//Redirect detour
		DetourAttach(&(PVOID&)nsDetours::Real_connect, nsDetours::Detour_connect);

		DetourTransactionCommit();

		using namespace nsDetours;

		printf("Redirecting To: %s:%d\n", g_RedirectIP.c_str(), g_RedirectPort);

		vector<string> tokens = TokenizeString(g_RedirectIP, "\r\n\t .");

		for (size_t i = 0; i < routeListCount; ++i)
		{
			routeArray[i].dstA = atoi(tokens[0].c_str());
			routeArray[i].dstB = atoi(tokens[1].c_str());
			routeArray[i].dstC = atoi(tokens[2].c_str());
			routeArray[i].dstD = atoi(tokens[3].c_str());
			routeArray[i].dstPort = g_RedirectPort;
		}

		WSADATA wsaData = { 0 };
		WSAStartup(MAKEWORD(2, 2), &wsaData);
		routeListCount = 0;
		for (size_t i = 0; i < g_RealGatewayAddresses.size(); ++i)
		{
			string nme = g_RealGatewayAddresses[i];
			printf("g_RealGatewayAddresses[%d]: %s\n", i, nme.c_str());
			struct hostent* remoteHost = gethostbyname(nme.c_str());
			if (remoteHost)
			{
				struct in_addr addr;
				addr.s_addr = *(u_long*)remoteHost->h_addr_list[0];
				std::string hostip = inet_ntoa(addr);
				printf("\tIP: %s:%d\n", hostip.c_str(), g_RealGatewayPort);
				tokens = TokenizeString(hostip, ".");
				routeArray[routeListCount].srcA = atoi(tokens[0].c_str());
				routeArray[routeListCount].srcB = atoi(tokens[1].c_str());
				routeArray[routeListCount].srcC = atoi(tokens[2].c_str());
				routeArray[routeListCount].srcD = atoi(tokens[3].c_str());
				routeArray[routeListCount].srcPort = g_RealGatewayPort;
				routeListCount++;
				if (routeListCount > 16)
				{
					MessageBoxA(0, "There are too many host addresses to track. The application will now exit.", "Fatal Error", MB_ICONERROR);
					ExitProcess(0);
				}
			}
			else
			{
				printf("Lookup Failed for: %s\n", nme.c_str());
			}
		}
		WSACleanup();
	}

	void Uninstall()
	{
		DetourRestoreAfterWith();
		DetourTransactionBegin();
		DetourUpdateThread(GetCurrentThread());

		DetourDetach(&(PVOID&)nsDetours::Real_QueryPerformanceCounter, nsDetours::User_QueryPerformanceCounter);

		//Multiclient
		DetourDetach(&(PVOID&)nsDetours::Real_CreateMutexA, nsDetours::User_CreateMutexA);
		DetourDetach(&(PVOID&)nsDetours::Real_bind, nsDetours::User_bind);
		DetourDetach(&(PVOID&)nsDetours::Real_GetAdaptersInfo, nsDetours::User_GetAdaptersInfo);
		DetourDetach(&(PVOID&)nsDetours::Real_CreateSemaphoreA, nsDetours::User_CreateSemaphoreA);

		DetourTransactionCommit();

		RemoveConsole();
	}
}

void User_Initialize()
{
	try
	{
		nsPatch::Setup();
	}
	catch (const std::exception& ex)
	{
		MessageBoxA(NULL, ex.what(), "exception", MB_ICONERROR);
	}
}

//-----------------------------------------------------------------------------

void User_Deinitialize()
{
	nsPatch::Uninstall();

	free(codePtr);
	free(dataPtr);
}

DWORD WINAPI InjectionThread(LPVOID lpParam)
{
	HINSTANCE exeInstance = GetModuleHandle(0);

	ReadBytes(PtrToUlong(exeInstance), peHeader, 4096);

	PIMAGE_DOS_HEADER dosHeader = (PIMAGE_DOS_HEADER)peHeader;
#define MakePtr(cast, ptr, addValue) (cast)((DWORD)(ptr)+(DWORD)(addValue))
	PIMAGE_NT_HEADERS pNTHeader = MakePtr(PIMAGE_NT_HEADERS, dosHeader, dosHeader->e_lfanew);
#undef MakePtr

	IMAGE_SECTION_HEADER* pish = (IMAGE_SECTION_HEADER*)(((LPBYTE)&pNTHeader->OptionalHeader) + pNTHeader->FileHeader.SizeOfOptionalHeader);
	for (int x = 0; x < pNTHeader->FileHeader.NumberOfSections; ++x)
	{
		IMAGE_SECTION_HEADER& header = pish[x];

		if (header.VirtualAddress == pNTHeader->OptionalHeader.BaseOfData)
		{
			dataStart = pNTHeader->OptionalHeader.ImageBase + header.VirtualAddress;
			dataSize = header.Misc.VirtualSize;
			printf("-- Data --\n");
			printf("\tdataStart: %X\n", dataStart);
			printf("\tdataSize: %X\n\n", dataSize);
		}
		else if (header.VirtualAddress == pNTHeader->OptionalHeader.BaseOfCode)
		{
			codeStart = pNTHeader->OptionalHeader.ImageBase + header.VirtualAddress;
			codeSize = header.Misc.VirtualSize;

			printf("-- Code --\n");
			printf("\tcodeStart: %X\n", codeStart);
			printf("\tcodeSize: %X\n\n", codeSize);
		}
		else
		{
			continue;
		}
	}

	if (codeSize == 0)
	{
		MessageBoxA(0, "codeSize == 0", "Fatal Error", MB_ICONERROR);
		ExitProcess(0);
	}

	if (dataSize == 0)
	{
		MessageBoxA(0, "dataSize == 0", "Fatal Error", MB_ICONERROR);
		ExitProcess(0);
	}

	codePtr = (LPBYTE)malloc(codeSize);
	ReadBytes(codeStart, codePtr, codeSize);

	dataPtr = (LPBYTE)malloc(dataSize);
	ReadBytes(dataStart, dataPtr, dataSize);

	LoadConfig();
	if (g_IsDebug)
	{
		// Create a debugging console
		AddConsole("RSBot.LoaderDll - Debugging Console");

		freopen("CONIN$", "r", stdin);
		freopen("CONOUT$", "w", stdout);
		freopen("CONOUT$", "w", stderr);
	}

	nsPatch::Install();

	// Mutex for the launcher, no patches required to start Silkroad now
	CreateMutexA(0, 0, "Silkroad Online Launcher");
	CreateMutexA(0, 0, "Ready");

	return 0;
}

void LoadConfig()
{
	stringstream payloadPath;
	payloadPath << getenv("TMP") << "\\rsLoader_" << GetCurrentProcessId() << ".dat";

	ifstream stream(payloadPath.str(), ifstream::binary);

	PayloadRead(stream, g_IsDebug);
	PayloadReadString(stream, g_RedirectIP);
	PayloadRead(stream, g_RedirectPort);

	BYTE nRealGatewayAddressCount = 0;
	PayloadRead(stream, nRealGatewayAddressCount);
	for (size_t i = 0; i < nRealGatewayAddressCount; i++)
	{
		string address;
		PayloadReadString(stream, address);

		g_RealGatewayAddresses.push_back(address);
	}
	PayloadRead(stream, g_RealGatewayPort);

	stream.close();
	DeleteFileA(payloadPath.str().c_str());
}

BOOL APIENTRY DllMain(HMODULE hModule, DWORD ulReason, LPVOID lpReserved)
{
	if (ulReason == DLL_PROCESS_ATTACH)
	{
		g_Instance = hModule;
	}
	else if (ulReason == DLL_PROCESS_DETACH)
	{
		printf("Framework_Deinitialize..\n");
		nsFramework::Framework_Deinitialize();
	}
	return TRUE;
}