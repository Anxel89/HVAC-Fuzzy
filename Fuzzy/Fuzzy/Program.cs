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

            Region very_cold = create_region("very cold", 0.0, 0.0, 60.0, 1.0, 65.0, 0.0, true, false);
            Region cold = create_region("cold",60.0, 0.0, 65.0, 1.0, 60.0, 0.0, false, false);
            Region warm = create_region("warm",65.0, 0.0, 70.0, 1.0, 75.0, 0.0, false, false);
            Region hot = create_region("hot",70.0, 0.0, 75.0, 1.0, 80.0, 0.0, false, false);
            Region very_hot = create_region("very hot",75.0, 0.0, 80.0, 1.0, 0.0, 0.0, false, true);
            MembershipFunction temp = new MembershipFunction(very_cold, cold, warm, hot, very_hot);
            // this is how we get the value of a points degree of membership
            point two = new point(10.0, 0.0);
            point one = new point(5.0, 1.0);
            point value = new point();
            value = value.liner_interpolation(one, two, 9.84);
            Console.WriteLine(value.Y);
            Console.ReadKey();

        }

        static Region create_region(string name, double leftbound_x, double leftbound_y, double peak_x, double peak_y, double rightbound_x, double rightboud_y, bool leftmost, bool rightmost)
        {
            if (leftmost && !rightmost)
            {
                point peak = new point(peak_x, peak_y);
                point rightbound = new point(rightbound_x, rightboud_y);
                point leftbound = new point();
                Region result = new Region(name,leftbound, rightbound, peak, false, true);
                return result;

            }
            else if (rightmost && !leftmost)
            {
                point peak = new point(peak_x, peak_y);
                point rightbound = new point();
                point leftbound = new point(leftbound_x, leftbound_y);
                Region result = new Region(name,leftbound, rightbound, peak, true, false);
                return result;
            }
            else
            {
                point peak = new point(peak_x, peak_y);
                point rightbound = new point(rightbound_x, rightboud_y);
                point leftbound = new point(leftbound_x, leftbound_y);
                Region result = new Region(name,leftbound, rightbound, peak, false, false);
                return result;
            }

        }

    
    }
}
