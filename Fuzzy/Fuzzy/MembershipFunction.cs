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

        public FuzzySet EvalMembership(double input, string tofind)
        {
            FuzzySet result = new FuzzySet();
            for (int i = 0; i < regions.Length; i++)
            {
               if(regions[i].Leftmost == true && regions[i].Rightmost == false)
                {
                    // is the leftmost region
                    if( input <= regions[i].Rightbound.X && input > regions[i].Peak.X)
                    {                        
                        point tmp = new point();
                        tmp = tmp.liner_interpolation(regions[i].Peak, regions[i].Rightbound, input, tofind);
                        result.Data.Add(regions[i].Name, tmp.Y);
                    }
                    else if(input <= regions[i].Peak.X)
                    {
                        result.Data.Add(regions[i].Name, 1.0);
                    }
                    else
                    {
                        result.Data.Add(regions[i].Name, 0.0);
                    }
                }

               else if(regions[i].Rightmost == true && regions[i].Leftmost == false)
                {
                    // is the rightmost region
                    if(input >= regions[i].Leftbound.X && input < regions[i].Peak.X)
                    {
                        point tmp = new point();
                        tmp = tmp.liner_interpolation(regions[i].Peak, regions[i].Leftbound, input, tofind);
                        result.Data.Add(regions[i].Name, tmp.Y);

                    }
                    else if(input >= regions[i].Peak.X)
                    {
                        result.Data.Add(regions[i].Name, 1.0);
                    }
                    else
                    {
                        result.Data.Add(regions[i].Name, 0.0);
                    }
                }

               else
                {
                    // middle region
                    if(input >= regions[i].Leftbound.X && input < regions[i].Peak.X)
                    {
                        point tmp = new point();
                        tmp = tmp.liner_interpolation(regions[i].Leftbound, regions[i].Peak, input, tofind);
                        result.Data.Add(regions[i].Name, tmp.Y);
                    }
                    else if(input >= regions[i].Peak.X && input <= regions[i].Rightbound.X)
                    {
                        point tmp = new point();
                        tmp = tmp.liner_interpolation(regions[i].Peak, regions[i].Rightbound, input, tofind);
                        result.Data.Add(regions[i].Name, tmp.Y);

                    }
                    else
                    {
                        result.Data.Add(regions[i].Name, 0.0);
                    }
                }
            }
            return result;
        }
        public string defuzzify(FuzzySet data, string type = "max")
        {
            type.ToLower();        
            if (type == "max")
            {
                double max = 0.0;
                string region = string.Empty;
                foreach (string key in data.Data.Keys)
                {

                    if (data.Data[key] != 0.0)
                    {
                        if (data.Data[key] > max)
                        {
                            max = data.Data[key];
                            region = key;

                        }
                    }
                }
                string[] regions = { "hi cool", "cool", "no change", "heat", "hi heat" };
                point value = new point();
                point value1 = new Fuzzy.point();
                if (region == regions[0])
                {
                    value = value.liner_interpolation(this.Regions[0].Peak, this.Regions[0].Leftbound, max, "x");
                    return "Output is: " + Math.Abs(value.X) + "% cooling";
                }

                else if(region == regions[1])
                {
                    value = value.liner_interpolation(this.Regions[1].Peak, this.Regions[1].Leftbound, max, "x");
                    value1 = value1.liner_interpolation(this.Regions[1].Peak, this.Regions[1].Rightbound, max, "x");
                    double output = (value.X + value1.X) / 2;
                    return "Output is: " + Math.Abs(output) + "% cooling";

                }
                else if (region == regions[2])
                {
                    value = value.liner_interpolation(this.Regions[2].Peak, this.Regions[2].Leftbound, max, "x");
                    value1 = value1.liner_interpolation(this.Regions[2].Peak, this.Regions[2].Rightbound, max, "x");
                    double output = (value.X + value1.X) / 2;
                    return "Output is: " + Math.Abs(output) + "% sytstem is off";

                }
                else if (region == regions[3])
                {
                    value = value.liner_interpolation(this.Regions[3].Peak, this.Regions[3].Leftbound, max, "x");
                    value1 = value1.liner_interpolation(this.Regions[3].Peak, this.Regions[3].Rightbound, max, "x");
                    double output = (value.X + value1.X) / 2;
                    return "Output is: " + Math.Abs(output) + "% heating";

                }
                else if (region == regions[4])
                {
                    value = value.liner_interpolation(this.Regions[4].Peak, this.Regions[4].Rightbound, max, "x");
                    return "Output is: " + Math.Abs(value.X) + "% heating";

                }
                else
                {
                    return string.Empty;
                }
            }
            else if (type == "gravity")
            {
                // logic for doing center of gravity method
                return string.Empty;
            }

            else
            {
                // logic for doing center of area
                return string.Empty;
            }

        }


    }
}
