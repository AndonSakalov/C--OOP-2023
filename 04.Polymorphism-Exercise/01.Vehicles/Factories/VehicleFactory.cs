using _01.Vehicles.Factories.Interfaces;
using _01.Vehicles.Models;
using _01.Vehicles.Models.Interfaces;

namespace _01.Vehicles.Factories
{
    public class VehicleFactory : IVehicleFactory
    {
        public IVehicle Create(string type, double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            switch (type)
            {
                case "Car":
                    return new Car(fuelQuantity, fuelConsumption, tankCapacity);
                case "Truck":
                    return new Truck(fuelQuantity, fuelConsumption, tankCapacity);
                case "Bus":
                    return new Bus(fuelQuantity, fuelConsumption, tankCapacity);
                default:
                    throw new ArgumentException("Invalid vehicle type");
            }
        }
    }
}
