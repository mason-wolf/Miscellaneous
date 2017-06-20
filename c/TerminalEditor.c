#include <stdio.h>
#include <string.h>

void main() {

    FILE *file;
    
    // declare two-dimensional array, or table that has x rows and y columns
    // where x = 100 and y = 100

    char fileLength[100][100], fileBuffer;

    file = fopen("test.txt", "a");
    
    int row = 0, column;

    do {    
        // scanf - read formatted input from stdin
        scanf("%s", fileLength[row]);

        // strcmp - string compare, seek if stdin contains ./save 
        if ((strcmp(fileLength[row], "./save")) == 0) {
            // fseek - sets the file position of the stream to the given offset
            fseek(file, 0L, 0);
            row--;
            for (column = 0; column <= row; column++) {
                // fprintf - sends the formatted output to a stream 
                // recursively adding each row and column 
                fprintf(file, "%s", fileLength[column]);
                putc(' ', file);
            }
        }
    }

    while (strcmp(fileLength[row++], "./exit") != 0);

    fclose(file);

}
