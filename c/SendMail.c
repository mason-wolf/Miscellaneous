#include <stdio.h>
#include <string.h>
#include <curl/curl.h>


int main(void)
{
  CURL *curl;
  CURLcode res = CURLE_OK;

  struct curl_slist *recipients = NULL;
  char usr[255];
  char pswd[255];
  char send_to[255];
  printf("\nHowlSMTP - enter message when server acknowledges 'Go ahead'.\n");
  printf("Press Ctrl-D when finished typing message.\n");
  printf("\nUsername: ");
  scanf("%s", usr);

  printf("Password: ");
  scanf("%s", pswd);

  printf("To: ");
  scanf("%s", send_to);
  curl = curl_easy_init();

  if(curl) {

    curl_easy_setopt(curl, CURLOPT_USERNAME, usr);
    curl_easy_setopt(curl, CURLOPT_PASSWORD, pswd);
    curl_easy_setopt(curl, CURLOPT_URL, "smtp.gmail.com:587");
    curl_easy_setopt(curl, CURLOPT_USE_SSL, (long)CURLUSESSL_ALL);
    curl_easy_setopt(curl, CURLOPT_MAIL_FROM, usr);
    recipients = curl_slist_append(recipients, send_to);
    curl_easy_setopt(curl, CURLOPT_MAIL_RCPT, recipients);
    curl_easy_setopt(curl, CURLOPT_READDATA, stdin);
    curl_easy_setopt(curl, CURLOPT_UPLOAD, 1L);
    curl_easy_setopt(curl, CURLOPT_VERBOSE, 1L);

    /* Send the message */
    res = curl_easy_perform(curl);

    /* Check for errors */
    if(res != CURLE_OK)
      fprintf(stderr, "curl_easy_perform() failed: %s\n",
              curl_easy_strerror(res));

    /* Free the list of recipients */
    curl_slist_free_all(recipients);

    /* Always cleanup */
    curl_easy_cleanup(curl);
  }

  return (int)res;
}
