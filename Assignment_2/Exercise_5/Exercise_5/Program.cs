using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_5
{
    class Program
    {
        public enum DuckType
        {
            Rubber,
            Mallard,
            Redhead
        }

        public interface IFlyable
        {
            void Fly();
        }

        public interface IQuackable
        {
            void Quack();
        }

        public abstract class Duck
        {
            public double Weight { get; set; }
            public int NumWings { get; set; }
            public DuckType Type { get; set; }

            public Duck(double weight, int numWings, DuckType type)
            {
                Weight = weight;
                NumWings = numWings;
                Type = type;
            }

            public void ShowDetails()
            {
                Console.WriteLine($"Weight: {Weight}");
                Console.WriteLine($"Number of Wings: {NumWings}");
                Console.WriteLine($"Type: {Type}");
                Fly();
                Quack();
            }

            public abstract void Fly();
            public abstract void Quack();
        }

        public class RubberDuck : Duck, IQuackable
        {
            public RubberDuck(double weight, int numWings) : base(weight, numWings, DuckType.Rubber) { }
            public override void Quack()
            {
                Console.WriteLine("Quack: Squeak!");
            }
            public override void Fly()
            {
                Console.WriteLine("Rubber ducks don't fly.");
            }
        }

        public class MallardDuck : Duck, IFlyable, IQuackable
        {
            public MallardDuck(double weight, int numWings) : base(weight, numWings, DuckType.Mallard) { }
            public override void Fly()
            {
                Console.WriteLine("Flying fast.");
            }
            public override void Quack()
            {
                Console.WriteLine("Quack: Loud!");
            }
        }

        public class RedheadDuck : Duck, IFlyable, IQuackable
        {
            public RedheadDuck(double weight, int numWings) : base(weight, numWings, DuckType.Redhead) { }
            public override void Fly()
            {
                Console.WriteLine("Flying slow.");
            }
            public override void Quack()
            {
                Console.WriteLine("Quack: Mild!");
            }
        }
        static void Main(string[] args)
        {
            Duck rubberDuck = new RubberDuck(0.1, 0);
            rubberDuck.ShowDetails();

            Duck mallardDuck = new MallardDuck(1.2, 2);
            mallardDuck.ShowDetails();

            Duck redheadDuck = new RedheadDuck(0.8, 2);
            redheadDuck.ShowDetails();
            
            Console.ReadLine();
        }
    }
}
