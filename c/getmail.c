#include <stdio.h>
#include <string.h>
#include <curl/curl.h>
#include <stdlib.h>

//  getmail.c   -- retrieves summary from gmail inbox atom feed
//  written by Mason Wolf, 2016   masonhwolf@gmail.com

// function to handle curl buffer
size_t write_data(void *ptr, size_t size, size_t nmemb, FILE *stream) {
    size_t written = fwrite(ptr, size, nmemb, stream);
    return written;
}

// extracts text in between tags

char * extract_tag(char * tag1, char * tag2, int space) {
  FILE * fp = fopen("feed.txt", "r");
  char linebuffer[BUFSIZ];
  while(fgets(linebuffer, sizeof(linebuffer), fp)) {
  const char * tagstart = strstr(linebuffer, tag1) + space;
  const char * tagend = strstr(tagstart, tag2);

  size_t result_length = tagend - tagstart;
  char * result = (char *)malloc(sizeof(char) * (result_length + space));
  strncpy(result, tagstart, result_length);
  result[result_length] = '\0';
  return(result);
  }
  fclose(fp);
}

// checks if file contains a string
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
        numresult++;
      }
    }

    if(numresult == 0) {
      return (0);
    }
    else {
      return(1);
    }

    if(fp) {
      fclose(fp);
    }
}

int main(void) {

    CURL *curl;
    FILE *fp;
    CURLcode res;

    char *url = "https://mail.google.com/mail/feed/atom";
    char outfilename[FILENAME_MAX] = "feed.txt";
    curl = curl_easy_init();
    int fexists;

    if (curl) {
        fp = fopen(outfilename,"wb");
        // https://curl.haxx.se/libcurl/c/curl_easy_setopt.html
        // enter credentials in USERPWD section
        curl_easy_setopt(curl, CURLOPT_USERPWD, "");
        curl_easy_setopt(curl, CURLOPT_URL, url);
        curl_easy_setopt(curl, CURLOPT_WRITEFUNCTION, write_data);
        curl_easy_setopt(curl, CURLOPT_WRITEDATA, fp);
        res = curl_easy_perform(curl);
        curl_easy_cleanup(curl);
        fclose(fp);
    }
        // if request was rejected google with throw 401 page
        // fexists returns 0 if unauthorized page was not reached
      fexists = fcontains("feed.txt", "401");
      if(fexists == 0) {
            char * msgcount;
            // <fullcount> is xml atom tag containing number of new emails
            char * msg = extract_tag("<fullcount>", "</fullcount>", 11);
            msgcount = strchr(msg, '0');
            if(msgcount != NULL) {
              printf("\nNo new messages.\n\n");
            }
            else {
              // retrieve sender and email contents
              char * sender = extract_tag("\n<name>", "</name>\n", 6);
              char * msg = extract_tag("\n<summary>", "</summary>\n\n", 11);
              printf("%s\n", sender);
              printf("%s\n", msg);
            }
          }
          // cleanup, https://www.gnu.org/software/libc/manual/html_node/Deleting-Files.html
          remove("feed.txt");
      }
