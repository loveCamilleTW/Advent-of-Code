using System.Text;

class Program
{
    static void Main(string[] args)
    {
        Problem1();
        Problem2();
    }

    static void Problem1()
    {
        var lines = File.ReadAllLines("input.txt");
        var message = "";

        for (var i = 0; i < lines[0].Length; i++) {
            var frequency = lines.Select(line => line[i])
                .GroupBy(c => c)
                .OrderByDescending(g => g.Count())
                .First()
                .Key;
            message += frequency;
        }
        Console.WriteLine(message);
    }
    
    static void Problem2()
    {
        var lines = File.ReadAllLines("input.txt");
        var message = "";

        for (var i = 0; i < lines[0].Length; i++) {
            var frequency = lines.Select(line => line[i])
                .GroupBy(c => c)
                .OrderBy(g => g.Count())
                .First()
                .Key;
            message += frequency;
        }
        Console.WriteLine(message);
    }
}
