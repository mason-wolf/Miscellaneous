#include <stdio.h>
#include <string.h>
#include <stdlib.h>

int main() {

  // string that text will be extracted from
  char base_string[] = "<summary>entry</summary>";

  // using strstr for ocating substring
  // const char * strstr (string to be scanned, string containing characters to match)
  const char * first = strstr(base_string, "<summary>") + 9;
  const char * last = strstr(first, "</summary>");

  // size_t represents size of objects
  // http://www.gnu.org/software/libc/manual/html_node/Important-Data-Types.html
  size_t length = last - first;

  // malloc is used to allocate a block of memory
  // http://www.gnu.org/software/libc/manual/html_node/Basic-Allocation.html#Basic-Allocation
  char * result = (char *)malloc(sizeof(char) * (length + 1));

  // strncpy copies characters from a source to a destination
  // char * strncpy (destination, source, size)
  strncpy(result, first, length);

  // '\0' acts as string termination, signals end of string processing
  result[length] = '\0';
  printf("%s\n", result);
}
