using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fuzzy
{

    class Program
    {
        static void Main(string[] args)
        {
            // this is how we get the value of a points degree of membership
            point one = new point(5.0, 1.0);
            point two = new point(10.0, 0);
            point value = new point();
            value.liner_interpolation(one, two, 9.84);
            Console.WriteLine(value.X);
            Console.ReadKey();

        }

       
    }
}
