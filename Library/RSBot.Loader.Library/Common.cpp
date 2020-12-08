#include "common.h"
#include <sstream>
#include <algorithm>

//-----------------------------------------------------------------------------

// Macro for adding pointers/DWORDs together without C arithmetic interfering
#define MakePtr( cast, ptr, addValue ) (cast)( (DWORD)(ptr)+(DWORD)(addValue))

// Returns the entry point of an EXE (not made for 64-bit applications)
DWORD GetFileEntryPoint(CONST CHAR* filename)
{
	DWORD OEP = 0;
	HANDLE hFile = NULL;
	HANDLE hFileMapping = NULL;
	PIMAGE_DOS_HEADER dosHeader = { 0 };
	PBYTE g_pMappedFileBase = NULL;
	PIMAGE_FILE_HEADER pImgFileHdr = NULL;

	// Try to open the file
	hFile = CreateFileA(filename, GENERIC_READ, FILE_SHARE_READ, NULL, OPEN_EXISTING, FILE_ATTRIBUTE_NORMAL, 0);
	if (hFile == INVALID_HANDLE_VALUE)
		return 0;

	// Create a file mapping object
	hFileMapping = CreateFileMapping(hFile, NULL, PAGE_READONLY, 0, 0, NULL);
	if (hFileMapping == 0)
	{
		CloseHandle(hFile);
		return 0;
	}

	// Get the data pointer
	g_pMappedFileBase = (PBYTE)MapViewOfFile(hFileMapping, FILE_MAP_READ, 0, 0, 0);
	if (g_pMappedFileBase == 0)
	{
		CloseHandle(hFileMapping);
		CloseHandle(hFile);
		return 0;
	}

	// Type cast the data
	dosHeader = (PIMAGE_DOS_HEADER)g_pMappedFileBase;
	pImgFileHdr = (PIMAGE_FILE_HEADER)g_pMappedFileBase;
	if (dosHeader->e_magic == IMAGE_DOS_SIGNATURE)
	{
		PIMAGE_NT_HEADERS pNTHeader = MakePtr(PIMAGE_NT_HEADERS, dosHeader, dosHeader->e_lfanew);
		PIMAGE_NT_HEADERS64 pNTHeader64 = (PIMAGE_NT_HEADERS64)pNTHeader;

		// First, verify that the e_lfanew field gave us a reasonable pointer, then verify the PE signature.
		if (IsBadReadPtr(pNTHeader, sizeof(pNTHeader->Signature)) || pNTHeader->Signature != IMAGE_NT_SIGNATURE)
		{
			UnmapViewOfFile(g_pMappedFileBase);
			CloseHandle(hFileMapping);
			CloseHandle(hFile);
			return 0;
		}

		// Do not support 64bit applications
		if (pNTHeader->OptionalHeader.Magic == IMAGE_NT_OPTIONAL_HDR64_MAGIC)
		{
			//OEP = pNTHeader64->OptionalHeader.AddressOfEntryPoint + pNTHeader64->OptionalHeader.ImageBase;
			return 0;
		}
		else
		{
			OEP = pNTHeader->OptionalHeader.AddressOfEntryPoint + pNTHeader->OptionalHeader.ImageBase;
		}
	}

	// Unmap the view
	UnmapViewOfFile(g_pMappedFileBase);

	// Close the handles
	CloseHandle(hFileMapping);
	CloseHandle(hFile);

	// Return the entry point
	return OEP;
}

// Remove name scope
#undef MakePtr

//-----------------------------------------------------------------------------

// Writes bytes to a process
BOOL WriteProcessBytes(HANDLE hProcess, DWORD destAddress, LPVOID patch, DWORD numBytes)
{
	DWORD oldProtect = 0;	// Old protection on page we are writing to
	DWORD bytesRet = 0;		// # of bytes written
	BOOL status = TRUE;		// Status of the function

							// Change page protection so we can write executable code
	if (!VirtualProtectEx(hProcess, UlongToPtr(destAddress), numBytes, PAGE_EXECUTE_READWRITE, &oldProtect))
		return FALSE;

	// Write out the data
	if (!WriteProcessMemory(hProcess, UlongToPtr(destAddress), patch, numBytes, &bytesRet))
		status = FALSE;

	// Compare written bytes to the size of the patch
	if (bytesRet != numBytes)
		status = FALSE;

	// Restore the old page protection
	if (!VirtualProtectEx(hProcess, UlongToPtr(destAddress), numBytes, oldProtect, &oldProtect))
		status = FALSE;

	// Make sure changes are made!
	if (!FlushInstructionCache(hProcess, UlongToPtr(destAddress), numBytes))
		status = FALSE;

	// Return the final status, note once we set page protection, we don't want to prematurely return
	return status;
}

//-----------------------------------------------------------------------------

// Reads bytes of a process
BOOL ReadProcessBytes(HANDLE hProcess, DWORD destAddress, LPVOID buffer, DWORD numBytes)
{
	DWORD oldProtect = 0;	// Old protection on page we are writing to
	DWORD bytesRet = 0;		// # of bytes written
	BOOL status = TRUE;		// Status of the function

							// Change page protection so we can read bytes
	if (!VirtualProtectEx(hProcess, UlongToPtr(destAddress), numBytes, PAGE_READONLY, &oldProtect))
		return FALSE;

	// Read in the data
	if (!ReadProcessMemory(hProcess, UlongToPtr(destAddress), buffer, numBytes, &bytesRet))
		status = FALSE;

	// Compare written bytes to the size of the patch
	if (bytesRet != numBytes)
		status = FALSE;

	// Restore the old page protection
	if (!VirtualProtectEx(hProcess, UlongToPtr(destAddress), numBytes, oldProtect, &oldProtect))
		status = FALSE;

	// Return the final status, note once we set page protection, we don't want to prematurely return
	return status;
}

//-----------------------------------------------------------------------------

// Patches bytes in the current process
BOOL WriteBytes(DWORD destAddress, LPVOID patch, DWORD numBytes)
{
	// Store old protection of the memory page
	DWORD oldProtect = 0;

	// Store the source address
	DWORD srcAddress = PtrToUlong(patch);

	// Result of the function
	BOOL result = TRUE;

	// Make sure page is writable
	result = result && VirtualProtect(UlongToPtr(destAddress), numBytes, PAGE_EXECUTE_READWRITE, &oldProtect);

	// Copy over the patch
	memcpy(UlongToPtr(destAddress), patch, numBytes);

	// Restore old page protection
	result = result && VirtualProtect(UlongToPtr(destAddress), numBytes, oldProtect, &oldProtect);

	// Make sure changes are made
	result = result && FlushInstructionCache(GetCurrentProcess(), UlongToPtr(destAddress), numBytes);

	// Return the result
	return result;
}

//-----------------------------------------------------------------------------

// Reads bytes in the current process
BOOL ReadBytes(DWORD sourceAddress, LPVOID buffer, DWORD numBytes)
{
	// Store old protection of the memory page
	DWORD oldProtect = 0;

	// Store the source address
	DWORD dstAddress = PtrToUlong(buffer);

	// Result of the function
	BOOL result = TRUE;

	// Make sure page is writable
	result = result && VirtualProtect(UlongToPtr(sourceAddress), numBytes, PAGE_EXECUTE_READWRITE, &oldProtect);

	// Copy over the patch
	memcpy(buffer, UlongToPtr(sourceAddress), numBytes);

	// Restore old page protection
	result = result && VirtualProtect(UlongToPtr(sourceAddress), numBytes, oldProtect, &oldProtect);

	// Return the result
	return result;
}

//-----------------------------------------------------------------------------

// Creates a codecave
BOOL CreateCodeCave(DWORD destAddress, BYTE patchSize, VOID(*function)(VOID))
{
	// Offset to make the codecave at
	DWORD offset = 0;

	// Bytes to write
	BYTE patch[5] = { 0 };

	// Number of extra nops we need
	BYTE nopCount = 0;

	// NOP buffer
	static BYTE nop[0xFF] = { 0 };

	// Is the buffer filled?
	static BOOL filled = FALSE;

	// Need at least 5 bytes to be patched
	if (patchSize < 5)
		return FALSE;

	// Calculate the code cave
	offset = (PtrToUlong(function) - destAddress) - 5;

	// Construct the patch to the function call
	patch[0] = 0xE8;
	memcpy(patch + 1, &offset, sizeof(DWORD));
	WriteBytes(destAddress, patch, 5);

	// We are done if we do not have NOPs
	nopCount = patchSize - 5;
	if (nopCount == 0)
		return TRUE;

	// Fill in the buffer
	if (filled == FALSE)
	{
		memset(nop, 0x90, 0xFF);
		filled = TRUE;
	}

	// Make the patch now
	WriteBytes(destAddress + 5, nop, nopCount);

	// Success
	return TRUE;
}

//-----------------------------------------------------------------------------

// Assembly macro that will need to be invoked in the user's function that will
// be assembled into a stub.
#define ASSEMBLE_MACRO(param1, param2)		\
	LPVOID tmpBuffer = 0;						\
	DWORD tmpSize = 0;							\
	__asm { mov eax, offset buffer_begin }		\
	__asm { mov tmpBuffer, eax }				\
	__asm { mov edx, offset buffer_end }		\
	__asm { sub edx, eax }						\
	__asm { mov tmpSize, edx }					\
	param1 = tmpBuffer;							\
	param2 = tmpSize;							\
	return;

// This is the user function to assemble - a dll loading stub
void AsmLoaderStub(LPVOID& lpBuffer, DWORD& dwSize)
{
	// This is the required macro we need to place in this function
	// to setup the assembly code.
	ASSEMBLE_MACRO(lpBuffer, dwSize);

	__asm
	{
		// The assembly code needs to have this code start marker
	buffer_begin:

		// Attach debugger loop
		//START:	JMP START

		// Save registers
		PUSHAD

			// User32 DLL Loading
			// user32.dll string address
			PUSH 0xDEADF00D							// 0
													// LoadLibraryA address
			MOV EAX, 0xDEADF00D						// 1
			MOV EAX, [EAX]
			// Call LoadLibraryA
			CALL EAX

			// MessageBoxA Loading
			// MessageBoxA function name
			PUSH 0xDEADF00D							// 2
													// User32.dll address
			PUSH EAX
			// GetProcAddress address into eax
			MOV EAX, 0xDEADF00D						// 3
			MOV EAX, [EAX]
			// Call GetProcAddress
			CALL EAX
			// Move the address of MessageBoxA into the user stored address
			MOV ECX, 0xDEADF00D						// 4
			MOV[ECX], EAX

			// DLL Loading
			// DLL name
			PUSH 0xDEADF00D							// 5
													// Move the address of LoadLibraryA into EAX
			MOV EAX, 0xDEADF00D						// 6
			MOV EAX, [EAX]
			// Call LoadLibraryA
			CALL EAX

			// Error Checking
			CMP EAX, 0
			JNZ CONTINUE1

			// MessageBox Error
			PUSH 0x10
			PUSH 0xDEADF00D							// 7
			PUSH 0xDEADF00D							// 8
			PUSH 0
			MOV EAX, 0xDEADF00D						// 9
			MOV EAX, [EAX]
			CALL EAX

			// ExitProcess
			PUSH 0
			MOV EAX, 0xDEADF00D						// 10
			MOV EAX, [EAX]
			CALL EAX

			CONTINUE1 :
		// Move the handle into our own variable
		MOV ECX, 0xDEADF00D						// 11
			MOV[ECX], EAX

			// GetProcAddress
			PUSH 0xDEADF00D							// 12
			PUSH EAX
			MOV EAX, 0xDEADF00D						// 13
			MOV EAX, [EAX]
			CALL EAX

			// Error Checking
			CMP EAX, 0
			JNZ CONTINUE2

			// MessageBox Error
			PUSH 0x10
			PUSH 0xDEADF00D							// 14
			PUSH 0xDEADF00D							// 15
			PUSH 0
			MOV EAX, 0xDEADF00D						// 16
			MOV EAX, [EAX]
			CALL EAX

			// ExitProcess
			PUSH 0
			MOV EAX, 0xDEADF00D						// 17
			MOV EAX, [EAX]
			CALL EAX

			CONTINUE2 :
		// Pointer to original bytes
		MOV ECX, 0xDEADF00D							// 18
			PUSH ECX

			// OEP of process to write original bytes to
			MOV ECX, 0xDEADF00D							// 19
			MOV ECX, [ECX]
			PUSH ECX

			// Allocation buffer of the stub to free
			MOV ECX, 0xDEADF00D							// 20
			MOV ECX, [ECX]
			PUSH ECX

			// Call Initialize
			CALL EAX

			// Add ESP, C, since we have 3 parameters
			ADD ESP, 0xC

			// Restore registers
			POPAD

			// Return to OEP
			POP EAX
			SUB EAX, 5
			PUSH EAX
			RET

			// The assembly code needs to have this code end marker
			buffer_end :
	}
}

//-----------------------------------------------------------------------------

// Ctor for the class
AsmStubGenerator::AsmStubGenerator(DWORD dataSize, DWORD codeSize)
{
	memset(placeHolderPositions, 0, 1024 * sizeof(DWORD));
	placeHolderIndex = 0;
	workspaceIndex = 0;
	maxDataSize = dataSize;
	maxCodeSize = codeSize;

	// Space for the workspaces
	workspace = new BYTE[maxCodeSize + maxDataSize];
	memset(workspace, 0, maxCodeSize + maxDataSize);
	tmpWorkSpace = new BYTE[maxCodeSize + maxDataSize];
	memset(tmpWorkSpace, 0, maxCodeSize + maxDataSize);
}

// Dtor for the class
AsmStubGenerator::~AsmStubGenerator()
{
	// Free the memory at the end
	delete[] workspace;
	delete[] tmpWorkSpace;
}

// Generate the asm stub given the base address where it should reside in memory
BYTE* AsmStubGenerator::GenerateAsmStub(LPVOID baseAddress)
{
	// Copy over the original workspace data
	memcpy(tmpWorkSpace, workspace, maxCodeSize + maxDataSize);

	// Store the base address
	DWORD base = PtrToUlong(baseAddress);

	for (DWORD x = 0; x < placeHolderIndex; ++x)
	{
		// The value to update
		DWORD value = 0;

		// Read in the offset value
		memcpy(&value, workspace + placeHolderPositions[x] + maxDataSize, 4);

		// Update the offset value with the real base address
		value += base;

		// Read in the offset value
		memcpy(tmpWorkSpace + placeHolderPositions[x] + maxDataSize, &value, 4);
	}

	// Return the new workspace
	return tmpWorkSpace;
}

// Returns the total raw size of the workspace
DWORD AsmStubGenerator::GetTotalSize()
{
	return (maxCodeSize + maxDataSize);
}

// Generate the asm listing
void AsmStubGenerator::Initialize(LPVOID lpBuffer, DWORD dwSize, DWORD dwMagic)
{
	// Clear the workspace to begin with
	memset(workspace, 0, maxCodeSize + maxDataSize);
	memset(tmpWorkSpace, 0, maxCodeSize + maxDataSize);

	// Copy over the asm code into the workspace now
	memcpy(workspace + maxDataSize, lpBuffer, dwSize);

	// Reset the place holders
	placeHolderIndex = 0;
	memset(placeHolderPositions, 0, 1024 * sizeof(DWORD));

	// Start with a clean workspace
	workspaceIndex = 0;

	// Loop through and calculate all place holders from the magic byte
	for (DWORD x = 0; x < dwSize - 4; ++x)
	{
		// Look for the magic byte
		if (*LPDWORD(((LPBYTE)lpBuffer) + x) == dwMagic)
		{
			// Store the position of the place holder
			placeHolderPositions[placeHolderIndex++] = x;
			if (placeHolderIndex >= 1024)
			{
				MessageBoxA(0, "Error", "Too many place holder positions detected.", MB_ICONERROR);
				abort();
			}
		}
	}
}

// This function will add a string to the assembly buffer
DWORD AsmStubGenerator::AddString(const char* text)
{
	// Store the current workspace index
	int index = workspaceIndex;

	// Prestore the size
	DWORD size = (DWORD)strlen(text) + 1;

	// Error checking
	if (index + size >= maxDataSize)
	{
		MessageBoxA(0, "Error", "AddString workspace buffer overflow.", MB_ICONERROR);
		abort();
	}

	// Copy the data into the workspace
	//strcpy((char*)(workspace + index), text);
	memcpy((workspace + index), text, size);

	// Update byte count for data
	workspaceIndex += size;

	// Return the offset to reference this data
	return index;
}

// This function will add a DWORD to the assembly buffer
DWORD AsmStubGenerator::AddDword(DWORD value)
{
	// Store the current workspace index
	int index = workspaceIndex;

	// Prestore the size
	DWORD size = 4;

	// Error checking
	if (index + size >= maxDataSize)
	{
		MessageBoxA(0, "Error", "AddDword workspace buffer overflow.", MB_ICONERROR);
		abort();
	}

	// Copy the data into the workspace
	memcpy(workspace + index, &value, size);

	// Update byte count for data
	workspaceIndex += size;

	// Return the offset to reference this data
	return index;
}

// This function will add a WORD to the assembly buffer
DWORD AsmStubGenerator::AddWord(WORD value)
{
	// Store the current workspace index
	int index = workspaceIndex;

	// Prestore the size
	DWORD size = 2;

	// Error checking
	if (index + size >= maxDataSize)
	{
		MessageBoxA(0, "Error", "WriteWord workspace buffer overflow.", MB_ICONERROR);
		abort();
	}

	// Copy the data into the workspace
	memcpy(workspace + index, &value, size);

	// Update byte count for data
	workspaceIndex += size;

	// Return the offset to reference this data
	return index;
}

// This function will add a BYTE to the assembly buffer
DWORD AsmStubGenerator::AddByte(BYTE value)
{
	// Store the current workspace index
	int index = workspaceIndex;

	// Prestore the size
	DWORD size = 1;

	// Error checking
	if (index + size >= maxDataSize)
	{
		MessageBoxA(0, "Error", "WriteByte workspace buffer overflow.", MB_ICONERROR);
		abort();
	}

	// Copy the data into the workspace
	memcpy(workspace + index, &value, size);

	// Update byte count for data
	workspaceIndex += size;

	// Return the offset to reference this data
	return index;
}

// This function will add an array to the assembly buffer
DWORD AsmStubGenerator::AddArray(LPVOID data, DWORD size)
{
	// Store the current workspace index
	int index = workspaceIndex;

	// Error checking
	if (index + size >= maxDataSize)
	{
		MessageBoxA(0, "Error", "WriteArray workspace buffer overflow.", MB_ICONERROR);
		abort();
	}

	// Copy the data into the workspace
	memcpy(workspace + index, data, size);

	// Update byte count for data
	workspaceIndex += size;

	// Return the offset to reference this data
	return index;
}

// This function will automatically replace a place holder with the correct address from the data section
void AsmStubGenerator::SetPlaceHolder(DWORD index, DWORD offset)
{
	// Error checking
	if (index >= placeHolderIndex)
	{
		MessageBoxA(0, "SetPlaceHolder called with an illegal index.", "Error", MB_ICONERROR);
		abort();
	}

	// Write that address to the workspace
	memcpy(workspace + placeHolderPositions[index] + maxDataSize, &offset, 4);
}

// This function will overwrite bytes at a particular location in the buffer
void AsmStubGenerator::OverwriteDword(DWORD offset, DWORD value, BOOL dataSection)
{
	// Prestore the size
	DWORD size = 4;

	// Section offset
	DWORD section = 0;

	// Determine if we need to start at the code or data section
	if (dataSection == TRUE)
		section = 0;
	else
		section = maxDataSize;

	// Copy the data into the workspace
	memcpy(workspace + offset + section, &value, size);
}

// This function will overwrite bytes at a particular location in the buffer
void AsmStubGenerator::OverwriteWord(DWORD offset, WORD value, BOOL dataSection)
{
	// Prestore the size
	DWORD size = 2;

	// Section offset
	DWORD section = 0;

	// Determine if we need to start at the code or data section
	if (dataSection == TRUE)
		section = 0;
	else
		section = maxDataSize;

	// Copy the data into the workspace
	memcpy(workspace + offset + section, &value, size);
}

// This function will overwrite bytes at a particular location in the buffer
void AsmStubGenerator::OverwriteByte(DWORD offset, BYTE value, BOOL dataSection)
{
	// Prestore the size
	DWORD size = 1;

	// Section offset
	DWORD section = 0;

	// Determine if we need to start at the code or data section
	if (dataSection == TRUE)
		section = 0;
	else
		section = maxDataSize;

	// Copy the data into the workspace
	memcpy(workspace + offset + section, &value, size);
}

// This function will overwrite bytes at a particular location in the buffer
void AsmStubGenerator::OverwriteArray(DWORD offset, LPBYTE data, DWORD size, BOOL dataSection)
{
	// Section offset
	DWORD section = 0;

	// Determine if we need to start at the code or data section
	if (dataSection == TRUE)
		section = 0;
	else
		section = maxDataSize;

	// Copy the data into the workspace
	memcpy(workspace + offset + section, data, size);
}

//-----------------------------------------------------------------------------

// New function for injecting a DLL into a process using a asm stub in the process
void InjectDLL(HANDLE hProcess, DWORD injectAddress, const char* dllName, const char* funcName)
{
	// Max size of data section
	DWORD dataSize = 512;

	// Max size of code section
	DWORD codeSize = 512;

	// Pointer to the stub
	LPVOID lpBuffer = 0;

	// Size of the stub
	DWORD dwSize = 0;

	// Generate a memory block in the target process to write to (our asm stub uses this address too)
	LPVOID allocAddress = VirtualAllocEx(hProcess, 0, dataSize + codeSize, MEM_COMMIT | MEM_RESERVE, PAGE_EXECUTE_READWRITE);;

	// Setup an asm generator
	AsmStubGenerator asmStub(dataSize, codeSize);

	// Call our function to store the pointer to the code and size
	AsmLoaderStub(lpBuffer, dwSize);

	// Initialuze the asm stub generator with the data
	asmStub.Initialize(lpBuffer, dwSize, 0xDEADF00D);

	///////////////////////////////////////////////////////////////////////////////
	// This is the section that we fill in the asm stub's place holder data		 //
	///////////////////////////////////////////////////////////////////////////////

	// STRING's

	CHAR error1[1024] = { 0 };
	_snprintf_s(error1, 1023, "The DLL \"%s\" was not able to be loaded successfully.", dllName);

	CHAR error2[1024] = { 0 };
	_snprintf_s(error2, 1023, "The function \"%s\" was not able to be loaded from the DLL successfully.", funcName);

	DWORD string_User32DLLName = asmStub.AddString("user32.dll");
	DWORD string_MessageBoxAName = asmStub.AddString("MessageBoxA");
	DWORD string_InjectDLLName = asmStub.AddString(dllName);
	DWORD string_ErrorMsgTitle = asmStub.AddString("Fatal Error");
	DWORD string_InjectDLLFunc = asmStub.AddString(funcName);
	DWORD string_Error1 = asmStub.AddString(error1);
	DWORD string_Error2 = asmStub.AddString(error2);

	asmStub.SetPlaceHolder(0, string_User32DLLName);
	asmStub.SetPlaceHolder(2, string_MessageBoxAName);
	asmStub.SetPlaceHolder(5, string_InjectDLLName);
	asmStub.SetPlaceHolder(7, string_ErrorMsgTitle);
	asmStub.SetPlaceHolder(8, string_Error1);
	asmStub.SetPlaceHolder(12, string_InjectDLLFunc);
	asmStub.SetPlaceHolder(14, string_ErrorMsgTitle);
	asmStub.SetPlaceHolder(15, string_Error2);

	// DWORD's

	DWORD dword_LoadLibraryA = asmStub.AddDword(PtrToUlong(GetProcAddress(LoadLibraryA("kernel32.dll"), "LoadLibraryA")));
	DWORD dword_GetProcAddress = asmStub.AddDword(PtrToUlong(GetProcAddress(LoadLibraryA("kernel32.dll"), "GetProcAddress")));
	DWORD dword_ExitProcess = asmStub.AddDword(PtrToUlong(GetProcAddress(LoadLibraryA("kernel32.dll"), "ExitProcess")));
	DWORD dword_MessageBoxA = asmStub.AddDword(0);
	DWORD dword_DLLHandle = asmStub.AddDword(0);
	DWORD dword_OEP = asmStub.AddDword(injectAddress);
	DWORD dword_Alloc = asmStub.AddDword(PtrToUlong(allocAddress));

	asmStub.SetPlaceHolder(1, dword_LoadLibraryA);
	asmStub.SetPlaceHolder(3, dword_GetProcAddress);
	asmStub.SetPlaceHolder(4, dword_MessageBoxA);
	asmStub.SetPlaceHolder(6, dword_LoadLibraryA);
	asmStub.SetPlaceHolder(9, dword_MessageBoxA);
	asmStub.SetPlaceHolder(10, dword_ExitProcess);
	asmStub.SetPlaceHolder(11, dword_DLLHandle);
	asmStub.SetPlaceHolder(13, dword_GetProcAddress);
	asmStub.SetPlaceHolder(16, dword_MessageBoxA);
	asmStub.SetPlaceHolder(17, dword_ExitProcess);
	asmStub.SetPlaceHolder(19, dword_OEP);
	asmStub.SetPlaceHolder(20, dword_Alloc);

	// ARRAY's

	// This will save the original 6 bytes at OEP to the asm stub so the DLL can restore them
	BYTE oepBytes[6] = { 0 };
	DWORD read = 0;
	ReadProcessMemory(hProcess, UlongToPtr(injectAddress), oepBytes, 6, &read);

	DWORD addr_OepBytes = asmStub.AddArray(oepBytes, 6);

	asmStub.SetPlaceHolder(18, addr_OepBytes);

	// Write the workspace to the process now
	WriteProcessBytes(hProcess, PtrToUlong(allocAddress), asmStub.GenerateAsmStub(allocAddress), asmStub.GetTotalSize());

	// Calculate the OEP of the workspace
	DWORD oep = PtrToUlong(allocAddress) + dataSize;

	// Now that the patch is written into the process, we need to make the process call it
	BYTE patch2[6] = { 0xE8, 0x00, 0x00, 0x00, 0x00, 0x90 };

	// Calculate the JMP offset +5 for the FAR JMP we are adding)
	DWORD toCC = oep - (injectAddress + 5);

	// Write the offset to the patch
	memcpy(patch2 + 1, &toCC, sizeof(toCC));

	// Make the patch that will JMP to the codecave
	WriteProcessBytes(hProcess, injectAddress, patch2, 6);
}

//-----------------------------------------------------------------------------

// Byte signature searching function
std::vector<LONGLONG> FindSignature(LPBYTE sigBuffer, LPBYTE sigWildCard, DWORD sigSize, PBYTE pBuffer, LONGLONG size)
{
	std::vector<LONGLONG> results;
	for (LONGLONG index = 0; index < size; ++index)
	{
		bool found = true;
		for (DWORD sindex = 0; sindex < sigSize; ++sindex)
		{
			// Make sure we don't overrun the buffer!
			if (sindex + index >= size)
			{
				found = false;
				break;
			}

			if (sigWildCard != 0)
			{
				if (pBuffer[index + sindex] != sigBuffer[sindex] && sigWildCard[sindex] == 0)
				{
					found = false;
					break;
				}
			}
			else
			{
				if (pBuffer[index + sindex] != sigBuffer[sindex])
				{
					found = false;
					break;
				}
			}
		}
		if (found)
		{
			results.push_back(index);
		}
	}
	return results;
}

//-----------------------------------------------------------------------------