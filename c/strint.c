#include <stdio.h>

int main() {
// coverting string to integer
printf("%d", atoi("string"));
}

// converts string of digits into its numeric equivalent
int atoi(char s[]) {
  int i, n;
  n = 0;
  for(i = 0; s[i] >= '0' && s[i] <= '9'; i++) {
    n = 10 * n + (s[i] - '0');
    return n;
  }
}
