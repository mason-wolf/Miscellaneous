#define UNICODE
#include <stdio.h>
#include <wchar.h>
#include <windows.h>

#define WINDOW_TITLE L""

int main(void)
{
	HWND Handle;
	LONG_PTR Window_Style;

	while (1)
	{
		Handle = FindWindow(NULL, WINDOW_TITLE);
		if (Handle != NULL) break;
		Sleep(1000); 
	}
	
	Window_Style = GetWindowLongPtr(Handle, GWL_STYLE);
	if (Window_Style == 0)
	{
		return EXIT_FAILURE;
	}

	Window_Style &= ~(WS_BORDER | WS_CAPTION);
	if (SetWindowLongPtr(Handle, GWL_STYLE, Window_Style) == 0)
	{
		return EXIT_FAILURE;
	}
	
	ShowWindow(Handle, SW_MAXIMIZE);

	return EXIT_SUCCESS;
}
