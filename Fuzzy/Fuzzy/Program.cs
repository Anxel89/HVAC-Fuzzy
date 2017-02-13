using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fuzzy
{
    public class point
    {
        public double x,y;

        public point(double x, double y){
            this.x = x;
            this.y = y;
            }
      
    }
    class Program
    {
        static void Main(string[] args)
        {
            // this is how we get the value of a points degree of membership
            point one = new point(5.0, 1.0);
            point two = new point(10.0, 0);
            double value = liner_interpolation(one, two, 9.84);
            Console.WriteLine(value);
            Console.ReadKey();

        }

        static public double liner_interpolation(point a, point b, double x)
        {
            double slope = ((b.y - a.y) / (b.x - a.x));
            Console.WriteLine("Slope is :" + slope);
            double second_term = x - a.x;
            Console.WriteLine("Second Term is: " + second_term);
            double tmp = a.y + second_term * slope;            
            return tmp;
        }
    }
}
