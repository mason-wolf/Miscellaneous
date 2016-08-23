#include <stdio.h>
#include <stdlib.h>
#include <string.h>

char * fchar() {
  FILE *fp;
  long lSize;
  char *buffer;

  fp = fopen ( "mail.txt" , "r" );

  fseek( fp , 0L , SEEK_END);
  lSize = ftell( fp );
  rewind( fp );

  buffer = calloc( 1, lSize+1 );

  if( 1!=fread( buffer , lSize, 1 , fp) );

  return (buffer);

  fclose(fp);
  free(buffer);
}

int main() {
  printf("%s\n", fchar());
}
