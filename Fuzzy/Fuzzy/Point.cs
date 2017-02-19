using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fuzzy
{
   
        public class point
        {
            private double x, y;
            private string region_in;

            public double X
             {
                set { x = value; }
                get { return x; }
            }
            public double Y
            {
                set { y = value; }
                get { return y; }
            }
            public string RegionIn
             {
            set { region_in = value; }
            get { return region_in; }

             }



            public point()
            {
                x = 0.0;
                y = 0.0;
            }
            public point(double x, double y, string region_in = "")
            {
                this.x = x;
                this.y = y;
                this.region_in = region_in;
            }

         public point liner_interpolation(point a, point b, double x,string tofind)
        {

            // (x0,y0) is always the first point passed in;
            point result = new point();
            if (tofind == "y")
            {
                double slope = ((b.Y - a.Y) / (b.X - a.X));
                double second_term = x - a.X;
                double tmp = a.y + second_term * slope;
                result.X = x;
                result.Y = tmp;
                return result;
            }
            else
            {
                double slope = ((b.X - a.X) / (b.Y - a.Y));
                double second_term = x - a.Y;
                double tmp = a.X + second_term * slope;
                result.X = tmp;
                result.Y = x;
                return result;
            }
            
        }

    }
    }

