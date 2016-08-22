char linebuffer[BUFSIZ];
FILE * fp = fopen(".txt", "r");
  while(fgets(linebuffer, sizeof(linebuffer), fp)) {
   printf("%s", linebuffer);
}
