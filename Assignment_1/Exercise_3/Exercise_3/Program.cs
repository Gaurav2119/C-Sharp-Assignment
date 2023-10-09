using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_3
{
    class Program
    {
        static bool isPrime(int number)
        {
            if (number < 2) return false;
            for (int i = 2; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0) return false;
            }
            return true;
        }
        static void Main(string[] args)
        {
            string small, large;
            int smaller, larger;
            while(true)
            {
                Console.WriteLine("Enter two positive non equal intergers between 2 and 1000, in increasing order: ");
                Console.Write("Enter smaller one: ");
                small = Console.ReadLine();
                Console.Write("Enter larger one: ");
                large = Console.ReadLine();

                if (int.TryParse(small, out smaller) && int.TryParse(large, out larger))
                {
                    if (smaller < larger) break;
                    else Console.WriteLine("The first number must be smaller than the second");
                }
                else Console.WriteLine("Invalid input. Try Again.");
            }
            Console.Write("Prime numbers between {0} and {1} are: ", smaller, larger);
            for (int i = smaller; i <= larger; i++)
            {
                if (isPrime(i)) Console.Write(i + " ");
            }
            Console.ReadLine();
        }
    }
}
