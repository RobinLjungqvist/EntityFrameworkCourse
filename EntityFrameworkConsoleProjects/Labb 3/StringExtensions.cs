using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb_3
{
    public static class StringExtensions
    {
        public static float ToFloat(this string input)
        {
            float outputFloat = float.Parse(input);
            return outputFloat;
            
        }
    }
}
