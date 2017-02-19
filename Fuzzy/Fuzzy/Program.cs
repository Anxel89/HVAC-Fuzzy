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
            //input memebership function creation
            Region very_cold = create_region("very cold", 0.0, 0.0, 60.0, 1.0, 65.0, 0.0, true, false);
            Region cold = create_region("cold",60.0, 0.0, 65.0, 1.0, 70.0, 0.0, false, false);
            Region warm = create_region("warm",65.0, 0.0, 70.0, 1.0, 75.0, 0.0, false, false);
            Region hot = create_region("hot",70.0, 0.0, 75.0, 1.0, 80.0, 0.0, false, false);
            Region very_hot = create_region("very hot",75.0, 0.0, 80.0, 1.0, 0.0, 0.0, false, true);
            MembershipFunction temp = new MembershipFunction(very_cold, cold, warm, hot, very_hot);
            // output memebership function creation
            string[] regions = { "hi cool", "cool", "no change", "heat", "hi heat" };
            Region hicool = create_region("hi cool", 0.0, 0.0, -100.0, 1.0, -50.0, 0.0, true, false);
            Region cool = create_region("cool", -50.25, 0.0, -50.0, 1.0, -1.0, 0.0, false, false);
            Region no_change = create_region("no change", -1.0, 0.0, 0.0, 1.0, 1.0, 0.0, false, false);
            Region heat = create_region("heat", 1.0, 0.0, 50.0, 1.0, 50.25, 0.0, false, false);
            Region hiheat = create_region("hi heat", 50.0, 0.0, 100.0, 1.0, 0.0, 0.0, false, true);
            MembershipFunction heat_cool = new MembershipFunction(hicool, cool, no_change, heat, hiheat);


            // get user input

            bool cont = true;
            while (cont) {
                double current_temp = 0;
                double target_temp = 0;
                bool current_flag = false;
                bool target_flag = false;
               

                while (!current_flag)
                {
                    Console.WriteLine("Please Enter a current temperature (ex. 75.0)");
                    current_flag = Double.TryParse(Console.ReadLine(), out current_temp);
                }

                while (!target_flag)
                {
                    Console.WriteLine("Please Enter a target temperature (ex. 75.0)");
                    target_flag = Double.TryParse(Console.ReadLine(), out target_temp);
                }

                FuzzySet current_fuzz = new FuzzySet();
                FuzzySet target_fuzz = new FuzzySet();
                current_fuzz = temp.EvalMembership(current_temp, "y");
                target_fuzz = temp.EvalMembership(target_temp, "y");
                FuzzySet output = new FuzzySet();
                output = output.BaseRules(target_fuzz, current_fuzz);
                string result = heat_cool.defuzzify(output);
                Console.WriteLine(result);
                Console.WriteLine("would you like to run another execution y/n");
                char cont_char = Convert.ToChar(Console.ReadLine());
                if(cont_char == 'y')
                {
                    cont = true;
                }
                else
                {
                    cont = false;
                }
            }
            
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
