using System.Security.Cryptography;
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
        var index = 0;
        var password = "";
        var input = "ffykfhsq";

        while (password.Length < 8) {
            var hash = GetHash($"{input}{index}");
            if (hash.StartsWith("00000")) {
                password += hash[5];
            }
            index++;
        }
        Console.WriteLine(password);
    }
    
    static void Problem2()
    {
        var index = 0;
        var password = new char[8];
        var input = "ffykfhsq";
        // var test = "abc";

        while (password.Any(c => c == '\0')) {
            var hash = GetHash($"{input}{index}");
            if (hash.StartsWith("00000")) {
                var position = hash[5] - '0';
                var character = hash[6];
                if (position >= 0 && position < 8 && password[position] == '\0') {
                    password[position] = character;
                }
            }
            index++;
        }
        Console.WriteLine(new string(password));
    }
    
    static string GetHash(string input)
    {
        using (var md5 = MD5.Create())
        {
            var inputBytes = Encoding.ASCII.GetBytes(input);
            var hashBytes = md5.ComputeHash(inputBytes);
            return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
        }
    }
}
