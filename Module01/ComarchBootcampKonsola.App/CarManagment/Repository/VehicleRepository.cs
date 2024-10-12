using ComarchBootcampKonsola.App.CarManagment.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Diagnostics.Metrics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.JavaScript;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ComarchBootcampKonsola.App.CarManagment.Repository
{
    /// <summary>
    /// CRUD
    /// </summary>
    internal class VehicleRepository
    {
        private const string PATH = "./cars.txt";
        private static List<Vehicle> data = [];

        public List<Vehicle> GetAll()
        {

            return data;
        }


        public void SaveDataToFile()
        {
            if (!File.Exists(PATH))
            {
                File.Create(PATH).Close();
            }

            List<string> lines = new List<string>();
            foreach (var car in data)
            {
                lines.Add($"{car.CarType},{car.Id},{car.Maker},{car.Model},{car.GasType}," +
                    $"{car.Capacity},{car.IsBorrowed.ToString()},{car.Borrower}");
            }

            File.WriteAllLines(PATH, lines);
        }

        public void GetDataFromFile()
        {
            if (File.Exists(PATH))
            {
                string[] lines = File.ReadAllLines(PATH);

                foreach (var line in lines)
                {
                    string[] parts = line.Split(',');
                    
                    CarTypes carType = (CarTypes)Enum.Parse(typeof(CarTypes), parts[0]);
                    switch ( (CarTypes)carType )
                    {
                        case CarTypes.Car:
                            var car = new Car
                            {
                                Id = int.Parse(parts[1]),
                                Maker = parts[2],
                                Model = parts[3],
                                GasType = parts[4],
                                Capacity = int.Parse(parts[5]),
                                IsBorrowed = bool.Parse(parts[6]),
                                Borrower = parts[7],
                                CarType = carType
                            };
                            data.Add(car);
                            break;
                        case CarTypes.Bus:
                            var bus = new Bus
                            {
                                Id = int.Parse(parts[1]),
                                Maker = parts[2],
                                Model = parts[3],
                                GasType = parts[4],
                                Capacity = int.Parse(parts[5]),
                                IsBorrowed = bool.Parse(parts[6]),
                                Borrower = parts[7],
                                CarType = carType
                            };
                            data.Add(bus);
                            break;
                        case CarTypes.Truck:
                            var truck = new Truck
                            {
                                Id = int.Parse(parts[1]),
                                Maker = parts[2],
                                Model = parts[3],
                                GasType = parts[4],
                                Capacity = int.Parse(parts[5]),
                                IsBorrowed = bool.Parse(parts[6]),
                                Borrower = parts[7],
                                CarType = carType
                            };
                            data.Add(truck);
                            break;
                    }
                }
            }
        }

        public Vehicle GetVehicle(int id)
        {
            return data.FirstOrDefault(x => x.Id == id);
        }

        public void Add(Vehicle vehicle)
        {
            int id = 0;
            if(data.Any())
            {
                id = data.OrderByDescending(x => x.Id).First().Id;
            }
                
            vehicle.Id = id + 1;
            data.Add(vehicle);
        }

        public void Edit(int vehicleID, Vehicle vehicle)
        {
            Vehicle currentVehicle = GetVehicle(vehicleID);

            currentVehicle.Maker = vehicle.Maker;
            currentVehicle.Model = vehicle.Model;
            currentVehicle.GasType = vehicle.GasType;
            currentVehicle.Capacity = vehicle.Capacity;
            currentVehicle.CarType = vehicle.CarType;
        }

        public void Remove(int id)
        {
            Vehicle vehicle = GetVehicle(id);
            data.Remove(vehicle);
        }

    }
   }
