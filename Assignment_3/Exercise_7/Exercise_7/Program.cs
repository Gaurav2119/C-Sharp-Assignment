using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_7
{
    class Program
    {
        
        // enum to represent different types of ducks
        public enum DuckType
        {
            Rubber,
            Mallard,
            Redhead
        }
        
        // interface for flying behaviour
        public interface IFlyable
        {
            void Fly();
        }
        
        // interface for quacking behaviour
        public interface IQuackable
        {
            void Quack();
        }

        // base class for all ducks
        public abstract class Duck
        {
            // properties
            public double Weight { get; set; }
            public int NumWings { get; set; }
            public DuckType Type { get; set; }

            // constructor
            public Duck(double weight, int numWings, DuckType type)
            {
                Weight = weight;
                NumWings = numWings;
                Type = type;
            }

            // show details of duck
            public void ShowDetails()
            {
                Console.WriteLine($"Weight: {Weight}");
                Console.WriteLine($"Number of Wings: {NumWings}");
                Console.WriteLine($"Type: {Type}");
                Fly();
                Quack();
            }

            // abstract method for flying and quacking behaviour
            public abstract void Fly();
            public abstract void Quack();
        }

        // class for rubber duck
        public class RubberDuck : Duck, IQuackable
        {
            
            // constructor
            public RubberDuck(double weight, int numWings) : base(weight, numWings, DuckType.Rubber) { }

            // quacking behaviour implementation
            public override void Quack()
            {
                Console.WriteLine("Quack: Squeak!");
            }

            // flying behaviour implementation
            public override void Fly()
            {
                Console.WriteLine("Rubber ducks don't fly.");
            }
        }

        // class for mallard ducks
        public class MallardDuck : Duck, IFlyable, IQuackable
        {
            // constructor
            public MallardDuck(double weight, int numWings) : base(weight, numWings, DuckType.Mallard) { }

            // flying behaviour implementation
            public override void Fly()
            {
                Console.WriteLine("Flying fast.");
            }

            // // quacking behaviour implementation
            public override void Quack()
            {
                Console.WriteLine("Quack: Loud!");
            }
        }

        // class for rubberhead duck
        public class RedheadDuck : Duck, IFlyable, IQuackable
        {

            // constructor
            public RedheadDuck(double weight, int numWings) : base(weight, numWings, DuckType.Redhead) { }

            // flying behaviour implementation
            public override void Fly()
            {
                Console.WriteLine("Flying slow.");
            }

            // quacking behaviour implementation
            public override void Quack()
            {
                Console.WriteLine("Quack: Mild!");
            }
        }

        // manage collection of ducks
        public class DuckCollection
        {
            private List<Duck> ducks = new List<Duck>();

            // add duck to the collection
            public void AddDuck(Duck duck)
            {
                ducks.Add(duck);
            }

            // remove duck from the collection
            public void RemoveDuck(Duck duck)
            {
                ducks.Remove(duck);
            }

            // remove all ducks from the collection
            public void RemoveAllDucks()
            {
                ducks.Clear();
            }

            // iterate duck collection in increasing order of weight
            public IEnumerable<Duck> GetDucksByWeight()
            {
                return ducks.OrderBy(duck => duck.Weight);
            }

            // iterate duck collection in increasing order of number of wings
            public IEnumerable<Duck> GetDucksByNumWings()
            {
                return ducks.OrderBy(duck => duck.NumWings);
            }
        }
        static void Main(string[] args)
        {
            // new duck collection
            DuckCollection duckCollection = new DuckCollection();

            // add ducks to collection
            duckCollection.AddDuck(new MallardDuck(2.5, 2));
            duckCollection.AddDuck(new RedheadDuck(1.8, 2));
            duckCollection.AddDuck(new RubberDuck(0.5, 0));
            duckCollection.AddDuck(new MallardDuck(3.2, 2));
            duckCollection.AddDuck(new RedheadDuck(1.6, 2));

            // remove duck from collection
            duckCollection.RemoveDuck(duckCollection.GetDucksByWeight().First());

            // remove all ducks from the collection
            duckCollection.RemoveAllDucks();

            // add some duck in collection
            duckCollection.AddDuck(new MallardDuck(2.5, 2));
            duckCollection.AddDuck(new RedheadDuck(1.8, 2));

            Console.WriteLine("Get Ducks by weight: ");
            // iterate over ducks in collection by weight
            foreach (Duck duck in duckCollection.GetDucksByWeight())
            {
                duck.ShowDetails();
            }

            Console.WriteLine("\n\nGet Ducks by num of wings: ");
            // iterate over ducks in collection by number of wings
            foreach (Duck duck in duckCollection.GetDucksByNumWings())
            {
                duck.ShowDetails();
            }

            Console.ReadLine();
        }
    }
}
