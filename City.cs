using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoryPlanner
{
    class City
    {
        protected int myPopulation; //Population of the town
        public enum size { XSmall, Small, Medium, Large, XLarge }; //Size of the town, this might need to go in the parent class
        protected size mySize;
        public City(int pop, size theSize)
        {
            myPopulation = pop;
            mySize = theSize;
        }
        public int population
        { //Get and set the population
            get
            {
                return myPopulation;
            }
            set
            {
                myPopulation = value;
            }
        }
        public size theSize
        { //Get and set the size of the town/City
            get
            {
                return mySize;
            }
            set
            {
                mySize = value;
            }
        }
    }
}
