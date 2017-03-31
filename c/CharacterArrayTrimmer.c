#include <stdio.h>

#define TRUE  1
#define FALSE 0

char s1[] = "abc";
char s2[] = "c";

// removes characters from char array

void squeeze(char s1[], char s2[])
{
    int i, j, k;
    int strfound;

    for (i = j = 0; s1[i] != '\0'; i++) {
        strfound = FALSE;
        for (k = 0; s2[k] != '\0' && !strfound; k++)
            if (s2[k] == s1[i])
                strfound = TRUE;
        if (!strfound)
            s1[j++] = s1[i];
    }
    s1[j] = '\0';
}

int main() {
squeeze(s1, s2);
printf("%s", s1);
}
