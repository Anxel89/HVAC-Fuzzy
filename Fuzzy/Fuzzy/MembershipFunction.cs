using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fuzzy
{
    class MembershipFunction
    {
        Region[] regions;

        public Region[] Regions
        {
            get { return regions; }
            set { regions = value; }
        }

        public MembershipFunction()
        {


        }

        #region Overloads of MembershipFunction Constructors
        public MembershipFunction(Region one)
        {
            regions = new Region[1];
            regions[0] = one;
        }
        public MembershipFunction(Region one, Region two)
        {
            regions = new Region[2];
            regions[0] = one;
            regions[1] = two;
        }
        public MembershipFunction(Region one, Region two, Region three)
        {
            regions = new Region[3];
            regions[0] = one;
            regions[1] = two;
            regions[2] = three;
        }

        public MembershipFunction(Region one, Region two, Region three, Region four)
        {
            regions = new Region[4];
            regions[0] = one;
            regions[1] = two;
            regions[2] = three;
            regions[3] = four;
        }
        #endregion
        public MembershipFunction(Region one, Region two, Region three, Region four, Region five)
        {
            regions = new Region[5];
            this.regions[0] = one;
            this.regions[1] = two;
            this.regions[2] = three;
            this.regions[3] = four;
            this.regions[4] = five;
        }

        public FuzzySet EvalMembership(double temp)
        {
            FuzzySet result = new FuzzySet();
            for (int i = 0; i < regions.Length; i++)
            {
               if(regions[i].Leftmost == true && regions[i].Rightmost == false)
                {
                    // is the leftmost region




                }

               else if(regions[i].Rightmost == true && regions[i].Leftmost == false)
                {
                    // is the rightmost region

                }

               else
                {
                    // is a middle region
                }
            }
            return result;
        }

        //public point liner_interpolation(point a, point b, double x)
        //{

        //    // (x0,y0) is always the first point passed in;
        //    point result = new point();
        //    double slope = ((b.y - a.y) / (b.x - a.x));
        //    double second_term = x - a.x;
        //    double tmp = a.y + second_term * slope;
        //    result.X = x;
        //    result.Y = tmp;
        //    return result;

        //}


    }
}
