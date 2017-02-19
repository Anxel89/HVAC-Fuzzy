using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fuzzy
{
    class Region
    {
        string name;
        bool leftmost;
        bool rightmost;
        private point leftbound;
        private point rightbound;
        private point peak;


        public point Leftbound
        {
            get { return leftbound; }
            set { leftbound = value;}
        }

        public point Rightbound
        {
            get { return rightbound; }
            set { rightbound = value; }

        }

        public point Peak
        {
            get { return peak; }
            set { peak = value; }
        }

        public bool Leftmost
        {
            get { return leftmost; }
            set { leftmost = value; }
        }

        public bool Rightmost
        {
            get { return rightmost; }
            set { rightmost = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public Region()
        {
            point leftbound = new point();
            this.leftbound = leftbound;
            point rightbound = new point();
            this.rightbound = rightbound;
            point peak = new point();
            this.peak = peak;

        }

        public Region(string name, point leftbound, point rightbound , point peak, bool rightmost = false, bool leftmost = false)
        {
            this.name = name;
            this.leftbound = leftbound;
            this.rightbound = rightbound;
            this.peak = peak;
            this.leftmost = leftmost;
            this.rightmost = rightmost;
        }

    
        

    }
}
