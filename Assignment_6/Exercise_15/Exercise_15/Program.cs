using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace Exercise_15
{
    class Program
    {
        static void Main(string[] args)
        {
            ObservableCollection<string> collection = new ObservableCollection<string>();
            collection.CollectionChanged += CollectionChangedHandler;

            collection.Add("Element 1");
            collection.Add("Element 2");
            collection.Add("Element 3");
            collection.Remove("Element 2");
            collection.Remove("Element 4");

            Console.ReadLine();
        }

        private static void CollectionChangedHandler(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    Console.WriteLine($"Element '{e.NewItems[0]}' is added in collection");
                    break;
                case NotifyCollectionChangedAction.Remove:
                    Console.WriteLine($"Element '{e.OldItems[0]}' is removed from collection");
                    break;
                default:
                    break;

            }
        }
    }
}
