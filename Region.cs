using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoryPlanner
{
    public class Region : Location
    {
        public Region(string name, string desc, string hist, string imageFile) : base(name, desc, hist, imageFile)
        {

        }
        private string terrain;
        public string Terrain
        {
            get { return terrain; }
            set { terrain = value; }
        } //If we make getters and setters here, we are going to need to do the same for all other small strings
    }
}
