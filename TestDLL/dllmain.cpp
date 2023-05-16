#include <Windows.h>

unsigned long WINAPI MainThread(void* instance)
{
	// Your code...
	MessageBoxA(NULL, "Hello from inside the process!", "Hello World", 0);

	FreeLibraryAndExitThread(static_cast<HMODULE>(instance), EXIT_SUCCESS);
}

BOOL APIENTRY DllMain(const HMODULE hModule, unsigned long callReason, void* reserved)
{
	DisableThreadLibraryCalls(hModule);

	HANDLE handle{};

	switch (callReason)
	{
	case DLL_PROCESS_ATTACH:
		handle = CreateThread(nullptr, NULL, MainThread, hModule, NULL, nullptr);
		break;
	case DLL_PROCESS_DETACH:
		break;
	}

	if (handle)
		CloseHandle(handle);

	return TRUE;
}
