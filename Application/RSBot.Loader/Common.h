#pragma once

#ifndef COMMON_H_
#define COMMON_H_

//-----------------------------------------------------------------------------

#include <windows.h>
#include <vector>

//-----------------------------------------------------------------------------

// Class that will generate an assembly stub based on a user function
class AsmStubGenerator
{
private:
	// Array of place holder positions
	DWORD placeHolderPositions[1024];
	DWORD placeHolderIndex;

	// Workspace to build the asm code into
	LPBYTE workspace;
	LPBYTE tmpWorkSpace;
	DWORD workspaceIndex;

	// Max buffer sizes for code and data
	DWORD maxCodeSize;
	DWORD maxDataSize;

public:
	// Ctor for the class
	AsmStubGenerator(DWORD dataSize, DWORD codeSize);

	// Dtor for the class
	~AsmStubGenerator();

	// Generate the asm stub given the base address where it should reside in memory
	BYTE* GenerateAsmStub(LPVOID baseAddress);

	// Returns the total raw size of the workspace
	DWORD GetTotalSize();

	// Generate the asm listing
	void Initialize(LPVOID lpBuffer, DWORD dwSize, DWORD dwMagic);

	// This function will add a string to the assembly buffer
	DWORD AddString(const char* text);

	// This function will add a DWORD to the assembly buffer
	DWORD AddDword(DWORD value);

	// This function will add a WORD to the assembly buffer
	DWORD AddWord(WORD value);

	// This function will add a BYTE to the assembly buffer
	DWORD AddByte(BYTE value);

	// This function will add an array to the assembly buffer
	DWORD AddArray(LPVOID data, DWORD size);

	// This function will automatically replace a place holder with the correct address from the data section
	void SetPlaceHolder(DWORD index, DWORD offset);

	// This function will overwrite bytes at a particular location in the buffer
	void OverwriteDword(DWORD offset, DWORD value, BOOL dataSection);

	// This function will overwrite bytes at a particular location in the buffer
	void OverwriteWord(DWORD offset, WORD value, BOOL dataSection);

	// This function will overwrite bytes at a particular location in the buffer
	void OverwriteByte(DWORD offset, BYTE value, BOOL dataSection);

	// This function will overwrite bytes at a particular location in the buffer
	void OverwriteArray(DWORD offset, LPBYTE data, DWORD size, BOOL dataSection);
};

//-----------------------------------------------------------------------------

// New function for injecting a DLL into a process using a asm stub in the process
void InjectDLL(HANDLE hProcess, DWORD injectAddress, const char* dllName, const char* funcName);

// Returns the entry point of an EXE (not made for 64-bit applications)
DWORD GetFileEntryPoint(CONST CHAR* filename);

// Writes bytes to a process
BOOL WriteProcessBytes(HANDLE hProcess, DWORD destAddress, LPVOID patch, DWORD numBytes);

// Reads bytes of a process
BOOL ReadProcessBytes(HANDLE hProcess, DWORD destAddress, LPVOID buffer, DWORD numBytes);

// Patches bytes in the current process
BOOL WriteBytes(DWORD destAddress, LPVOID patch, DWORD numBytes);

// Reads bytes in the current process
BOOL ReadBytes(DWORD sourceAddress, LPVOID buffer, DWORD numBytes);

// Creates a codecave
BOOL CreateCodeCave(DWORD destAddress, BYTE patchSize, VOID(*function)(VOID));

// Byte signature searching function
std::vector<LONGLONG> FindSignature(LPBYTE sigBuffer, LPBYTE sigWildCard, DWORD sigSize, PBYTE pBuffer, LONGLONG size);

//-----------------------------------------------------------------------------

#endif
