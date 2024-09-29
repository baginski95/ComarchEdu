using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComarchBootcampKonsola.App
{
    internal class Calculator
    {
        public float Add(float x, float y)
        {
            return x + y;
        }

        public float Subtract(float x, float y)
        {
            return x - y;
        }

        public float Multiplication(float x, float y)
        {
            return x * y;
        }

        public float Divide(float x, float y)
        {
            return x / y;
        }

        public float Modulo(float x, float y)
        {
            return x % y;
        }
    }
}
