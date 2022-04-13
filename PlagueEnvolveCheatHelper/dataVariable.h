#pragma once
// Module Base Address
uintptr_t moduleBaseAddress = NULL;

// Current Process Handle
HANDLE hCurrentProcess = NULL;

// Read Memory from game store array
uintptr_t* readMemoryOffsetValues = nullptr;