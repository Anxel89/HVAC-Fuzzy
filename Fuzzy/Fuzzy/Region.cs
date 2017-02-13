using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fuzzy
{
    class Region
    {
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

        public Region()
        {
            point leftbound = new point();
            this.leftbound = leftbound;
            point rightbound = new point();
            this.rightbound = rightbound;
            point peak = new point();
            this.peak = peak;

        }

        public Region(point leftbound, point rightbound , point peak)
        {
            this.leftbound = leftbound;
            this.rightbound = rightbound;
            this.peak = peak;
        }

    
        

    }
}
