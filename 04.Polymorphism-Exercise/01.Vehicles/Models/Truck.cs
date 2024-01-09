namespace _01.Vehicles.Models
{
    public class Truck : Vehicle
    {
        private const double TruckBonusFuelConsumption = 1.6;
        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity) : base(fuelQuantity, fuelConsumption, tankCapacity, TruckBonusFuelConsumption)
        {
        }
        public override void Refuel(double fuelAmount) //Possible problem with tankCapacity checking!
        {
            if (fuelAmount <= 0)
            {

            }
            if (FuelQuantity + fuelAmount * 0.95 > TankCapacity)
            {
                throw new ArgumentException($"Cannot fit {fuelAmount} fuel in the tank");
            }

            base.Refuel(fuelAmount * 0.95);
        }
    }
}
