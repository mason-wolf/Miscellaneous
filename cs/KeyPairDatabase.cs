
        string user_input = Console.ReadLine();
        string search_item;
        string result;
        string response;
        
        StreamReader database = new StreamReader("database.txt");
        
            while ((search_item = database.ReadLine()) != null) {
                result = search_item.RetrievePrefix();
                if (result == user_input) {
                    response = search_item.Substring(search_item.LastIndexOf(":"));
                }
            }
            
            
 static class KeyPair {
  public static string RetrievePrefix(this string text, string stopAt = ":")
    {
        if (!String.IsNullOrWhiteSpace(text))
        {
            int charLocation = text.IndexOf(stopAt, StringComparison.Ordinal);

            if (charLocation > 0)
            {
                return text.Substring(0, charLocation);
            }
        }

        return String.Empty;
    }
}
