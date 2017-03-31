using (var sr = new StreamReader(filePath))
                    {
                        using (var sw = new StreamWriter(tempFile))
                        {
                            string line;
                            while ((line = sr.ReadLine()) != null)
                            {
                                if (line != item)
                                {
                                    sw.WriteLine(line);
                                }
                            }
                        }
                    }
