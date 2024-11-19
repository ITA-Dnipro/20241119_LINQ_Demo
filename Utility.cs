using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20241119_LINQ_Demo
{
    public static class Utility
    {
        public static int Sqr(this int number)
        {
            return number * number;
        }

        public static IEnumerable<double> DoDouble(this IEnumerable<double> source)
        {
            foreach (double d in source) 
            {
                yield return d;
                yield return d;
            }
        }
    }
}
