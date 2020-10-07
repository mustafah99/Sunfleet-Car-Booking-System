using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;
using static System.Console;
using System.Text.RegularExpressions;

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
            Dictionary<string, string> vehicleDictionary = new Dictionary<string, string>();


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

                        bool invalidCarCredentials = true;

                        do
                        {
                            VehicleRepresentation vehicle = new VehicleRepresentation();

                            Write("Registration Number: ");
                            vehicle.registrationNumber = ReadLine();

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

                            WriteLine("Is this correct? (Y)es (N)o");
                            WriteLine($"Registration Number: {vehicle.registrationNumber}");
                            WriteLine($"Brand: {vehicle.carBrand}");
                            WriteLine($"Model: {vehicle.vehicleModel}");
                            WriteLine($"Type (Sedan, Compact, Subcompact): {vehicle.vehicleType}");
                            WriteLine($"Autoupilot (Yes/No): {vehicle.autoPilot}");

                            ConsoleKeyInfo newInput = ReadKey(true);

                            if (newInput.Key == ConsoleKey.Y)
                            {
                                Clear();

                                WriteLine("Vehicle registered.");

                                Thread.Sleep(2000);

                                Clear();

                                break;
                            }
                            else if (newInput.Key == ConsoleKey.N)
                            {
                                Clear();
                            }
                        } while (invalidCarCredentials);

                        break;
                    case ConsoleKey.D2:
                        Write("Search for vehicle by license plate: ");
                        string searchingForVehicle = ReadLine();

                        foreach (var veh in allVehicles)
                        {
                            if (veh.registrationNumber == searchingForVehicle)
                            {
                                WriteLine("Value found.");
                                // write here all the information you want to display.
                                WriteLine($"Registration Number: {veh.registrationNumber}");
                                WriteLine($"Brand: {veh.carBrand}");
                                WriteLine($"Model: {veh.vehicleModel}");
                                WriteLine($"Type (Sedan, Compact, Subcompact): {veh.vehicleType}");
                                WriteLine($"Autoupilot: {veh.autoPilot}");
                            }
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
