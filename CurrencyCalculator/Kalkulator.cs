using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyCalculator
{
    class Kalkulator
    {
        public static string Calc(string rate, string cash)
        {
            string All = (Convert.ToDecimal(cash) * Convert.ToDecimal(rate)).ToString();
            return All;
        }
    }
}
