void normalize(void) {

   int from = 0;
   int to = 0;
   char buffer[80];

   // Skip past leading whitespaces
   while(user_input[from] == ' ') from++;

   while(1) {

      // If lower case
      if(user_input[from] >= 'a' && user_input[from] <= 'z') {
         buffer[to++] = user_input[from++];
         continue;
      }

      // If upper case
      if(user_input[from] >= 'A' && user_input[from] <= 'Z') {
         buffer[to++] = user_input[from++] + 32;
         continue;
      }

      // If number
      if(user_input[from] >= '0' && user_input[from] <= '9') {
         buffer[to++] = user_input[from++];
         continue;
      }


      // If multiple whitespaces
      //   if(user_input[from] == ' ' && user_input[from-1] == ' ' && from > 0) {
      if(user_input[from] == ' ' && buffer[to - 1] == ' ' && to > 0) {
         from++;
         continue;
      }
      // If normal whitespace
      if(user_input[from] == ' ') {
         buffer[to++] = user_input[from++];
         continue;
      }

      // If null
      if(user_input[from] == 0) {
         buffer[to++] = user_input[from++];
         strcpy(user_input, buffer);
         //puts(buffer); // DEBUG
         return;
      }

      from++;
   }
}