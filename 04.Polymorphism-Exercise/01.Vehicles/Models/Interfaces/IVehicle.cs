namespace _01.Vehicles.Models.Interfaces
{
    public interface IVehicle
    {
        double FuelQuantity { get; }
        double FuelConsumption { get; }
        double TankCapacity { get; }

        string Drive(double km);
        void Refuel(double fuelAmount);
    }
}
