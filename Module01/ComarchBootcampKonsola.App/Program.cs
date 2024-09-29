using ComarchBootcampKonsola.App.CarManagment;
using System.Security.Cryptography.X509Certificates;

namespace ComarchBootcampKonsola.App
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool stopProgram;
            do
            {
                stopProgram = true;
                Console.Clear();
                Console.Write("Wybierz operację matematyczną:\n 1. Dodawanie \n 2. Odejmowanie \n 3. Mnożenie \n 4. Dzielenie  \n 5. Modulo \n 6. Car Manager \n 0. Wyjście\n");
                string? selectedOperation = Console.ReadLine();
                
                Console.Write("Podaj pierwszą liczbę: ");
                float firstNumber = float.Parse(Console.ReadLine()!);
                Console.Write("Podaj drugą liczbę: ");
                float secondNumber = float.Parse(Console.ReadLine()!);

                Calculator calculator = new Calculator();
                float result;

                switch (selectedOperation)
                {
                    case "1":
                        Console.WriteLine("Dodawanie");
                        result = calculator.Add(firstNumber, secondNumber);
                        break;
                    case "2":
                        Console.WriteLine("Odejmowanie");
                        result = calculator.Subtract(firstNumber, secondNumber);
                        break;
                    case "3":
                        Console.WriteLine("Możenie");
                        result = calculator.Multiplication(firstNumber, secondNumber);
                        break;
                    case "4":
                        Console.WriteLine("Dzielenie");
                        if (secondNumber == 0)
                        {
                            Console.Clear();
                            Console.WriteLine("Nie można dzielić przez 0");
                            continue;
                        }
                        else
                        {
                            result = calculator.Divide(firstNumber, secondNumber);
                        }
                        break;
                    case "5":
                        Console.WriteLine("Modulo");
                        result = calculator.Modulo(firstNumber, secondNumber);
                        break;
                    case "6":
                        CarManager cm = new CarManager();
                        cm.Start();
                        result = 0;
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Nie wybrano żadnej z dostępnych operacji");
                        continue;
                }

                Console.WriteLine($"Wynik {result}");
                Console.WriteLine("Jeśli chcesz wykonać kolejną operację naciśnij T");
                string userDecision = Console.ReadLine();

                if (userDecision == null || userDecision.ToUpper() != "T")
                {
                    stopProgram = false;
                }
            } while (stopProgram);
        }
    }
}
