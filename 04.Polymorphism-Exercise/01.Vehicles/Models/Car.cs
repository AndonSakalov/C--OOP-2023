namespace _01.Vehicles.Models
{
    public class Car : Vehicle
    {
        private const double CarBonusFuelConsumption = 0.9;
        public Car(double fuelQuantity, double fuelConsumption, double tankCapacity) : base(fuelQuantity, fuelConsumption, tankCapacity, CarBonusFuelConsumption)
        {

        }
    }
}
