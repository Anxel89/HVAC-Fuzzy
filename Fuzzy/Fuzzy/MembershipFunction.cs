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
            regions[0] = one;
        }
        public MembershipFunction(Region one, Region two)
        {
            regions[0] = one;
            regions[1] = two;
        }
        public MembershipFunction(Region one, Region two, Region three)
        {
            regions[0] = one;
            regions[1] = two;
            regions[2] = three;
        }

        public MembershipFunction(Region one, Region two, Region three, Region four)
        {
            regions[0] = one;
            regions[1] = two;
            regions[2] = three;
            regions[3] = four;
        }
        #endregion
        public MembershipFunction(Region one, Region two, Region three, Region four, Region five)
        {
            regions[0] = one;
            regions[1] = two;
            regions[2] = three;
            regions[3] = four;
            regions[4] = five;
        }



    }
}
