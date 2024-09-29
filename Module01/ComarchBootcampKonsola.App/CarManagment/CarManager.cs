using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComarchBootcampKonsola.App.CarManagment
{
    public class CarManager
    {
        public CarManager() { }

        public void Start()
        {
            int choice;
            do
            {
                ShowMenu();

                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    switch(choice)
                    {
                        default:
                            break;
                    }
                }
            }
            while (choice != 0);
            Console.WriteLine("Koniec programu.");
        }

        private void ShowMenu()
        {
            Console.Clear();
            Console.WriteLine("CAR MANAGER 1.0");
            Console.WriteLine("  1. Lista aut");
            Console.WriteLine("  2. Dodaj auto");
            Console.WriteLine("  3. Usuń auto");
            Console.WriteLine("  0. Zakończ");
        }
    }
}
