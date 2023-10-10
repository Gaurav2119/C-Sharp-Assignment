using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_12
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int> { 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            // 1. Find odd - Lambda Expression – without curly brackets
            var odds = numbers.Where(x => x % 2 == 1);
            Console.WriteLine("Odd numbers: " + string.Join(", ", odds));

            // 2. Find Even - Lambda Expression – with curly brackets
            var evens = numbers.Where(x => { return x % 2 == 0; });
            Console.WriteLine("Even numbers: " + string.Join(", ", evens));

            // 3. Find Prime – Anonymous Method
            var primes = numbers.Where(delegate (int x)
            {
                if (x < 2) return false;
                for (int i = 2; i <= Math.Sqrt(x); i++)
                {
                    if (x % i == 0) return false;
                }
                return true;
            });
            Console.WriteLine("Prime numbers: " + string.Join(", ", primes));

            // 4. Find Prime Another – Lambda Expression
            var prime = numbers.Where(x =>
            {
                if (x <= 1) return false;
                for (int i = 2; i <= x / 2; i++)
                    if (x % i == 0)
                        return false;
                return true;
            });
            Console.WriteLine("Prime numbers using lambda expression: " + string.Join(", ", prime));

            // 5. Find Elements Greater Than Five – Method Group Conversion Syntax
            Func<int, bool> greaterThanFive = new Func<int, bool>(GreaterThanFive);
            var greater = numbers.Where(greaterThanFive);
            Console.WriteLine("Numbers greater than five: " + string.Join(", ", greater));

            // 6. Find Less than Five – Delegate Object in Where – Method Group Conversion Syntax in Constructor of Object
            Func<int, bool> lessThanFive = new Func<int, bool>(LessThanFive);
            var less = numbers.Where(lessThanFive);
            Console.WriteLine("Numbers lesser than five: " + string.Join(", ", less));

            // 7. Find 3k – Delegate Object in Where –Lambda Expression in Constructor of Object
            Func<int, bool> multipleofThree = new Func<int, bool>(x => x % 3 == 0);
            var multiplesofThree = numbers.Where(multipleofThree);
            Console.WriteLine("Multiples of Three: " + string.Join(", ", multiplesofThree));

            // 8. Find 3k + 1 - Delegate Object in Where –Anonymous Method in Constructor of Object
            Func<int, bool> oneMoreThanMultipleOfThree = new Func<int, bool>(delegate (int x)
            {
                return x % 3 == 1;
            });
            var oneMoreThanMultiplesOfThree = numbers.Where(oneMoreThanMultipleOfThree);
            Console.WriteLine("One More Than Multiples Of Three: " + string.Join(", ", oneMoreThanMultiplesOfThree));

            // 9. Find 3k + 2 - Delegate Object in Where –Lambda Expression Assignment
            Func<int, bool> twoMoreThanMultipleOfThree = (x => x % 3 == 2);
            var twoMoreThanMultiplesOfThree = numbers.Where(twoMoreThanMultipleOfThree);
            Console.WriteLine("Two More Than Multiples Of Three: " + string.Join(", ", twoMoreThanMultiplesOfThree));

            // 10. Find anything - Delegate Object in Where – Anonymous Method Assignment
            Func<int, bool> anything = delegate (int x) { return x != 0; };
            var allNumbers = numbers.Where(anything);
            Console.WriteLine("All numbers: " + string.Join(", ", allNumbers));

            // 11. Find anything - Delegate Object in Where – Method Group Conversion Assignment
            Func<int, bool> Anything = AnythingMethod;
            var AllNumbers = numbers.Where(Anything);
            Console.WriteLine("All numbers: " + string.Join(", ", AllNumbers));

            Console.ReadLine();
        }

        public static bool GreaterThanFive(int x)
        {
            return x > 5;
        }

        public static bool LessThanFive(int x)
        {
            return x < 5;
        }

        public static bool AnythingMethod(int x)
        {
            return x != 0;
        }
    }
}