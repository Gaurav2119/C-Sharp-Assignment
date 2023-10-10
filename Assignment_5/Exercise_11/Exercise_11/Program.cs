using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_11
{
    public static class Extension
    {
        public static bool IsOdd(this int number)
        {
            return number % 2 != 0;
        }

        public static bool IsEven(this int number)
        {
            return number % 2 == 0;
        }

        public static bool IsPrime(this int number)
        {
            if (number == 1) return false;
            if (number == 2) return true;
            for (int i = 2; i <= Math.Sqrt(number); i++)
            {
                if ((number % i) == 0) return false;
            }
            return true;
        }

        public static bool IsDivisibleBy(this int number, int divisor)
        {
            return number % divisor == 0;
        }
    }
    class Program
    {
            static void Main(string[] args)
            {
                Console.Write("Enter a number: ");
                string input;
                input = Console.ReadLine();
                int.TryParse(input, out int num);

                Console.WriteLine("\nThe given number is:");

                if (num.IsOdd()) Console.WriteLine("Odd");
                if (num.IsEven()) Console.WriteLine("Even");
                if (num.IsPrime()) Console.WriteLine("Prime Number");
                if (num.IsDivisibleBy(4)) Console.WriteLine("Is divisble by 4");

                Console.ReadLine();
            }
    }
}
