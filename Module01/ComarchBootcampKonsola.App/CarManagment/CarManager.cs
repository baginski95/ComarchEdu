using ComarchBootcampKonsola.App.CarManagment.Model;
using ComarchBootcampKonsola.App.CarManagment.Repository;
using ConsoleTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace ComarchBootcampKonsola.App.CarManagment
{
    internal class CarManager
    {
        private readonly VehicleRepository repository;
        public CarManager()
        {
            repository = new VehicleRepository();
            repository.GetDataFromFile();
        }
        public void Start()
        {
            int choice;
            do
            {
                ShowMenu();

                Console.Write("Wybierz pozycję: ");
                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    switch (choice)
                    {
                        case 1:
                            ShowCars();
                            break;
                        case 2:
                            AddNewCar();
                            break;
                        case 3:
                            EditCar();
                            break;
                        case 4:
                            DeleteCar();
                            break;
                        case 5:
                            BorrowCar();
                            break;
                        case 6:
                            ReceiveCar();
                            break;
                        default:
                            break;
                    }
                    repository.SaveDataToFile();
                }
                else
                {
                    ShowError("Wprowadzona wartość jest nieprawidłowa.");
                    choice = 99;
                    continue;
                }

            } while (choice != 0);
        }

        private void ReceiveCar()
        {
            Vehicle? vehicle = CheckVehicleID();

            vehicle?.Receive();
        }

        private void BorrowCar()
        {
            Vehicle? vehicle = CheckVehicleID();

            bool isBorrowerName = true;
            string? borrower;

            do
            {
                Console.Write("Podaj nazwę osoby wypożyczającej pojazd: ");
                borrower = Console.ReadLine();
                if (borrower != null && borrower.Length > 0) isBorrowerName = false;
            } while (isBorrowerName);

            vehicle?.Borrow(borrower);
        }

        protected void ShowError(string msg, bool stopProgram = true)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(msg);
            Console.ResetColor();
            
            Console.ReadKey();
        }

        private void DeleteCar()
        {
            Console.WriteLine("Usunięcie pojazdu.");

            int vehicleID = ValidateInsertedInteger("Podaj ID pojazdu: ",
                                                      "Błędna wartość. Zajrzyj do listy pojazdów i podaj poprawne ID.");

            repository.Remove(vehicleID);
        }

        private Vehicle? GetCarData(Vehicle? vehicle)
        {
            int carTypeUser = ValidateInsertedInteger("Wybierz typ auta: \n 1. Car\n 2. Bus\n 3. Truck\n",
                                                        "Błędny typ danych. Podaj typ auta . Wprowadź [1-3].", 1, 3);

            CarTypes carType = (CarTypes)carTypeUser;

            switch (carType)
            {
                case CarTypes.Car:
                    vehicle = new Car();
                    break;
                case CarTypes.Bus:
                    vehicle = new Bus();
                    break;
                case CarTypes.Truck:
                    vehicle = new Truck();
                    break;
                default:
                    Console.WriteLine("Nieprawidłowa opcja");
                    break;
            }

            if (vehicle == null) return null;

            vehicle.CarType = carType;

            Console.Write("Podaj markę: ");
            vehicle.Maker = Console.ReadLine();

            Console.Write("Podaj model: ");
            vehicle.Model = Console.ReadLine();

            Console.Write("Podaj rodzaj paliwa: ");
            vehicle.GasType = Console.ReadLine();

            vehicle.Capacity = ValidateInsertedInteger("Podaj pojemność silnika [cm^3]: ", "Błędny typ danych. Podaj pojemność silnika w centymetrach sześciennych.");

            return vehicle;
        }
        private void EditCar()
        {
            Console.WriteLine("Edycja pojazdu.");

            int vehicleID = 0;
            Vehicle? vehicle = null;
            bool vehicleFound = true;

            do
            {
                vehicleID = ValidateInsertedInteger("Podaj ID pojazdu: ",
                                                      "Błędna wartość. Zajrzyj do listy pojazdów i podaj poprawne ID.");
                vehicle = repository.GetVehicle(vehicleID);
                if (vehicle != null) vehicleFound = false;
                else
                {
                    ShowError("Podany ID pojazu nie istnieje!");
                }

            } while (vehicleFound);

            vehicle = GetCarData(vehicle);

            if(vehicle == null) return;

            repository.Edit(vehicleID, vehicle);
        }

        private void AddNewCar()
        {
            Console.WriteLine("Tworzenie nowego pojazdu.");
            Vehicle? vehicle = null;

            vehicle = GetCarData(vehicle);
            if (vehicle == null) return;

            repository.Add(vehicle);

        }

        private void ShowCars()
        {
            var carList = repository.GetAll();

            ConsoleTable
                .From(carList)
                .Write(Format.Default);
            Console.ReadKey();
        }

        private Vehicle? CheckVehicleID()
        {
            Vehicle? vehicle = null;
            bool vehicleFound = true;
            do
            {
                int vehicleID = ValidateInsertedInteger("Podaj ID pojazdu: ",
                                                      "Błędna wartość. Zajrzyj do listy pojazdów i podaj poprawne ID.");
                vehicle = repository.GetVehicle(vehicleID);
                if (vehicle != null) vehicleFound = false;
                else
                {
                    ShowError("Podany ID pojazu nie istnieje!");
                }

            } while (vehicleFound);

            return vehicle;
        }

        private int ValidateInsertedInteger(string message, string errorMessage, int minRange = 0, int maxRange = 0)
        {
            bool isDataCorrect = false;
            int value = 0;
            do
            {
                Console.Write(message);
                if (int.TryParse(Console.ReadLine(), out value))
                {
                    
                    if (minRange != maxRange && (value < minRange || value > maxRange) )
                    {
                        ShowError(errorMessage);
                    }
                    else
                    {
                        isDataCorrect = true;
                    }
                }
                else
                {
                    ShowError(errorMessage);
                }
            } while (!isDataCorrect);

            return value;
        }

        private void ShowMenu()
        {
            Console.Clear();
            Console.WriteLine("CAR MANAGER 2.0");
            Console.WriteLine("  1. Lista aut");
            Console.WriteLine("  2. Dodaj auto");
            Console.WriteLine("  3. Edytuj auto");
            Console.WriteLine("  4. Usuń auto");
            Console.WriteLine("  5. Wypożycz");
            Console.WriteLine("  6. Zwróć");
            Console.WriteLine("  0. Zakończ");
        }

    }
}
