using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoryPlanner
{
    public class Location : Object
    {
        public enum measurement { Inches, Centimeters, Feet, Meters, Yard, Lightyear };
        private string map_file;
        public string Map_file
        {   //Gets the file name that contains the map
            get { return map_file; }
            set { map_file = value; }
        }
        public Location(string name, string desc, string hist, string imageFile) : base(name, desc, hist, imageFile) {
            
       }
            
        private string size;        //Ex: 125 Leagues squared.	We could trun this into it its own object of class Size{ uint value; units; dimensions; }
        public string Size
        {
            get { return size; }
            set { size = value; }
        }
    }
}
