using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoryPlanner
{
    class Planet //Will inheret from Location class
    {
        public Planet(int pop, biome land, technologyLevel developement, string other = "") {
            population = pop;
            myLevel = developement;
            myLand = land;
            if (myLevel == technologyLevel.Other) otherLevel = other;
        }
        public enum technologyLevel {Primitive, PreWarp, Modern, Spacefaring, PreIndustrial, Other}; //Not sure if we need more
        string otherLevel; //If the user chose other
        public enum biome {Taiga, Grassland, Chaparral, Desert, Rainforest, Alpine};
        private long population;
        private technologyLevel myLevel;
        private biome myLand;
        public long populations { //Set and get population
            get { return population; }
            set { population = value; }

        }
        public void setLevel(technologyLevel theLevel, string other = "") { //Set the technology level
            theLevel = myLevel;
            if (myLevel == technologyLevel.Other) otherLevel = other;
        }
        public string getLevel() { //Get the technology level
            if (myLevel == technologyLevel.Other) return otherLevel;
            return myLevel.ToString();
        }
        public biome theBiome {
            get { return myLand; }
            set { myLand = value; }
        }
    }
}
