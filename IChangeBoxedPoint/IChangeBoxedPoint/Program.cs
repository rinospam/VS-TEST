using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    interface IChangeBoxedPoint
    {
        void Change(Int32 x, Int32 y);
    }
    internal struct Point : IChangeBoxedPoint
    {
        private Int32 m_x, m_y;
        public Point(Int32 x, Int32 y)
        {
            m_x = x;
            m_y = y;
        }

        public void Change(Int32 x, Int32 y)
        {
            m_x = x;
            m_y = y;
        }
        public override string ToString()
        {
            return String.Format("({0},{1})", m_x.ToString(), m_y.ToString());
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Point p = new Point(1, 1);
            Console.WriteLine(p);

            p.Change(2, 2);
            Console.WriteLine(p);

            Object o = p;
            Console.WriteLine(o);

            ((Point)o).Change(3, 3);
            Console.WriteLine(o);

            ((IChangeBoxedPoint)p).Change(4, 4);
            Console.WriteLine(p);
            
            ((IChangeBoxedPoint)o).Change(5, 5);
            Console.WriteLine(o);

            Console.ReadLine();
        }
    }
}
