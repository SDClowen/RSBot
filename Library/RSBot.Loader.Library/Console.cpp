#include "Console.h"

#include <io.h>
#include <fcntl.h>
#include <windows.h>
#include <stdio.h>

// Creates a console, need to call FreeConsole before exit
void AddConsole(const char* winTitle)
{
	// http://www.gamedev.net/community/forums/viewreply.asp?ID=1958358
	INT hConHandle = 0;
	HANDLE lStdHandle = 0;
	FILE* fp = 0;

	// Allocate the console
	AllocConsole();

	// Set a title if we need one
	if (winTitle)
		SetConsoleTitleA(winTitle);

	// redirect unbuffered STDOUT to the console
	lStdHandle = GetStdHandle(STD_OUTPUT_HANDLE);
	hConHandle = _open_osfhandle(PtrToUlong(lStdHandle), _O_TEXT);
	fp = _fdopen(hConHandle, "w");
	*stdout = *fp;
	setvbuf(stdout, NULL, _IONBF, 0);

	// redirect unbuffered STDIN to the console
	lStdHandle = GetStdHandle(STD_INPUT_HANDLE);
	hConHandle = _open_osfhandle(PtrToUlong(lStdHandle), _O_TEXT);
	fp = _fdopen(hConHandle, "r");
	*stdin = *fp;
	setvbuf(stdin, NULL, _IONBF, 0);

	// redirect unbuffered STDERR to the console
	lStdHandle = GetStdHandle(STD_ERROR_HANDLE);
	hConHandle = _open_osfhandle(PtrToUlong(lStdHandle), _O_TEXT);
	fp = _fdopen(hConHandle, "w");
	*stderr = *fp;
	setvbuf(stderr, NULL, _IONBF, 0);
}

void RemoveConsole()
{
	FreeConsole();
}