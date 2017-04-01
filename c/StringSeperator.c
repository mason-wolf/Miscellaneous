void parse(void) {

   // input: user_input
   // output: words, number_of_words

   int position = 0;
   int letter_position;
   int word_position;
   //while(1);
   for(word_position=1; word_position < MAX_WORDS; word_position++) {
      for(letter_position = 0; letter_position < MAX_LETTERS; letter_position++) {

         // End of user input?
         if(user_input[position]==0 || position >= 80) {
            words[word_position][letter_position] = 0;
            number_of_words = word_position;
            return;
         }

         //end of word?
         if(user_input[position]==' ') {
            words[word_position][letter_position] = 0;  // terminate the word
            letter_position = 0;  // probably not needed
            position++;  // skip over the space
            break;
         }

         //
         words[word_position][letter_position] = user_input[position];
         position++;
      }
   }

}