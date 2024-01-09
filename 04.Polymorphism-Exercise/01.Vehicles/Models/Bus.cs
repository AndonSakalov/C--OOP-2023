namespace _01.Vehicles.Models
{
    public class Bus : Vehicle
    {
        private const double BusBonusFuelConsumption = 1.4;
        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity) : base(fuelQuantity, fuelConsumption, tankCapacity, BusBonusFuelConsumption)
        {

        }

        public string DriveEmpty(double km)
        {
            double consumption = FuelConsumption;
            if (FuelQuantity < km * consumption)
            {
                throw new ArgumentException($"{this.GetType().Name} needs refueling");
            }

            FuelQuantity -= km * consumption;
            return $"{this.GetType().Name} travelled {km} km";
        }
    }
}



