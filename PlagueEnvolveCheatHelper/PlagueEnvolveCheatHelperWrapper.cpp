#define DLLEXPORT extern "C" __declspec(dllexport)
#include <Windows.h>
#include <thread>
#include <TlHelp32.h>
#include "dataVariable.h"

// Get Module Base Address By provide Module Name
void GetModuleBaseAddress(LPCWSTR lpszModuleName)
{
	DWORD currentProcessID = GetCurrentProcessId();
	HWND currentParentWindow = GetActiveWindow();
	HANDLE hSnapshot = CreateToolhelp32Snapshot(TH32CS_SNAPMODULE, currentProcessID);
	if (hSnapshot == INVALID_HANDLE_VALUE) {
		MessageBox(currentParentWindow, L"Create Module Handle Failure", L"", MB_ICONERROR);
		return;
	}

	MODULEENTRY32 moduleEntry = { 0 };
	moduleEntry.dwSize = sizeof(MODULEENTRY32);
	if (!Module32First(hSnapshot, &moduleEntry)) {
		MessageBox(currentParentWindow, L"Enum Modules Failure", L"", MB_ICONERROR);
		return;
	}
	do {
		if (!_wcsicmp(moduleEntry.szModule, lpszModuleName)) {
			moduleBaseAddress = (uintptr_t)moduleEntry.modBaseAddr;
			break;
		}
	} while (Module32Next(hSnapshot, &moduleEntry));
	CloseHandle(hSnapshot);
}

// read process memory to store offsets
DLLEXPORT bool readProcessMemoryStatus()
{
	if (!moduleBaseAddress && !hCurrentProcess && !readMemoryOffsetValues) {
		GetModuleBaseAddress(L"UnityPlayer.dll");
		hCurrentProcess = GetCurrentProcess();
		readMemoryOffsetValues = new uintptr_t[8]{ 0 };
	}
	bool ret = false;
	ret = ReadProcessMemory(hCurrentProcess, (LPVOID)(moduleBaseAddress + 0x01792F28), &readMemoryOffsetValues[0], sizeof(readMemoryOffsetValues[0]), NULL);
	ret = ReadProcessMemory(hCurrentProcess, (LPVOID)(readMemoryOffsetValues[0] + 0x40), &readMemoryOffsetValues[1], sizeof(readMemoryOffsetValues[0]), NULL);
	ret = ReadProcessMemory(hCurrentProcess, (LPVOID)(readMemoryOffsetValues[1] + 0xC0), &readMemoryOffsetValues[2], sizeof(readMemoryOffsetValues[0]), NULL);
	ret = ReadProcessMemory(hCurrentProcess, (LPVOID)(readMemoryOffsetValues[2] + 0x1BC), &readMemoryOffsetValues[3], sizeof(readMemoryOffsetValues[0]), NULL);
	ret = ReadProcessMemory(hCurrentProcess, (LPVOID)(readMemoryOffsetValues[3] + 0x0), &readMemoryOffsetValues[4], sizeof(readMemoryOffsetValues[0]), NULL);
	ret = ReadProcessMemory(hCurrentProcess, (LPVOID)(readMemoryOffsetValues[4] + 0x338), &readMemoryOffsetValues[5], sizeof(readMemoryOffsetValues[0]), NULL);
	ret = ReadProcessMemory(hCurrentProcess, (LPVOID)(readMemoryOffsetValues[5] + 0x660), &readMemoryOffsetValues[6], sizeof(readMemoryOffsetValues[0]), NULL);
	ret = ReadProcessMemory(hCurrentProcess, (LPVOID)(readMemoryOffsetValues[6] + 0x14), &readMemoryOffsetValues[7], sizeof(readMemoryOffsetValues[0]), NULL);
	return ret;
}

// Modify Value
DLLEXPORT void modifyValue(uintptr_t& newValue)
{
	// write new value into memory
	WriteProcessMemory(hCurrentProcess, (LPVOID)(readMemoryOffsetValues[6] + 0x14), &newValue, sizeof(readMemoryOffsetValues[0]), NULL);
}

// Empty Allocate Memory
DLLEXPORT void emptyMemory()
{
	MessageBox(NULL, L"Empty Memory", L"", MB_ICONINFORMATION);
	delete[] readMemoryOffsetValues;
	readMemoryOffsetValues = nullptr;
	CloseHandle(hCurrentProcess);
}

// Get current point
DLLEXPORT uintptr_t getCurrentValue()
{
	if (!readMemoryOffsetValues)
		return -1;
	return readMemoryOffsetValues[7];
}