using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;
using static System.Console;
using System.Text.RegularExpressions;
using System.Linq;

namespace Sunfleet_Car_Terminal
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("Welcome to Sunfleets Car Administration Terminal.");

            Thread.Sleep(500);

            Clear();

            bool invalidCredentials = true;
            do
            {
                Write("Username: ");
                string username = ReadLine();
                Write("Password: ");
                string password = ReadLine();

                if (username == "admin" && password == "admin")
                {
                    Clear();

                    WriteLine("Logging in...");

                    Thread.Sleep(300);

                    Clear();

                    invalidCredentials = false;

                    WriteLine("Welcome Admin.");

                    Thread.Sleep(500);

                    Clear();
                }
                else
                {
                    Clear();

                    WriteLine("Logging in...");

                    Thread.Sleep(300);

                    Clear();

                    WriteLine("Invalid credentials, please try again.");

                    Thread.Sleep(2000);

                    Clear();
                }

            } while (invalidCredentials);

            CursorVisible = false;

            bool sunfleetAdminTools = true;

            //Dictionary<string, string> newVehicle = new Dictionary<string, string>();

            List<VehicleRepresentation> allVehicles = new List<VehicleRepresentation>();

            // I want to use a dictionary instead of a List in order to save my vehicle informations.
            Dictionary<String, String> vehicleDict = new Dictionary<String, String>();

            List<TruckRepresentation> allTrucks = new List<TruckRepresentation>();



            do
            {
                WriteLine("1. Add Vehicle");

                WriteLine("2. Search Vehicle");

                WriteLine("3. Log Out");

                ConsoleKeyInfo keyInput = ReadKey(true);

                Clear();

                switch (keyInput.Key)
                {
                    case ConsoleKey.D1:

                        Clear();

                        WriteLine("1. Car");
                        WriteLine("2. Truck");

                        bool invalidVehicleCredentials = true;

                        ConsoleKeyInfo newInput = ReadKey(true);
                        if (newInput.Key == ConsoleKey.D1)
                        {
                            Clear();
                            do
                            {
                                VehicleRepresentation vehicle = new VehicleRepresentation();

                                Write("Registration Number: ");
                                vehicle.registrationNumber = ReadLine();
                                //vehicleDict.Add("Registration Number", ReadLine());

                                Write("Brand: ");
                                vehicle.carBrand = ReadLine();

                                Write("Model: ");
                                vehicle.vehicleModel = ReadLine();

                                Write("Type (Sedan, Compact, Subcompact): ");
                                vehicle.vehicleType = ReadLine();

                                Write("Autopilot (Yes, No): ");
                                vehicle.autoPilot = ReadLine();

                                Clear();

                                allVehicles.Add(vehicle);

                                WriteLine($"Registration Number: {vehicle.registrationNumber}");
                                WriteLine($"Brand: {vehicle.carBrand}");
                                WriteLine($"Model: {vehicle.vehicleModel}");
                                WriteLine($"Type (Sedan, Compact, Subcompact): {vehicle.vehicleType}");
                                WriteLine($"Autoupilot (Yes/No): {vehicle.autoPilot}");

                                WriteLine(" ");

                                WriteLine("Is this correct? (Y)es (N)o");

                                ConsoleKeyInfo newInputs = ReadKey(true);

                                // I want to run a code here that checks if the registration number already exists
                                if (newInputs.Key == ConsoleKey.Y)
                                {
                                    Clear();

                                    WriteLine("Vehicle registered.");

                                    Thread.Sleep(2000);

                                    Clear();

                                    break;
                                }
                                else if (newInputs.Key == ConsoleKey.N)
                                {
                                    Clear();
                                }
                            } while (invalidVehicleCredentials);
                        }
                        else if (newInput.Key == ConsoleKey.D2)
                        {
                            Clear();
                            do
                            {
                                TruckRepresentation truckVehicle = new TruckRepresentation();

                                Write("Registration Number: ");
                                truckVehicle.registrationNumber = ReadLine();
                                //vehicleDict.Add("Registration Number", ReadLine());

                                Write("Brand: ");
                                truckVehicle.carBrand = ReadLine();

                                Write("Model: ");
                                truckVehicle.vehicleModel = ReadLine();

                                Write("Capacity: ");
                                truckVehicle.capacityCubic = ReadLine();

                                Write("Has Lift: ");
                                truckVehicle.liftAvailability = ReadLine();

                                Clear();

                                allTrucks.Add(truckVehicle);

                                WriteLine($"Registration Number: {truckVehicle.registrationNumber}");
                                WriteLine($"Brand: {truckVehicle.carBrand}");
                                WriteLine($"Model: {truckVehicle.vehicleModel}");
                                WriteLine($"Capacity: {truckVehicle.capacityCubic}");
                                WriteLine($"Has Lift: {truckVehicle.liftAvailability}");

                                WriteLine(" ");

                                WriteLine("Is this correct? (Y)es (N)o");


                                ConsoleKeyInfo newInputs = ReadKey(true);

                                // I want to run a code here that checks if the registration number already exists
                                if (newInputs.Key == ConsoleKey.Y)
                                {
                                    Clear();

                                    WriteLine("Vehicle registered.");

                                    Thread.Sleep(2000);

                                    Clear();

                                    break;
                                }
                                else if (newInputs.Key == ConsoleKey.N)
                                {
                                    Clear();
                                }
                            } while (invalidVehicleCredentials);
                        }

                        break;
                    case ConsoleKey.D2:
                        WriteLine("Choose Vehicle to Search For: ");
                        WriteLine("1. Car");
                        WriteLine("2. Truck");

                        ConsoleKeyInfo carOrTruck = ReadKey(true);

                        if (carOrTruck.Key == ConsoleKey.D1)
                        {
                            Clear();

                            Write("Search for vehicle by license plate: ");

                            string searchingForCar = ReadLine();

                            var c = allVehicles.FirstOrDefault(cars => cars.registrationNumber == searchingForCar);

                            if (c == null)
                            {
                                WriteLine("Vehicle not found");
                            }
                            else
                            {
                                Clear();
                                WriteLine("Value found.");
                                WriteLine(" ");
                                // write here all the information you want to display.
                                WriteLine($"Registration Number: {c.registrationNumber}");
                                WriteLine($"Brand: {c.carBrand}");
                                WriteLine($"Model: {c.vehicleModel}");
                                WriteLine($"Type (Sedan, Compact, Subcompact): {c.vehicleType}");
                                WriteLine($"Autoupilot: {c.autoPilot}");
                                WriteLine(" ");
                                WriteLine("Press any key to continue");
                            }

                            ReadKey(true);

                            Clear();

                            break;
                        }
                        else if (carOrTruck.Key == ConsoleKey.D2)
                        {
                            Clear();

                            Write("Search for vehicle by license plate: ");

                            string searchForTruck = ReadLine();

                            var t = allTrucks.FirstOrDefault(trucks => trucks.registrationNumber == searchForTruck);

                            if (t == null)
                            {
                                WriteLine("Vehicle not found");
                            }
                            else
                            {
                                Clear();
                                WriteLine("Value found.");
                                WriteLine(" ");
                                // write here all the information you want to display.
                                WriteLine($"Registration Number: {t.registrationNumber}");
                                WriteLine($"Brand: {t.carBrand}");
                                WriteLine($"Model: {t.vehicleModel}");
                                WriteLine($"Capacity: {t.capacityCubic}");
                                WriteLine($"Has Lift: {t.liftAvailability}");
                                WriteLine(" ");
                                WriteLine("Press any key to continue");
                            }

                            ReadKey(true);

                            Clear();

                            break;
                        }

                        ReadKey(true);

                        Clear();

                        break;
                    case ConsoleKey.D3:
                        Clear();

                        WriteLine("Logging out...");

                        Thread.Sleep(1000);

                        sunfleetAdminTools = false;

                        Environment.Exit(0);

                        break;
                }

            } while (sunfleetAdminTools);
        }
    }
}
