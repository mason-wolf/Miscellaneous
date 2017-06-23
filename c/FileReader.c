#include <stdio.h>
#include <stdlib.h>
#include <string.h>

void main(int argc, char *argv[]) {

    if (argc != 2) {
        printf("No filename specified.");
    }
    else {
    FILE *file;
    long fileSize;
    char *buffer;

    file = fopen(argv[1], "r");
    fseek(file, 0L, SEEK_END);
    fileSize = ftell(file);
    rewind(file);
    buffer = calloc(1, fileSize + 1);

    if (1 != fread(buffer, fileSize, 1, file)) {
        printf(buffer);
    }

    fclose(file);
    free(buffer);
    }
}
