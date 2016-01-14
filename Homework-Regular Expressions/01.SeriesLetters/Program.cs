using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _05.Regular_Expressions
{
    class Program
    {
        static void Main()
        {
            var regex = new Regex("(.)\\1+");
            var str = Console.ReadLine();

            Console.WriteLine(regex.Replace(str, "$1"));
        }
    }
}

