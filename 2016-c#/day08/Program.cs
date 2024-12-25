using System.Text;

class Program
{
    static void Main(string[] args)
    {
        var screen = Problem1();
        Problem2(screen);
    }

    static bool[,] Problem1()
    {
        var screen = new bool[6,50];
        
        foreach (var line in File.ReadLines("input.txt"))
        {
            var command = ParseCommand(line);
            ExecuteCommand(screen, command);
        }
        
        Console.WriteLine(CountLitPixels(screen));
        return screen;
    }

    record Command(string Type, int[] Dimensions, string? Axis = null, int? Index = null, int? Amount = null);

    static Command ParseCommand(string line)
    {
        var parts = line.Split(' ');
        return parts[0] switch
        {
            "rect" => new Command(
                "rect", 
                parts[1].Split('x').Select(int.Parse).ToArray()
            ),
            "rotate" => new Command(
                "rotate",
                Array.Empty<int>(),
                parts[2].Split('=')[0],
                int.Parse(parts[2].Split('=')[1]),
                int.Parse(parts[4])
            ),
            _ => throw new ArgumentException($"Unknown command: {parts[0]}")
        };
    }

    static void ExecuteCommand(bool[,] screen, Command cmd)
    {
        switch (cmd.Type)
        {
            case "rect":
                DrawRectangle(screen, cmd.Dimensions[1], cmd.Dimensions[0]);
                break;
            case "rotate":
                Rotate(screen, cmd.Axis!, cmd.Index!.Value, cmd.Amount!.Value);
                break;
        }
    }

    static void DrawRectangle(bool[,] screen, int x, int y)
    {
        for (var i = 0; i < x && i < 6; i++)
            for (var j = 0; j < y && j < 50; j++)
                screen[i, j] = true;
    }

    static void Rotate(bool[,] screen, string axis, int index, int amount)
    {
        if (axis == "y")
            RotateRow(screen, index, amount);
        else
            RotateColumn(screen, index, amount);
    }

    static void RotateRow(bool[,] screen, int row, int amount)
    {
        var newRow = new bool[50];
        for (var i = 0; i < 50; i++)
            newRow[(i + amount) % 50] = screen[row, i];
        for (var i = 0; i < 50; i++)
            screen[row, i] = newRow[i];
    }

    static void RotateColumn(bool[,] screen, int col, int amount)
    {
        var newColumn = new bool[6];
        for (var i = 0; i < 6; i++)
            newColumn[(i + amount) % 6] = screen[i, col];
        for (var i = 0; i < 6; i++)
            screen[i, col] = newColumn[i];
    }

    static int CountLitPixels(bool[,] screen)
    {
        var count = 0;
        for (var i = 0; i < 6; i++)
            for (var j = 0; j < 50; j++)
                if (screen[i, j]) count++;
        return count;
    }
    
    static void Problem2(bool[,] screen)
    {
        for (var i = 0; i < 6; i++) {
            for (var j = 0; j < 50; j++) {
                Console.Write(screen[i, j] ? '#' : '.');
            }
            Console.WriteLine();
        }
    }
}
