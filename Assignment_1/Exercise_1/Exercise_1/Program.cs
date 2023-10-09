using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Converting userInput to Integer using different method
            Console.WriteLine("      String to Integer      ");
            Console.Write("Enter a number: ");
            string userInt = Console.ReadLine();

            // Method 1. using int.Parse
            Console.WriteLine("The integer value of your input using int.Parse method is: " + int.Parse(userInt));

            // Method 2. using Convert.ToInt
            Console.WriteLine("The integer value of your input using Convert.ToInt method is: " + Convert.ToInt32(userInt));

            // Method 3. using int.TryParse
            bool isInt = int.TryParse(userInt, out int toInt);
            if (isInt)
            {
                Console.WriteLine("The integer value of your input using int.TryParse method is: " + toInt);
            }
            else
            {
                Console.WriteLine("Invalid input - unable to parse string");
            }

            Console.WriteLine();

            // Converting userInput to Float using different method
            Console.WriteLine("      String to Float      ");
            Console.Write("Enter a decimal number: ");
            string userFloat = Console.ReadLine();

            // Method 1. using float.Parse
            Console.WriteLine("The float value of your input using float.Parse method is: " + float.Parse(userFloat));

            // Method 2. using Convert.ToSingle since no Convert.ToFloat method available
            Console.WriteLine("The float value of your input using Convert.ToSingle method is: " + Convert.ToSingle(userFloat));

            // Method 3. using float.TryParse
            bool isFloat = float.TryParse(userFloat, out float toFloat);
            if (isFloat)
            {
                Console.WriteLine("The float value of your input using float.TryParse method is: " + toFloat);
            }
            else
            {
                Console.WriteLine("Invalid input - unable to parse string");
            }

            Console.WriteLine();

            // Converting userInput to Boolean using different method
            Console.WriteLine("      String to Boolean      ");
            Console.Write("Enter a boolean value: ");
            string userBool = Console.ReadLine();

            // Method 1. using bool.Parse
            Console.WriteLine("The boolean value of your input using bool.Parse method is: " + bool.Parse(userBool));

            // Method 2. using Convert.ToBoolean
            Console.WriteLine("The boolean value of your input using Convert.ToBool method is: " + Convert.ToBoolean(userBool));

            // Method 3. using int.TryParse
            bool isbool = bool.TryParse(userBool, out bool toBool);
            if (isbool)
            {
                Console.WriteLine("The integer value of your input using int.TryParse method is: " + toBool);
            }
            else
            {
                Console.WriteLine("Invalid input - unable to parse string");
            }
            Console.ReadLine();
        }
    }
}
