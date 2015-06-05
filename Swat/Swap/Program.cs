using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3
{
    class Program
    {
        static void Swap<T>(ref T a, ref T b)
        {
            Console.WriteLine("Методу Swap() передано {0}",
                typeof(T));
            T temp;
            temp = a;
            a = b;
            b = temp;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("***** Забавы с обобщениями *****\n");

            // Обмен между двумя целыми. 
            int a = 10, b = 90;
            Console.WriteLine("До обмена: {0}, {1}", a, b);
            Swap<int>(ref a, ref b);
            Console.WriteLine("После обмена: {0}, {1}", a, b);
            Console.WriteLine();

            // Обмен между двумя строками. 
            string s1 = "Hello", s2 = "There";
            Console.WriteLine("До обмена: {0} {1}!", s1, s2);
            Swap<string>(ref s1, ref s2);
            Console.WriteLine("После обмена: {0} {1}!", s1, s2);
            Console.ReadLine();
        }
    }
}

