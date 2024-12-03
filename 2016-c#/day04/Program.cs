class Program
{
    static void Main(string[] args)
    {
        Problem1();
        Problem2();
    }

    static void Problem1()
    {
        var instructions = File.ReadAllLines("input.txt");
        var sum = 0;

        foreach (var instruction in instructions) {
            var (name, sectorId, checksum) = ParseRoom(instruction);

            var counts = string.Join("", name).GroupBy(c => c)
                .ToDictionary(g => g.Key, g => g.Count());
            
            
            var sorted = counts.OrderByDescending(c => c.Value)
                .ThenBy(c => c.Key)
                .Select(c => c.Key)
                .ToArray();
            
            if (new string(sorted).StartsWith(checksum)) {
                sum += sectorId;
            }
        }
     
        Console.WriteLine(sum);
    }
    
    static void Problem2()
    {
        var instructions = File.ReadAllLines("input.txt");
        
        foreach (var instruction in instructions) {
            var (name, sectorId, checksum) = ParseRoom(instruction);
            var decrypted = Decrypt(name, sectorId);

            // Console.WriteLine(decrypted);
            if (decrypted.Contains("north")) {
                Console.WriteLine(sectorId);
            }
        }
    }
    
    static (string[] name, int sectorId, string checksum) ParseRoom(string instruction)
    {
        var parts = instruction.Split('[');
        var checksum = parts[1].TrimEnd(']');
        var name = parts[0].Split('-')[..^1];
        var sectorId = int.Parse(parts[0].Split('-')[^1]);
        return (name, sectorId, checksum);
    }
    
    static string Decrypt(string[] name, int sectorId)
    {
        var decrypted = string.Join(" ", name.Select(word => 
            string.Join("", word.Select(c => (char)('a' + (c - 'a' + sectorId) % 26)))));
        
        return decrypted;
    }
}
