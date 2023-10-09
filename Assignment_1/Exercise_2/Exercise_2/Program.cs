using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 5;
            int b = 5;
            object obj1 = new object();
            object obj2 = new object();
            object obj3 = a;
            object obj4 = obj1;

            // Example 1: Reference types with the == operator

            Console.WriteLine(a == b); // True
            Console.WriteLine(obj1 == obj2); // False
            Console.WriteLine(obj1 == obj1); // True
            // Console.WriteLine(obj3 == b); --> == cann't be applied to object and int
            Console.WriteLine(obj1 == obj4); // True

            Console.WriteLine();

            // Example 2: Reference types with the object.Equals method

            Console.WriteLine(a.Equals(b)); // True
            Console.WriteLine(obj1.Equals(obj2)); // False
            Console.WriteLine(obj1.Equals(obj1)); // True
            Console.WriteLine(obj3.Equals(b)); // True
            Console.WriteLine(obj1.Equals(obj4)); // True

            Console.WriteLine();

            // Example 3: Reference types with the object.ReferenceEquals method

            
            Console.WriteLine(object.ReferenceEquals(a, b)); // False
            Console.WriteLine(object.ReferenceEquals(obj1, obj2)); // False
            Console.WriteLine(object.ReferenceEquals(obj1, obj1)); // True
            Console.WriteLine(object.ReferenceEquals(obj3, b)); // False
            Console.WriteLine(object.ReferenceEquals(obj1, obj4)); // True

            Console.ReadLine();

        }
    }
}
