using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComarchBootcampKonsola.App.CarManagment.Model
{
    internal class Car : Vehicle
    {
        public override void Refuel(int count)
        {
            throw new NotImplementedException();
        }
        public override void Borrow(string borrower)
        {
            Console.WriteLine("Metoda Car");
        }
    }
}
