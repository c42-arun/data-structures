using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Recursion
{
    // https://www.educative.io/collection/page/10370001/760001/1210002
    public class PowerFunction
    {
        public double Power(double num, int exp)
        {
            // base case
            if (exp == 0)
                return 1;

            // recursive case: exp is negative
            if (exp < 0)
            {
                int positiveExp = exp * -1;

                return (1 / Power(num, positiveExp));
            }

            // recursive case: exp is odd
            if (num % 2 != 0)
            {
                double numMinus1Power = Power(num, exp - 1);
                return num * numMinus1Power;
            }

            // recursive case: exp is even
            double y = Power(num, exp / 2);

            return y * y;
        }
    }
}
