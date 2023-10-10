using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_8
{
    class Program
    {
        static void Main(string[] args)
        {
            PriorityQueue<string> priorityQueue = new PriorityQueue<string>();
            priorityQueue.Enqueue(3, "Iooawi");
            priorityQueue.Enqueue(1, "Zuika");
            priorityQueue.Enqueue(2, "Aki");
            priorityQueue.Enqueue(5, "Iak");

            Console.WriteLine($"Top item: -> {priorityQueue.Peek()}");
            Console.WriteLine($"Removed item: -> {priorityQueue.Dequeue()}");
            Console.WriteLine($"Top item: -> {priorityQueue.Peek()}");
            Console.WriteLine($"Items present in this queue {priorityQueue.Count()}");
            Console.WriteLine($" ---> {priorityQueue.Contains("Iak")}");
            Console.WriteLine($"{priorityQueue.getHighestPriority()}");

            Console.ReadLine();
        }
    }

    class PriorityQueue<T> where T : IEquatable<T>
    {
        private IDictionary<int, IList<T>> elements;
        public PriorityQueue()
        {
            elements = new SortedDictionary<int, IList<T>>();
        }
        public PriorityQueue(IDictionary<int, IList<T>> elements) : this()
        {
        }
        public int Count()
        {
            return elements.Count;
        }
        public bool Contains(T item)
        {
            bool res = false;
            foreach (KeyValuePair<int, IList<T>> pair in elements)
            {
                if (pair.Value[0].Equals(item))
                {
                    Console.Write($"{item} Found ---> {pair.Key} {pair.Value[0]}");
                    res = true;
                }
            }
            return res;
        }
        public T Dequeue()
        {
            IList<T> list = elements[elements.Keys.First()];
            int priority = elements.Keys.First();
            T highestPriority = list.First();
            list.Remove(highestPriority);
            if(list.Count == 0)
            {
                elements.Remove(priority);
            }
            return highestPriority;
        }
        public void Enqueue(int priority, T item)
        {
            IList<T> items;
            if (!elements.ContainsKey(priority))
                elements.Add(priority, new List<T>());
            items = elements[priority];
            items.Add(item);
        }
        public T Peek()
        {
            IList<T> priorityList = elements[elements.Keys.First()];
            return priorityList[0];
        }
        public int getHighestPriority()
        {
            int Firstkey = elements.Take(1).Select(d => d.Key).First();
            return Firstkey;
        }
    }
}
