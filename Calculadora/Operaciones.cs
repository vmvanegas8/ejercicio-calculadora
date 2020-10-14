using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculadora
{
    class Operaciones
    {

        public double Suma(double numA, double numB)
        {
            return numA + numB;
        }

        public double Resta(double numA, double numB)
        {
            return numA - numB;
        }

        public double Multi(double numA, double numB)
        {
            return numA * numB;
        }

        public double Divi(double numA, double numB)
        {
            return numA / numB;
        }

        public double Module(double numA, double numB)
        {
            return numA % numB;
        }

    }
}
