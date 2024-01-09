using _01.Vehicles.Core.Interfaces;
using _01.Vehicles.Factories.Interfaces;
using _01.Vehicles.IO.Interfaces;
using _01.Vehicles.Models;
using _01.Vehicles.Models.Interfaces;

namespace _01.Vehicles.Core
{
    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly IVehicleFactory vehicleFactory;
        private readonly ICollection<IVehicle> vehicles;

        public Engine(IReader reader, IWriter writer, IVehicleFactory vehicleFactory)
        {
            this.reader = reader;
            this.writer = writer;
            this.vehicleFactory = vehicleFactory;
            vehicles = new List<IVehicle>();
        }
        public void Run()
        {
            vehicles.Add(CreateVehicle(reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)));
            vehicles.Add(CreateVehicle(reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)));
            vehicles.Add(CreateVehicle(reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)));
            int numberOfCommands = int.Parse(reader.ReadLine());
            for (int i = 0; i < numberOfCommands; i++)
            {
                try
                {
                    ProcessCommand();
                }
                catch (Exception ex)
                {
                    writer.WriteLine(ex.Message);
                }
            }
            foreach (IVehicle vehicle in vehicles)
            {
                Console.WriteLine(vehicle);
            }
        }

        private void ProcessCommand()
        {
            string[] inputTokens = reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            IVehicle foundVehicle = vehicles.FirstOrDefault(v => v.GetType().Name == inputTokens[1]);
            switch (inputTokens[0])
            {
                case "Drive":
                    writer.WriteLine(foundVehicle.Drive(double.Parse(inputTokens[2])));
                    break;
                case "Refuel":
                    foundVehicle.Refuel(double.Parse(inputTokens[2]));
                    break;
                case "DriveEmpty":
                    if (foundVehicle.GetType().Name == "Bus")
                    {
                        Bus bus = foundVehicle as Bus;
                        if (bus != null)
                        {
                            bus.DriveEmpty(double.Parse(inputTokens[2]));
                        }
                        //else
                        //{
                        //    throw new ArgumentException("Bus does not exist");
                        //}
                    }
                    break;
                default:
                    throw new ArgumentException("Invalid command");
            }
        }

        public IVehicle CreateVehicle(string[] vehicleInfo)
        {
            return vehicleFactory.Create(vehicleInfo[0], double.Parse(vehicleInfo[1]), double.Parse(vehicleInfo[2]), double.Parse(vehicleInfo[3]));
        }
    }
}
