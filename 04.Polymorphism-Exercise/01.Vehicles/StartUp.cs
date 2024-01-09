using _01.Vehicles.Core;
using _01.Vehicles.Core.Interfaces;
using _01.Vehicles.Factories;
using _01.Vehicles.Factories.Interfaces;
using _01.Vehicles.IO;
using _01.Vehicles.IO.Interfaces;

IReader reader = new ConsoleReader();
IWriter writer = new ConsoleWriter();
IVehicleFactory vehileFactory = new VehicleFactory();
IEngine engine = new Engine(reader, writer, vehileFactory);

engine.Run();