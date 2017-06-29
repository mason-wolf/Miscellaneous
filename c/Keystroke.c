#include <windows.h>

// simulate key press 

int main()
{
    INPUT key;
    key.type = INPUT_KEYBOARD;
    key.ki.wScan = 0; 
    key.ki.time = 0;
    key.ki.dwExtraInfo = 0;
    // https://msdn.microsoft.com/en-us/library/windows/desktop/dd375731(v=vs.85).aspx
    // see virtual key codes, 0x0D is ENTER key
    
    key.ki.wVk = 0x0D;
    key.ki.dwFlags = 0; 
    SendInput(1, &key, sizeof(INPUT));

    key.ki.dwFlags = KEYEVENTF_KEYUP; 
    SendInput(1, &key, sizeof(INPUT));

    return 0;
}
