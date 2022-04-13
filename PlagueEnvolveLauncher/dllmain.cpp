#include "pch.h"
#include <thread>
#include <metahost.h>
#pragma comment(lib, "mscoree.lib")

void RunCheat(LPVOID pm)
{
    HRESULT hr = S_OK;
    ICLRMetaHost* pMetaHost = nullptr;
    ICLRRuntimeInfo* pRuntimeInfo = nullptr;
    ICLRRuntimeHost* pClrRuntimeHost = nullptr;
    
    //Bind to the CLR runtime
    hr = CLRCreateInstance(CLSID_CLRMetaHost, IID_ICLRMetaHost, (LPVOID*)&pMetaHost);
    if (hr != S_OK) {
        MessageBox(NULL, L"CLRCreateInstance Failure", L"", MB_ICONERROR);
    }
    hr = pMetaHost->GetRuntime(L"v4.0.30319", IID_ICLRRuntimeInfo, (LPVOID*)&pRuntimeInfo);
    if (hr != S_OK) {
        MessageBox(NULL, L"GetRuntime Failure", L"", MB_ICONERROR);
    }
    hr = pRuntimeInfo->GetInterface(CLSID_CLRRuntimeHost, IID_ICLRRuntimeHost, (LPVOID*)&pClrRuntimeHost);
    if (FAILED(hr)) {
        MessageBox(NULL, L"GetInterface Failure", L"", MB_ICONERROR);
    }

    hr = pClrRuntimeHost->Start();

    DWORD dwRet = 0;
    hr = pClrRuntimeHost->ExecuteInDefaultAppDomain(
        L"PlagueEnvolveCheatGUI.dll",
        L"PlagueEnvolveCheatGUI.Program",
        L"RunGUIWindow",
        L"",
        &dwRet
    );
    //hr = pClrRuntimeHost->Stop();
    pClrRuntimeHost->Release();
}

BOOL APIENTRY DllMain( HMODULE hModule, DWORD  ul_reason_for_call, LPVOID lpReserved )
{
    switch (ul_reason_for_call)
    {
    case DLL_PROCESS_ATTACH:
        _beginthread((void(__cdecl*)(void*))RunCheat, NULL, NULL);
        // CreateThread(NULL, NULL, (LPTHREAD_START_ROUTINE)RunCheat, NULL, NULL, NULL);
        break;
    case DLL_THREAD_ATTACH:
        break;
    case DLL_THREAD_DETACH:
        break;
    case DLL_PROCESS_DETACH:
        break;
    }
    return TRUE;
}

