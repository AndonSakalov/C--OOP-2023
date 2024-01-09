namespace CarManager.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class CarManagerTests
    {
        Car car;
        [SetUp]
        public void SetUp()
        {
            car = new("Audi", "RS7", 15.5, 80);
        }

        [Test]
        public void CreatingCar_ShouldSet_FuelAmountTo0()
        {
            int expectedFuelAmount = 0;
            Assert.AreEqual(expectedFuelAmount, car.FuelAmount);
        }

        [Test]
        public void CarConstructor_WorksCorrectly()
        {
            string expectedMake = "Mercedes";
            string expectedModel = "G63";
            double expectedFuelConsumption = 17.5;
            double expectedFuelCapacity = 85;

            car = new("Mercedes", "G63", 17.5, 85);

            Assert.AreEqual(expectedMake, car.Make);
            Assert.AreEqual(expectedModel, car.Model);
            Assert.AreEqual(expectedFuelConsumption, car.FuelConsumption);
            Assert.AreEqual(expectedFuelCapacity, car.FuelCapacity);
            Assert.IsNotNull(car);
        }

        [Test]
        public void CreatingCarWith_NullOrEmpty_Make_ShouldThrowException()
        {
            Assert.Throws<ArgumentException>(() => car = new(null, "M5", 14.5, 55), "Make cannot be null or empty!");

            Assert.Throws<ArgumentException>(() => car = new("", "M5", 14.5, 55), "Make cannot be null or empty!");
        }

        [Test]
        public void CreatingCarWith_NullOrEmpty_Model_ShouldThrowException()
        {
            Assert.Throws<ArgumentException>(() => car = new("Audi", null, 14.5, 55), "Model cannot be null or empty!");

            Assert.Throws<ArgumentException>(() => car = new("Audi", "", 14.5, 55), "Model cannot be null or empty!");
        }

        [Test]
        public void CreatingCarWith_ZeroOrNegative_FuelConsumption_ShouldThrowException()
        {
            Assert.Throws<ArgumentException>(() => car = new("Audi", "RS7", 0, 55), "Fuel consumption cannot be zero or negative!");

            Assert.Throws<ArgumentException>(() => car = new("Audi", "RS7", -1, 55), "Fuel consumption cannot be zero or negative!");

            Assert.Throws<ArgumentException>(() => car = new("Audi", "RS7", -1000, 55), "Fuel consumption cannot be zero or negative!");
        }

        [Test]
        public void CreatingCarWith_ZeroOrNegative_FuelCapacity_ShouldThrowException()
        {
            Assert.Throws<ArgumentException>(() => car = new("Audi", "RS7", 15.5, 0), "Fuel capacity cannot be zero or negative!");

            Assert.Throws<ArgumentException>(() => car = new("Audi", "RS7", 15.5, -1), "Fuel capacity cannot be zero or negative!");

            Assert.Throws<ArgumentException>(() => car = new("Audi", "RS7", -1000, -1000), "Fuel capacity cannot be zero or negative!");
        }

        [Test]
        public void RefuelMethod_ThrowsException_When_NegativeOrZero_AmountOfFuelIsGiven()
        {
            Assert.Throws<ArgumentException>(() => car.Refuel(0), "Fuel amount cannot be zero or negative!");
            Assert.Throws<ArgumentException>(() => car.Refuel(-1), "Fuel amount cannot be zero or negative!");
            Assert.Throws<ArgumentException>(() => car.Refuel(-1000), "Fuel amount cannot be zero or negative!");
        }

        [Test]
        public void RefuelMethod_Works_Correctly_EvenWhen_FuelAmountExceedsFuelCapacity()
        {
            car = new("VW", "Sharan", 10, 60);
            int expectedFuelAmountAfterRefuel = 50;
            car.Refuel(50);
            Assert.AreEqual(expectedFuelAmountAfterRefuel, car.FuelAmount);

            //WhenFuelAmountExceedsFuelCapacity

            expectedFuelAmountAfterRefuel = 60;
            car.Refuel(60);
            car.Refuel(600);
            car.Refuel(6000);
            Assert.AreEqual(expectedFuelAmountAfterRefuel, car.FuelAmount);
        }

        [Test]
        public void DriveMethod_Should_ThrowException_When_FuelAmountIsNotEnoughForTheGivenDistance()
        {
            //Car fuel consumption is 15.5l per 100km
            car.Refuel(5);
            Assert.Throws<InvalidOperationException>(() => car.Drive(50), "You don't have enough fuel to drive!");
            Assert.Throws<InvalidOperationException>(() => car.Drive(100), "You don't have enough fuel to drive!");
            Assert.Throws<InvalidOperationException>(() => car.Drive(10000), "You don't have enough fuel to drive!");
        }

        [Test]
        public void DriveMethod_Should_WorkCorrectly_By_RemovingFuelAmountForTheGivenDistance()
        {
            //Car fuel consumption is 15.5l per 100km
            int distance = 200; //km
            car.Refuel(car.FuelCapacity); //80l
            double expectedFuelAmountNeeded = (distance / 100) * 15.5;
            double expectedFuelAmountAfterDrivingTheDistance = car.FuelAmount - expectedFuelAmountNeeded;

            car.Drive(distance);

            Assert.AreEqual(expectedFuelAmountAfterDrivingTheDistance, car.FuelAmount);
        }
    }
}