using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_17
{
    class CustomException : Exception
    {
        public CustomException(string message) : base(message) { Console.WriteLine("Try Again"); }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int timesPlayed = 0;

            while (timesPlayed < 5)
            {
                Console.Write("Enter any number from 1 - 5: ");
                string input = Console.ReadLine();
                int.TryParse(input, out int userInput);
                try
                {
                    if (userInput < 1 || userInput > 5) throw new CustomException("Invalid input! Enter a number from 1 - 5");
                }
                catch (CustomException ex)
                {
                    Console.WriteLine(ex.Message);
                    continue;
                }
                Console.WriteLine();
                switch (userInput)
                {
                    case 1: 
                        Console.Write("Enter even number: ");
                        break;
                    case 2:
                        Console.Write("Enter odd number: ");
                        break;
                    case 3:
                        Console.Write("Enter prime number: ");
                        break;
                    case 4:
                        Console.Write("Enter a negative number: ");
                        break;
                    case 5:
                        Console.Write("Enter zero: ");
                        break;
                    default:
                        Console.Write("Invalid input! Enter a number from 1 - 5");
                        continue;
                }
                input = Console.ReadLine();
                int.TryParse(input, out int number);

                try
                {
                    switch (userInput)
                    {
                        case 1:
                            if (number % 2 == 0) Console.WriteLine("Success");
                            else throw new CustomException("Error! Enter an even number\n");
                            break;
                        case 2:
                            if (number % 2 != 0) Console.WriteLine("Success");
                            else throw new CustomException("Error! Enter an even number\n");
                            break;
                        case 3:
                            bool isPrime = true;
                            if (number < 2) isPrime = false;
                            for (int i = 2; i < Math.Sqrt(number); i++)
                            {
                                if (number % i == 0)
                                {
                                    isPrime = false;
                                    break;
                                }
                            }
                            if (isPrime) Console.WriteLine("Success");
                            else throw new CustomException("Error! Enter an prime number\n");
                            break;
                        case 4:
                            if (number < 0) Console.WriteLine("Success");
                            else throw new CustomException("Error! Enter an negative number\n");
                            break;
                        case 5:
                            if (number == 0) Console.WriteLine("Success");
                            else throw new CustomException("Error! Enter zero\n");
                            break;
                    }
                }
                catch (CustomException ex)
                {
                    Console.WriteLine(ex.Message);
                    continue;
                }
                timesPlayed++;

                if (timesPlayed == 5)
                {
                    Console.WriteLine("\nYou have played this game for 5 times.\nCome Back Again.");
                    break;
                }
                Console.WriteLine("Play Again.\n");
            } 
            Console.ReadLine();
        }
    }
}
