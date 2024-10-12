using ComarchBootcampKonsola.App.CarManagment;
using System.Security.Cryptography.X509Certificates;

namespace ComarchBootcampKonsola.App
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            CarManager cm = new CarManager();

            ConsoleKeyInfo yesNo;
            do
            {
                cm.Start();
               
                Console.Clear();
                Console.Write("Czy na pewno chcesz zamknąć program? [T|n]");
                yesNo = Console.ReadKey();

            } while (yesNo.Key != ConsoleKey.T);

        }

        internal static void ShowError(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(msg);
            Console.ResetColor();
        }
    }
}
