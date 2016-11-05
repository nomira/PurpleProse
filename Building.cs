using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoryPlanner
{
    class Building
    {
        private int stories;
        private int rooms;
        //Should have dimensions... wait for parent class implementation
        public Building(int stories = 1, int rooms = 1) {
            this.stories = stories;
            this.rooms = rooms;
        }
    }
}
