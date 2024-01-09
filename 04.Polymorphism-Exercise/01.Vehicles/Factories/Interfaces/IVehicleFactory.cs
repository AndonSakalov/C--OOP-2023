using _01.Vehicles.Models.Interfaces;

namespace _01.Vehicles.Factories.Interfaces
{
    public interface IVehicleFactory
    {
        IVehicle Create(string type, double fuelQuantity, double fuelConsumption, double tankCapacity);
    }
}
