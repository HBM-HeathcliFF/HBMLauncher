#include <windows.h>
#include <string>
#include <fstream>
#include <tlhelp32.h>

BOOL Inject(DWORD pId, LPSTR dllName)
{
	HANDLE h = OpenProcess(PROCESS_ALL_ACCESS, FALSE, pId);
	if (h)
	{
		LPVOID LoadLibAddr = (LPVOID)GetProcAddress(GetModuleHandleA("kernel32.dll"), "LoadLibraryA");
		LPVOID dereercomp = VirtualAllocEx(h, NULL, strlen(dllName), MEM_COMMIT | MEM_RESERVE, PAGE_READWRITE);
		WriteProcessMemory(h, dereercomp, dllName, strlen(dllName), NULL);
		HANDLE asdc = CreateRemoteThread(h, NULL, NULL, (LPTHREAD_START_ROUTINE)LoadLibAddr, dereercomp, 0, NULL);
		WaitForSingleObject(asdc, INFINITE);
		VirtualFreeEx(h, dereercomp, strlen(dllName), MEM_RELEASE);
		CloseHandle(asdc);
		CloseHandle(h);
		return TRUE;
	}
	return FALSE;
}

int WINAPI WinMain(HINSTANCE hInst, HINSTANCE hPrevInst, LPSTR, int)
{
	char* temp = getenv("LOCALAPPDATA");
	const char* namef = "\\HBMLauncher\\Resources\\run.ini";
	char localApp[1024];
	strcpy_s(localApp, sizeof(localApp), temp);
	for (int i = strlen(temp), j = 0; i < strlen(temp) + 30; i++, j++)
	{
		localApp[i] = namef[j];
	}
	localApp[strlen(temp) + 30] = '\0';

	std::ifstream fin(localApp);
	std::string str = "";
	char name[30], ip[24];
	int port;
	if (fin.is_open())
	{
		getline(fin, str);
		strcpy_s(ip, sizeof(ip), str.c_str());
		getline(fin, str);
		port = atoi(str.c_str());
		getline(fin, str);
		strcpy_s(name, sizeof(name), str.c_str());
	}
	fin.close();

	char commandLine[256];
	sprintf_s(commandLine, sizeof(commandLine), "-c -n %s -h %s -p %d", name, ip, port);

	STARTUPINFOA cif;
	ZeroMemory(&cif, sizeof(STARTUPINFOA));
	PROCESS_INFORMATION pi;
	
	if (CreateProcessA("gta_sa.exe", commandLine, NULL, NULL, FALSE, DETACHED_PROCESS | CREATE_SUSPENDED, NULL, NULL, &cif, &pi))
	{
		if (pi.hProcess != NULL)
		{
			if (!Inject(pi.dwProcessId, (char*)"samp.dll") || !Inject(pi.dwProcessId, (char*)"sampar.dll"))
			{
				TerminateProcess(pi.hProcess, 0);
				ExitProcess(0);
			}
			ResumeThread(pi.hThread);
		}
	}
	else MessageBoxA(NULL, "Failed to Create Process", "Error", MB_ICONERROR);
}