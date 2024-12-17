class Program
{
    enum Direction
    {
        North,
        East,
        South,
        West
    }

    static void Main(string[] args)
    {
        Problem1();
        Problem2();
    }

    static void Problem1()
    {
        var position = (x: 0, y: 0);
        var direction = Direction.North;
        
        var input = File.ReadAllText("input.txt");
        var instructions = input.Split(", ");

        foreach (var instruction in instructions) {
            var turn = instruction[0];
            var step = int.Parse(instruction.Substring(1));
            
            direction = turn == 'L' ? (Direction)(((int)direction + 3) % 4) : (Direction)(((int)direction + 1) % 4);
            
            switch (direction) {
                case Direction.North: position.y += step; break;
                case Direction.East: position.x += step; break;
                case Direction.South: position.y -= step; break;
                case Direction.West: position.x -= step; break;
            }
            // Console.WriteLine($"position: {position}");
        }
        
        Console.WriteLine($"Final position: {position}");
        Console.WriteLine($"Answer: {Math.Abs(position.x) + Math.Abs(position.y)}");
    }
    
    static void Problem2()
    {
        var position = (x: 0, y: 0);
        var direction = Direction.North;
        
        var input = File.ReadAllText("input.txt");
        var instructions = input.Split(", ");

        var visited = new HashSet<(int, int)>();
        var firstVisited = (x: 0, y: 0);
        visited.Add(firstVisited);
        
        var found = false;
        foreach (var instruction in instructions) {
            var turn = instruction[0];
            var step = int.Parse(instruction.Substring(1));
            
            direction = turn == 'L' ? (Direction)(((int)direction + 3) % 4) : (Direction)(((int)direction + 1) % 4);
            
            switch (direction) {
                case Direction.North: {
                    for (var i = 0; i < step; i++) {
                        position.y++;
                        if (visited.Contains(position)) {
                            found = true;
                            break;
                        }
                        visited.Add(position);
                    }
                    break;
                }
                case Direction.East: {
                    for (var i = 0; i < step; i++) {
                        position.x++;
                        if (visited.Contains(position)) {
                            found = true;
                            break;
                        }
                        visited.Add(position);
                    }
                    break;
                }
                case Direction.South: {
                    for (var i = 0; i < step; i++) {
                        position.y--;
                        if (visited.Contains(position)) {
                            found = true;
                            break;
                        }
                        visited.Add(position);
                    }
                    break;
                }
                case Direction.West: {
                    for (var i = 0; i < step; i++) {
                        position.x--;
                        if (visited.Contains(position)) {
                            found = true;
                            break;
                        }
                        visited.Add(position);
                    }
                    break;
                }
            }
            if (found) break;
        }
        
        Console.WriteLine($"Answer: {Math.Abs(position.x) + Math.Abs(position.y)}");
    }
}
