using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb_3
{
    public static class Helper
    {
        public static double StringToDouble(string input)
        {
            double output = double.Parse(input);       
            return output;
        }

    }
}
