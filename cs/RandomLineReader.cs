    static string RandomLine(string fileName) {
        Random random = new Random();
        var line = File.ReadAllLines(fileName);
        var response = random.Next(0, line.Length);
        return line[response];
    }
