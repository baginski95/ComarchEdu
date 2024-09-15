namespace ComarchBootcampKonsola.App
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Witaj, jak masz na imię?");
            //var name = Console.ReadLine();
            //Console.WriteLine("Ile masz lat?");
            //string sAge = Console.ReadLine();
            ////int age = int.TryParse(sAge);
            //if (int.TryParse(sAge, out int result))
            //{
            //    Console.WriteLine($"Witaj {name}, masz {result} lat.");
            //    //Console.WriteLine("Witaj {0}, masz {1} lat.", name, result);
            //    int dateOfBirth = DateTime.Now.Year - result;
            //    Console.WriteLine($"Urodziłeś się w {dateOfBirth} roku.");
            //}
            //else
            //{
            //    Console.WriteLine($"Witaj {name}, masz nietypowy wiek:  {sAge} lat.");
            //    Console.WriteLine($"Urodziłeś się w niepoliczalnym roku.");
            //}

            Console.WriteLine("Bubble sort");
            Console.WriteLine("Podaj elementy tablicy oddzielone przerwą");
            string line = Console.ReadLine();
            string[] elements = line.Split([' ', ',',  ';'], StringSplitOptions.RemoveEmptyEntries);
            int[] tab = new int[elements.Length];

            //Conversion to int
            for (int i = 0; i < tab.Length; i++)
            {
                tab[i] = int.Parse(elements[i]);
            }


            //Bubble sort
            for(int i = 0;i < tab.Length - 1;i++)
            {
                for(int j = 0;j < tab.Length - 1;j++)
                {
                    if (tab[j] > tab[j+1])
                    {
                        int tmp = tab[j];
                        tab[j] = tab[j+1];
                        tab[j+1] = tmp;
                    }
                }
            }

            Console.WriteLine("Sorted table: ");
            foreach(int item in tab)
            {
                Console.Write(item + " ");
            }
        }
    }
}
