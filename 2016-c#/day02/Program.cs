class Program
{
    static void Main(string[] args)
    {
        Problem1();
        Problem2();
    }

    static void Problem1()
    {
        var keypad = new Dictionary<(int, int), char> {
            {(0, 0), '1'}, {(1, 0), '2'}, {(2, 0), '3'},
            {(0, 1), '4'}, {(1, 1), '5'}, {(2, 1), '6'},
            {(0, 2), '7'}, {(1, 2), '8'}, {(2, 2), '9'},
        };
    
        var instructions = File.ReadAllLines("input.txt");
        
        var current = (x: 1, y: 1);

        foreach (var instruction in instructions) {
            foreach (var step in instruction) {
                var next = step switch {
                    'U' => (current.x, current.y - 1),
                    'D' => (current.x, current.y + 1),
                    'L' => (current.x - 1, current.y),
                    'R' => (current.x + 1, current.y),
                    _ => current
                };
                
                current = keypad.ContainsKey(next) ? next : current;
            }
            Console.Write(keypad[current]);
        }
        Console.WriteLine();
    }
    
    static void Problem2()
    {
        var keypad = new Dictionary<(int, int), char?> {
            {(2, 0), '1'},
            {(1, 1), '2'}, {(2, 1), '3'}, {(3, 1), '4'},
            {(0, 2), '5'}, {(1, 2), '6'}, {(2, 2), '7'}, {(3, 2), '8'}, {(4, 2), '9'},
            {(1, 3), 'A'}, {(2, 3), 'B'}, {(3, 3), 'C'},
            {(2, 4), 'D'},
        };
    
        var instructions = File.ReadAllLines("input.txt");
        
        var current = (x: 0, y: 2);

        foreach (var instruction in instructions) {
            foreach (var step in instruction) {
                var next = step switch {
                    'U' => (current.x, current.y - 1),
                    'D' => (current.x, current.y + 1),
                    'L' => (current.x - 1, current.y),
                    'R' => (current.x + 1, current.y),
                    _ => current
                };
                
                current = keypad.ContainsKey(next) ? next : current;
            }
            Console.Write(keypad[current]);
        }
        Console.WriteLine();
    }
}
