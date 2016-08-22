int fcontains(char *fname, char *str) {
    FILE *fp;
    int ln = 1;
    int numresult = 0;
    char temp[512];

    if((fp = fopen(fname, "r")) == NULL) {
      return(-1);
    }

    while(fgets(temp, 512, fp) != NULL) {
      if((strstr(temp, str)) != NULL) {
        printf("match found.");
        numresult++;
      }
    }

    if(numresult == 0) {
      printf("no matches.");
    }

    if(fp) {
      fclose(fp);
    }
    return(0);
}
