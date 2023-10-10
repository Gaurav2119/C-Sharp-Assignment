using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise9
{
    interface IPriority
    {
        int Priority { get; set; }
    }

    class PriorityQueue2<T> : IPriority where T : IEquatable<T>
    {

        private IDictionary<int, IList<T>> elements;
        public PriorityQueue2()
        {
            elements = new Dictionary<int, IList<T>>();
        }
        public PriorityQueue2(IDictionary<int, IList<T>> elements) : this()
        {
            this.elements = elements;
        }
        public int Count
        {
            get
            {

                return elements.Count;
            }
        }
        public int Priority { get; set; }
        public bool Contains(T items)
        {
            foreach (var list in elements)
            {
                foreach (T ele in list.Value)
                {
                    if (ele.Equals(items))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public T Dequeue()
        {
            if (elements.Count > 0)
            {
                int highestPriority = HighestPriority;
                T ele = elements[highestPriority][0];
                elements[highestPriority].Remove(ele);
                if (elements[highestPriority].Count == 0)
                {
                    elements.Remove(highestPriority);
                }
                return ele;
            }
            else
                throw new Exception("No element found");
        }
        public void Enqueue(T item)
        {
            if (!elements.ContainsKey(Priority))
            {
                elements[Priority] = new List<T>();
            }
            elements[Priority].Add(item);

        }
        public T Peek()
        {
            if (elements.Count > 0)
            {
                return elements[HighestPriority][0];
            }
            else
                throw new Exception("No element found");
        }
        public int HighestPriority
        {
            get
            {
                List<int> keys = elements.Keys.ToList();
                keys = keys.OrderByDescending(ele => ele).ToList();
                return keys[0];
            }
        }
        public int GetHighestPriority()
        {
            return this.HighestPriority;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            PriorityQueue2<int> pq = new PriorityQueue2<int>();

            //Enque Operation
            //setting priority with Property
            pq.Priority = 5;
            pq.Enqueue(10);
            pq.Enqueue(30);
            pq.Priority = 1;
            pq.Enqueue(90);

            pq.Priority = 10;
            pq.Enqueue(60);
            pq.Enqueue(88);
            pq.Priority = 6;
            pq.Enqueue(72);

            //peek()
            Console.WriteLine(pq.Peek());
            //contain
            Console.WriteLine(pq.Contains(10));
            //Deque
            Console.WriteLine(pq.Dequeue());
            //count
            Console.WriteLine(pq.Count);
            //Get Highest Priority
            Console.WriteLine(pq.GetHighestPriority());

            Console.ReadLine();
        }
    }
}