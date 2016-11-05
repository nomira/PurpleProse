using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoryPlanner
{
    public class Country : Location
    {
        public Country(string name, string desc, string hist, string imageFile) : base(name, desc, hist, imageFile) {

        }
        private Region regio;
        public Region Regio
        {
            get { return regio; }
            set { regio = value; }
        }

        private string _ocracy; //Ex: Theocracy Democracy
        public string _Ocracy
        {
            get { return _ocracy; }
            set { _ocracy = value; }
        }
        private string values; //Ex: Totalatarian, Left_wing right_wing
        public string Values
        {
            get { return values; }
            set { values = value; }
        }
        private string economy; //Ex: Communist, Market; Free Restricted Controled
        public string Economy
        {
            get { return economy; }
            set { economy = value; }
        }
    }
}
