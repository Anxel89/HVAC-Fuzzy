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
            name = "";
            this.data.Clear();
        }

        public FuzzySet(string[] region_name, double [] dom, string name)
        {
            // create object with data;
            this.name = name;
            // if the two array passed in are equal in length fill the dictionary
            try { 
                foreach (string item in region_name)
                {
                    data.Add(region_name[Convert.ToInt32(item)], dom[Convert.ToInt32(item)]);
                }
            }
            catch(IndexOutOfRangeException e)
            {
                throw new Exception("data arrays for fuzzyset not same lenght",e);
            }         
            }

        public string defuzzify(FuzzySet data, string type = "max")
        {
            type.ToLower();
            string result = "";
            if (type == "max")
            {
                // logic for picking maximum value in the set
            }
            else if(type == "gravity")
            {
                // logic for doing center of gravity method
            }
            
            else
            {
                // logic for doing center of area
            }
            return result;
        }

        public string BaseRules(string target_tmp, string current_tmp)
        {
            string result = "";
            current_tmp.ToLower();
            target_tmp.ToLower();


//+---------------------------------------------------------------------+
//| target Temp | Knowledge Base                                        |
//+-----------------------+---------+---------+----------+--------------+
//| Current temp | Very Cold | Cold | Warm | Hot | Very Hot             |
//+---------------------------------------------------------------------+
//| Very Cold    | No Change | heat | heat | heat | heat                |
//+---------------------------------------------------------------------+
//| Cold         | cool | no change | heat | heat | heat                |
//+---------------------------------------------------------------------+
//| Warm        | cool | cool | No Change | heat | heat                 |
//+---------------------------------------------------------------------+
//| Hot         | cool | cool | cool | No Change | heat                 |
//+---------------------------------------------------------------------+
//| Very Hot    | cool | cool | cool | cool | No Change                 |
//+------------+----------+---------+---------+----------+--------------+









            if (current_tmp == target_tmp)
            {
                result = "no change";
            }         
            else if(current_tmp == "very cold" && target_tmp != "very cold")
            {
                result = "heat";
            }
            else if(current_tmp == "very hot" && target_tmp != "very hot")
            {
                result = "cool";
            }
            else if(current_tmp == "hot" && (target_tmp != "hot" || target_tmp != "very hot"))
            {
                result = "cool";   
            }
            else if(current_tmp == "hot" && target_tmp == "very_hot")
            {
                result = "heat";
            }
            else if(current_tmp == "cold" && (target_tmp != "very cold" || target_tmp != "cold"))
            {
                result = "heat";
            }
            else if(current_tmp == "cold" && target_tmp == "very cold")
            {
                result = "cool";
            }
            else if(current_tmp == "warm"  && (target_tmp == "very cold" || target_tmp == "cold"))
            {
                result = "cool";
            }
            else
            {
                // fills in the rule where current tmp is equal to warm and target is hot or very hot
                result = "hot";
            }
         



            return result;
        }
     }
     }

    

