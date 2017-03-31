List<string> lines = new List<string>();

          try
          {
              using (StreamReader r = new StreamReader("")) //filename
              {
                  string line;
                  while ((line = r.ReadLine()) != null)
                  {
                      if(line != "")
                      {
                          lines.Add(line);
                      }

                  }
              }

              foreach (string line in lines)
              {
                  ConnectionsList.Items.Add(line);
              }
          }
          catch
          {}
