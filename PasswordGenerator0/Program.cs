namespace PasswordGenerator0
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            int length = PasswordLength();
            bool includeLowercase = Option("lowercase");
            bool includeUppercase = Option("uppercase");
            bool includeNumbers = Option("numbers");
            bool includeSymbols = Option("symbols");

            string password = GeneratePassword(length, includeLowercase, includeUppercase, includeNumbers, includeSymbols);
            Console.WriteLine("Your Password: " + password);
        }

        static int PasswordLength()
        {
            Console.Write("Enter password length: ");
            int length;
            while (!int.TryParse(Console.ReadLine(), out length) || length < 1)
            {
                Console.WriteLine("Invalid input. Please enter a positive integer.");
            }
            return length;
        }

        static bool Option(string option)
        {
            Console.Write($"Include {option} characters(y/n): ");
            string input = Console.ReadLine().ToLower();
            return input == "y";
        }

        static string GeneratePassword(int length, bool Lowercase, bool Uppercase, bool Numbers, bool Symbols)
        {
            string chars = "";
            if (Lowercase) chars += "abcdefghijklmnopqrstuvwxyz";
            if (Uppercase) chars += "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            if (Numbers) chars += "0123456789";
            if (Symbols) chars += "!@#$%^&*()+-/.?";

            if (chars.Length == 0)
                return "no character selected";

            Random random = new Random();
            char[] password = new char[length];
            for (int i = 0; i < length; i++)
            {
                password[i] = chars[random.Next(chars.Length)];
            }
            return new string(password);
        }
    }
}
