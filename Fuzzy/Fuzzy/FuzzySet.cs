using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fuzzy
{
    class FuzzySet
    {
        Dictionary<string, double> data;
        string name;       


        public Dictionary<string,double> Data
        {
          get { return data; }
          set { data = value; }
        }   

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public FuzzySet()
        {
            // create a brand new object with no data
            this.data = new Dictionary<string, double>();
            data.Add("default", 0.0);
            name = "";
            string[] region_name = new string[0];
            double[] region_dom = new double[0];
           
        }

        public FuzzySet(string[] region, double[] dom, string name)
        {
            // create object with data;
            this.data = new Dictionary<string, double>(50);
            this.name = name;
            if (dom.Length == region.Length)
            {
             
                for (int i = 0; i < region.Length; i++)
                {
                   
                    data.Add(region[i], dom[i]);
                }
            }
        }   
      

    

        public FuzzySet BaseRules(FuzzySet target_tmp, FuzzySet current_tmp)
        {

            List<double> HiCool = new List<double>();
            List<double> Cool = new List<double>();
            List<double> NoChange = new List<double>();
            List<double> Heat = new List<double>();
            List<double> HiHeat = new List<double>();
            HiCool.Add(0.0);
            Cool.Add(0.0);
            NoChange.Add(0.0);
            Heat.Add(0.0);
            HiHeat.Add(0.0);


            ////////////+---------------------------------------------------------------------+
            ////////////| target Temp | Knowledge Base                                        |
            ////////////+-----------------------+---------+---------+----------+--------------+
            ////////////| Current temp | Very Cold | Cold | Warm | Hot | Very Hot             |
            ////////////+---------------------------------------------------------------------+
            ////////////| Very Cold    | No Change | heat | hi-heat | hi-heat | hi-heat       |
            ////////////+---------------------------------------------------------------------+
            ////////////| Cold         | cool | no change | heat | hi-heat | hi-heat          |
            ////////////+---------------------------------------------------------------------+
            ////////////| Warm        | hi-cool | cool | No Change | heat | hi-heat           |
            ////////////+---------------------------------------------------------------------+
            ////////////| Hot         | hi-cool | hi-cool | cool | No Change | heat           |
            ////////////+---------------------------------------------------------------------+
            ////////////| Very Hot    | hi-cool | hi-cool | hi-cool | cool | No Change        |
            ////////////+------------+----------+---------+---------+----------+--------------+


            // no_change senerios
            if (target_tmp.Data["very cold"] != 0.0 && current_tmp.Data["very cold"] != 0.0)
            {
                double tmp = Math.Min(target_tmp.Data["very cold"], current_tmp.Data["very cold"]);
                NoChange.Add(tmp);
            }

            else if (target_tmp.Data["cold"] != 0.0 && current_tmp.Data["cold"] != 0.0)
            {
                double tmp = Math.Min(target_tmp.Data["cold"], current_tmp.Data["cold"]);
                NoChange.Add(tmp);
            }

            else if (target_tmp.Data["warm"] != 0.0 && current_tmp.Data["warm"] != 0.0)
            {
                double tmp = Math.Min(target_tmp.Data["warm"], current_tmp.Data["warm"]);
                NoChange.Add(tmp);
            }
            else if (target_tmp.Data["hot"] != 0.0 && current_tmp.Data["hot"] != 0.0)
            {
                double tmp = Math.Min(target_tmp.Data["hot"], current_tmp.Data["hot"]);
                NoChange.Add(tmp);
            }
            else if (target_tmp.Data["very hot"] != 0.0 && current_tmp.Data["very hot"] != 0.0)
            {
                double tmp = Math.Min(target_tmp.Data["very hot"], current_tmp.Data["very hot"]);
                NoChange.Add(tmp);
            }

            else if (target_tmp.Data["very cold"] != 0.0 && current_tmp.Data["cold"] != 0.0)
            {
                double tmp = Math.Min(target_tmp.Data["very cold"], current_tmp.Data["cold"]);
                Cool.Add(tmp);
            }

            else if (target_tmp.Data["very cold"] != 0.0 && (current_tmp.Data["warm"] != 0.0 || current_tmp.Data["hot"] != 0.0 || current_tmp.Data["very hot"] != 0.0))
            {
                double tmp = Math.Min(target_tmp.Data["very cold"], current_tmp.Data["warm"]);
                double tmp1 = Math.Min(target_tmp.Data["very cold"], current_tmp.Data["hot"]);
                double tmp2 = Math.Min(target_tmp.Data["very cold"], current_tmp.Data["very hot"]);
                double value = Math.Max(tmp1, tmp);
                double value2 = Math.Max(value, tmp2);
                HiCool.Add(value2);
            }

            else if (target_tmp.Data["cold"] != 0.0 && current_tmp.Data["very cold"] != 0.0)
            {
                double tmp = Math.Min(target_tmp.Data["cold"], current_tmp.Data["very_cold"]);
                Heat.Add(tmp);
            }
            else if (target_tmp.Data["cold"] != 0.0 && current_tmp.Data["warm"] != 0.0)
            {
                double tmp = Math.Min(target_tmp.Data["cold"], current_tmp.Data["warm"]);
                Cool.Add(tmp);
            }
            else if (target_tmp.Data["cold"] != 0.0 && current_tmp.Data["hot"] != 0.0 || current_tmp.Data["very hot"] != 0.0)
            {
                double tmp = Math.Min(target_tmp.Data["cold"], current_tmp.Data["hot"]);
                double tmp2 = Math.Min(target_tmp.Data["cold"], current_tmp.Data["very hot"]);
                double value = Math.Max(tmp, tmp2);
                HiCool.Add(value);

            }
            else if(target_tmp.Data["warm"] != 0.0 && current_tmp.Data["very cold"] != 0.0)
            {
                double tmp = Math.Min(target_tmp.Data["warm"], current_tmp.Data["very_cold"]);
                HiHeat.Add(tmp);

            }

            else if(target_tmp.Data["warm"] != 0.0 && current_tmp.Data["cold"] != 0.0)
            {
                double tmp = Math.Min(target_tmp.Data["warm"], current_tmp.Data["cold"]);
                Heat.Add(tmp);
            }

            else if(target_tmp.Data["warm"] != 0.0 && current_tmp.Data["hot"] != 0.0)
            {
                double tmp = Math.Min(target_tmp.Data["warm"], current_tmp.Data["hot"]);
                Cool.Add(tmp);

            }
            else if(target_tmp.Data["warm"] != 0.0 && current_tmp.Data["very hot"] != 0.0)
            {
                double tmp = Math.Min(target_tmp.Data["warm"], current_tmp.Data["very hot"]);
                HiCool.Add(tmp);
            }
            else if(target_tmp.Data["hot"] != 0.0 && (current_tmp.Data["very cold"] != 0.0 || current_tmp.Data["cold"] != 0.0))
            {
                double tmp = Math.Min(target_tmp.Data["hot"], current_tmp.Data["very cold"]);
                double tmp2 = Math.Min(target_tmp.Data["hot"], current_tmp.Data["cold"]);
                double value = Math.Max(tmp, tmp2);
                HiHeat.Add(value);
            }
            else if(target_tmp.Data["hot"] != 0.0 && current_tmp.Data["warm"] != 0.0)
            {
                double tmp = Math.Min(target_tmp.Data["hot"], current_tmp.Data["warm"]);
                Heat.Add(tmp);
            }
            else if (target_tmp.Data["hot"] != 0.0 && current_tmp.Data["very hot"] != 0.0)
            {
                double tmp = Math.Min(target_tmp.Data["hot"], current_tmp.Data["very hot"]);
                Cool.Add(tmp);
            }
            else if(target_tmp.Data["very hot"] != 0.0 && (current_tmp.Data["very cold"] != 0.0 || current_tmp.Data["cold"] != 0.0 || current_tmp.Data["warm"] != 0.0))
            {
                double tmp = Math.Min(target_tmp.Data["very hot"], current_tmp.Data["very cold"]);
                double tmp2 = Math.Min(target_tmp.Data["very hot"], current_tmp.Data["cold"]);
                double tmp3 = Math.Min(target_tmp.Data["very hot"], current_tmp.Data["warm"]);
                double value = Math.Max(tmp, tmp2);
                double value2 = Math.Max(tmp3, value);
                HiHeat.Add(value2);
            }
            else if(target_tmp.Data["very hot"] != 0.0 && current_tmp.Data["hot"] != 0.0)
            {
                double tmp = Math.Min(target_tmp.Data["very hot"], current_tmp.Data["hot"]);
                Heat.Add(tmp);
            }

            double max_hicool = 0.0;
            string[] regions = { "hi cool", "cool", "no change", "heat", "hi heat" };
            double[] dom = new double[5];
            foreach (double item in HiCool)
            {
                max_hicool = Math.Max(max_hicool, item);
            }
            dom[0] = max_hicool;
            double max_cool = 0.0;
            foreach (double item in Cool)
            {
                max_cool = Math.Max(max_cool, item);
            }
            dom[1] = max_cool;
            double no_change = 0.0;
            foreach (double item in NoChange)
            {
                no_change = Math.Max(no_change, item);
            }
            dom[2] = no_change;
            double max_heat = 0.0;
            foreach (double item in Heat)
            {
                max_heat = Math.Max(max_heat, item);
            }
            dom[3] = max_heat;
            double max_hiheat = 0.0;
            foreach (double item in HiHeat)
            {
                max_hiheat = Math.Max(max_hiheat, item);
            }
            dom[4] = max_hiheat;

            FuzzySet result = new FuzzySet(regions, dom, "output");
            return result;


        }


     }
     }

    

