#include <Windows.h>
#include <string>
#include <sstream>
#include <algorithm>
#include <map>
#include "PayloadHelper.h"
#include <vector>

using namespace std;

int main(int argc, char** argv)
{
	//for (int i = 0; i < argc; i++)
	//	printf("argv[%d]: %s\n", i, argv[i]);

	BYTE isDebug = atoi(argv[1]);
	string clientPath = string(argv[2]);
	string clientArgs = string(argv[3]);
	string libraryPath = string(argv[4]);

	string libraryRedirectIP = string(argv[5]);
	WORD libraryRedirectPort = atoi(argv[6]);
	DWORD libraryRealAddressCount = atoi(argv[7]);
	vector<string> libraryRealAddresses;
	for (size_t i = 0; i < libraryRealAddressCount; i++)
		libraryRealAddresses.push_back(string(argv[8 + i]));

	WORD libraryRealPort = atoi(argv[8 + libraryRealAddressCount]);

	stringstream commandLine;
	commandLine << "\"" << clientPath << "\" " << clientArgs;

	STARTUPINFOA si = { 0 };
	PROCESS_INFORMATION pi = { 0 };
	si.cb = sizeof(STARTUPINFOA);

	bool result = CreateProcessA(0, (LPSTR)commandLine.str().c_str(), 0, NULL, FALSE, CREATE_SUSPENDED, NULL, NULL, &si, &pi);
	if (result == false)
	{
		MessageBoxA(0, "Could not start \"sro_client.exe\".", "Fatal Error", MB_ICONERROR);
		return 0;
	}

	char* tempFolder = NULL;
	_dupenv_s(&tempFolder, NULL, "TMP");

	stringstream payloadPath;
	payloadPath << tempFolder << "\\RSBot_" << pi.dwProcessId << ".dat";

	ofstream stream(payloadPath.str(), ofstream::binary);

	PayloadWrite(stream, isDebug);
	PayloadWriteString(stream, libraryRedirectIP);
	PayloadWrite(stream, libraryRedirectPort);
	PayloadWrite(stream, libraryRealAddressCount);
	for (size_t i = 0; i < libraryRealAddressCount; i++)
		PayloadWriteString(stream, libraryRealAddresses[i]);
	PayloadWrite(stream, libraryRealPort);

	stream.flush();
	stream.close();

	char pid[5] = { 0 };
	memcpy(&pid, &pi.dwProcessId, sizeof(DWORD));
	auto semaphore = CreateSemaphoreA(NULL, 0, 1, (LPCSTR)&pid);
	//---------------------------------------------------------------------

	auto dll = libraryPath.c_str();

	auto handle = OpenProcess(PROCESS_ALL_ACCESS, false, pi.dwProcessId);
	if (handle == NULL)
		return false;

	auto LoadLibAddr = (LPVOID)GetProcAddress(GetModuleHandleA("kernel32.dll"), "LoadLibraryA");
	if (LoadLibAddr == NULL)
		return false;

	auto dereercomp = VirtualAllocEx(handle, NULL, strlen(dll), MEM_COMMIT | MEM_RESERVE, PAGE_READWRITE);
	if (dereercomp == NULL)
		return false;

	if (!WriteProcessMemory(handle, dereercomp, dll, strlen(dll),NULL))
		return false;

	auto remoteThread = CreateRemoteThread(handle, NULL, 0, (LPTHREAD_START_ROUTINE)LoadLibAddr, dereercomp, 0, NULL);
	if (remoteThread == NULL)
		return false;

	WaitForSingleObject(remoteThread, INFINITE);
	VirtualFreeEx(handle, dereercomp, strlen(dll), MEM_RELEASE);

	CloseHandle(remoteThread);
	CloseHandle(handle);

	ResumeThread(pi.hThread);
	ResumeThread(pi.hProcess);

	return pi.dwProcessId;
}