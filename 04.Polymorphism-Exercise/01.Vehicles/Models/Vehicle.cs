using _01.Vehicles.Models.Interfaces;

namespace _01.Vehicles.Models
{
    public abstract class Vehicle : IVehicle
    {
        private double bonusFuelConsumption;
        private double fuelQuantity;
        private double tankCapacity;
        protected Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity, double bonusFuelConsumption)
        {
            if (fuelQuantity > tankCapacity)
            {
                FuelQuantity = 0;
            }
            else
            {
                FuelQuantity = fuelQuantity;
            }

            TankCapacity = tankCapacity;
            FuelConsumption = fuelConsumption;
            this.bonusFuelConsumption = bonusFuelConsumption;
        }

        public double FuelQuantity { get; private protected set; }


        public double FuelConsumption { get; private set; }

        public double TankCapacity { get; private set; }

        public string Drive(double km)
        {
            double consumption = FuelConsumption + bonusFuelConsumption;
            if (FuelQuantity < km * consumption)
            {
                throw new ArgumentException($"{this.GetType().Name} needs refueling");
            }

            FuelQuantity -= km * consumption;
            return $"{this.GetType().Name} travelled {km} km";
        }
        public virtual void Refuel(double fuelAmount)
        {
            if (fuelAmount <= 0)
            {
                throw new ArgumentException($"Fuel must be a positive number");
            }

            if (FuelQuantity + fuelAmount > TankCapacity)
            {
                throw new ArgumentException($"Cannot fit {fuelAmount} fuel in the tank");
            }

            FuelQuantity += fuelAmount;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {FuelQuantity:F2}";
        }
    }
}
