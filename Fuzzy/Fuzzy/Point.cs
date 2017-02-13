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

            public double X
        {
                set { x = value; }
                get { return x; }
        }
            public double Y {
                set { y = value; }
                get { return y; }
        }

            public point()
            {
                x = 0.0;
                y = 0.0;
            }
            public point(double x, double y)
            {
                this.x = x;
                this.y = y;
            }

         public void liner_interpolation(point a, point b, double x)
        {
            // (x0,y0) is always the first point passed in;
            double slope = ((b.y - a.y) / (b.x - a.x));        
            double second_term = x - a.x;          
            double tmp = a.y + second_term * slope;
            this.x = x;
            this.y = tmp;
            
        }

    }
    }

