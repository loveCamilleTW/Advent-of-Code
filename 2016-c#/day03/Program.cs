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
        var valid = 0;

        foreach (var instruction in instructions) {
            var sides = instruction.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Array.Sort(sides);
            if (sides[0] + sides[1] > sides[2]) {
                valid++;
            }
        }
        Console.WriteLine(valid);
    }
    
    static void Problem2()
    {
        var instructions = File.ReadAllLines("input.txt");
        var valid = 0;
        
        for (var i = 0; i < instructions.Length; i += 3) {
            var sides = new[] {
                instructions[i].Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray(),
                instructions[i + 1].Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray(),
                instructions[i + 2].Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray(),
            };
            
            for (var j = 0; j < 3; j++) {
                var temp = new[] { sides[0][j], sides[1][j], sides[2][j] };
                Array.Sort(temp);
                if (temp[0] + temp[1] > temp[2]) {
                    valid++;
                }
            }
        }
        Console.WriteLine(valid);
    }
}
