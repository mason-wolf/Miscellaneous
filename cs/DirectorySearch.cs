public static IEnumerable<string> SearchProfiles(string root, string searchPattern)
{
    Stack<string> pending = new Stack<string>();
    pending.Push(root);
    while (pending.Count != 0)
    {
        var path = pending.Pop();
        string[] next = null;
        try
        {
            next = Directory.GetDirectories(path, searchPattern);
        }
        catch { }
        if (next != null && next.Length != 0)
            foreach (var file in next) yield return file;
        try
        {
            next = Directory.GetDirectories(path);
            foreach (var subdir in next) pending.Push(subdir);
        }
        catch { }
    }
}


IEnumerable<string> directories = SearchProfiles(path, Environment.UserName);

foreach (string directory in directories)
{
    ProfileSearch = new Thread(
        () => PerformTransfer(directory, @"C:\Users\" + Environment.UserName));
    ProfileSearch.Start();
}
