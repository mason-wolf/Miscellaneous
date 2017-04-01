char user_input[80];

void get_string(void) {

   int position;

   for(position = 0; position <= 78; position++) {
      user_input[position] = getchar();
      if(user_input[position]==10)break; // CR
      if(user_input[position]==13)break; // LF
   }
   user_input[position] = 0;

}