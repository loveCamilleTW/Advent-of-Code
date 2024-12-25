using System.Text;

class Program
{
    static void Main(string[] args)
    {
        // Problem1();
        Problem2();
    }

    static void Problem1()
    {
        var count = File.ReadLines("input.txt")
            .Count(line => {
                var parts = line.Split('[', ']');
                var outsides = parts.Where((_, i) => i % 2 == 0);
                var insides = parts.Where((_, i) => i % 2 == 1);
                
                return outsides.Any(HasABBA) && !insides.Any(HasABBA);
            });

        Console.WriteLine(count);
    }
    
    static void Problem2()
    {
        var count = File.ReadLines("input.txt")
            .Count(line => {
                var parts = line.Split('[', ']');
                var outsides = parts.Where((_, i) => i % 2 == 0);
                var insides = parts.Where((_, i) => i % 2 == 1);
                
                var abas = outsides.SelectMany(GetABAs).ToList();
                var babs = insides.SelectMany(GetBABs).ToList();

                return abas.Any(aba => babs.Contains(aba));
            });

        Console.WriteLine(count);
    }
    
    static bool HasABBA(string s)
    {
        for (var i = 0; i < s.Length - 3; i++) {
            if (s[i] == s[i + 3] && s[i + 1] == s[i + 2] && s[i] != s[i + 1]) {
                return true;
            }
        }
        return false;
    }
    
    static List<string> GetABAs(string s)
    {
        var abas = new List<string>();
        for (var i = 0; i < s.Length - 2; i++) {
            if (s[i] == s[i + 2] && s[i] != s[i + 1]) {
                abas.Add($"{s[i]}{s[i + 1]}{s[i]}");
            }
        }
        return abas;
    }
    
    static List<string> GetBABs(string s)
    {
        var babs = new List<string>();
        for (var i = 0; i < s.Length - 2; i++) {
            if (s[i] == s[i + 2] && s[i] != s[i + 1]) {
                babs.Add($"{s[i + 1]}{s[i]}{s[i + 1]}");
            }
        }
        return babs;
    }
}
