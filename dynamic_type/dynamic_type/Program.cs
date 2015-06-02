using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dynamic_type
{
    class Program
    {
        private static void M(Int32 n) { Console.WriteLine("M Int32:" + n); Console.ReadLine(); }
        private static void M(string n) { Console.WriteLine("M string:" + n); Console.ReadLine(); }
        static void Main(string[] args)
        {
            dynamic value;
            for (Int32 demo = 0; demo < 2; demo++)
            {
                value = (demo == 0) ? (dynamic)5 : (dynamic)"А";
                value = value + value;
                M(value);
                
            }
        }
    }

}
