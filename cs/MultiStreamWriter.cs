var streamWriters = new List<StreamWriter>();
streamWriters.Add(new StreamWriter("file_1.txt"));
streamWriters.Add(new StreamWriter("file_2.txt"));

Parallel.ForEach(streamWriters, s => { s.Write("some text"); s.Dispose(); });
