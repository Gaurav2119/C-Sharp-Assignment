using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_4
{
    public enum EquipmentType
    {
        Mobile,
        Immobile
    }
    public abstract class Equipment
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double DistanceMovedTillDate { get; protected set; } = 0;
        public double MaintenanceCost { get; protected set; } = 0;
        public abstract EquipmentType Type { get; }
        public virtual void MoveBy(double distance)
        {
            DistanceMovedTillDate += distance;
            MaintenanceCost += GetMaintenanceCost(distance);
        }

        protected abstract double GetMaintenanceCost(double distance);
    }
    public class MobileEquipment : Equipment
    {
        public int NumberOfWheels { get; set; }
        public override EquipmentType Type => EquipmentType.Mobile;
        protected override double GetMaintenanceCost(double distance)
        {
            return NumberOfWheels * distance;
        }
    }
    public class ImmobileEquipment : Equipment
    {
        public double Weight { get; set; }
        public override EquipmentType Type => EquipmentType.Immobile;
        protected override double GetMaintenanceCost(double distance)
        {
            return Weight * distance;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var mobileEquipment = new MobileEquipment
            {
                Name = "JCB",
                Description = "Heavy Equipment",
                NumberOfWheels = 4
            };

            var immobileEquipment = new ImmobileEquipment
            {
                Name = "Ladder",
                Description = "Portable Steps",
                Weight = 5
            };

            mobileEquipment.MoveBy(10);
            immobileEquipment.MoveBy(5);

            Console.WriteLine($"Mobile Equipment Name: {mobileEquipment.Name}");
            Console.WriteLine($"Mobile Equipment Type: {mobileEquipment.Type}");
            Console.WriteLine($"{mobileEquipment.Name} Wheels: {mobileEquipment.NumberOfWheels}");
            Console.WriteLine($"Mobile Equipment Distance Moved: {mobileEquipment.DistanceMovedTillDate}");
            Console.WriteLine($"Mobile Equipment Maintenance Cost: {mobileEquipment.MaintenanceCost}");

            Console.WriteLine($"\n\nImmobile Equipment Name: {immobileEquipment.Name}");
            Console.WriteLine($"Immobile Equipment Type: {immobileEquipment.Type}");
            Console.WriteLine($"{immobileEquipment.Name} Wheels: {immobileEquipment.Weight}");
            Console.WriteLine($"Immobile Equipment Distance Moved: {immobileEquipment.DistanceMovedTillDate}");
            Console.WriteLine($"Immobile Equipment Maintenance Cost: {immobileEquipment.MaintenanceCost}");


            Console.ReadLine();
        }
    }
}
