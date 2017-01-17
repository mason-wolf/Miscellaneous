#include <stdio.h>

void main() {
  FILE *file;
  file = fopen("", "w+");
  fprintf(file, "%s\n");
  fputs("test", file);
  fclose(file);
}
