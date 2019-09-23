using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson03
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please select the program you want to execute:");

            while (true)
            {
                Console.WriteLine("");
                Console.WriteLine("Press '1' if you want to run program 'Numbers' - to get information about entered number");
                Console.WriteLine("Press '2' if you want to run program 'Random' - to guess the number");
                Console.WriteLine("Press '3' to close the application");

                var selection = Console.ReadLine();

                switch (selection)
                {
                    case "1":
                        Numbers();
                        break;
                    case "2":
                        Random();
                        break;
                    case "3":
                        Environment.Exit(-1);
                        break;
                    default:
                        Console.WriteLine("Please make your choice");
                        break;
                }

            }
        }

        public static void Numbers()
        {
            var digit = string.Empty;
            var value = 0;

            do
            {
                Console.WriteLine("Please enter some integer digit:");
                digit = Console.ReadLine().Replace("-", "");
            } while (!int.TryParse(digit, out value));

            int b = 0;
            int c = 0;
            var number = 0;

            foreach (var t in digit)
            {
                number = (int)Char.GetNumericValue(t);

                if (number % 2 == 0) b = b + number;
                if (number % 3 == 0) c++;
            }

            Console.WriteLine($"Count of digits in a number is: {digit.Length}");
            Console.WriteLine($"Sum of even numbers is: {b}");
            Console.WriteLine($"Count of digits which is multiple of 3 is: {c}");

            Console.ReadKey();
        }

        public static void Random()
        {
            Console.WriteLine("Value is generated automatically");
            var random = new Random();
            var value = random.Next(0, 101);
            Console.WriteLine(value);
            Console.WriteLine("You can try to guess number which was generated automatically");
            Console.WriteLine("The range is between 0 and 100 and the value should be integer");
            Console.WriteLine("You have 5 attempts");
            var attempt = 1;
            var yourValue = "0";
            var result = "You LOSE";

            do
            {
                Console.WriteLine($"It's your {attempt} attempt");
                Console.WriteLine($"Please enter a number:");

                yourValue = Console.ReadLine();

                var isNumeric = int.TryParse(yourValue, out int number);

                if (number > 100 || number < 0 || !isNumeric)
                    Console.WriteLine("You have entered value which is out of range OR the value isn't a integer number");
                else if (number > value)
                    Console.WriteLine("Entered number is bigger than generated value");
                else if (number < value)
                    Console.WriteLine("Entered number is less than generated value");

                if (yourValue == value.ToString())
                {
                    result = "You WIN";
                    break;
                }

                attempt++;
            } while (attempt <= 5);

            Console.WriteLine(result);
            Console.ReadKey();
        }
    }
}
