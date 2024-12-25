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

        foreach (var line in File.ReadLines("input.txt")) {
            var parts = line.Split(' ');

            if (parts[0] == "rect") {
                var dims = parts[1].Split('x').Select(int.Parse).ToArray();
                var x = dims[1];
                var y = dims[0];
                for (var i = 0; i < x && i < 6; i++) {
                    for (var j = 0; j < y && j < 50; j++) {
                        screen[i, j] = true;
                    }
                }
            }
            else if (parts[0] == "rotate") {
                var target = parts[2].Split('=');
                var axis = target[0];
                var index = int.Parse(target[1]);
                var amount = int.Parse(parts[4]);

                if (axis == "y") {
                    var newRow = new bool[50];
                    for (var i = 0; i < 50; i++) {
                        newRow[(i + amount) % 50] = screen[index, i];
                    }
                    for (var i = 0; i < 50; i++) {
                        screen[index, i] = newRow[i];
                    }
                }
                else if (axis == "x") {
                    var newColumn = new bool[6];
                    for (var i = 0; i < 6; i++) {
                        newColumn[(i + amount) % 6] = screen[i, index];
                    }
                    for (var i = 0; i < 6; i++) {
                        screen[i, index] = newColumn[i];
                    }
                }
            }
        }
        
        var count = 0;
        for (var i = 0; i < 6; i++) {
            for (var j = 0; j < 50; j++) {
                if (screen[i, j]) {
                    count++;
                }
            }
        }
        Console.WriteLine(count);
        
        return screen;
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
