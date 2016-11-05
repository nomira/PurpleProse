﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoryPlanner
{
    public class Building : Location
    {
        private int stories;
        private int rooms;
        private struct dimensions {
            public int x;
            public int y;
            public int z;
            public measurement myMeasurement;
        }
        private dimensions myDimensions;
        public Building(string name, string desc, string hist, string imageFile, int height, int width, int length, measurement usedMeasurement, int stories = 1, int rooms = 1) : base(name, desc, hist, imageFile)
        {
            this.stories = stories;
            this.rooms = rooms;
            myDimensions = new dimensions();
            setDimensions(height, width, length, usedMeasurement);
        }

        public string getnumStories {
            get {
                return stories.ToString();
            }
        }
        public bool setNumStories(string num) { //Returns true if input value is a number
            int myNum;
            bool isNum = int.TryParse(num, out myNum);
            if (isNum == true) stories = myNum;
            return isNum;
        }
        public void setDimensions(int height, int width, int length, measurement usedMeasurement) {
            myDimensions.x = width;
            myDimensions.y = length;
            myDimensions.z = height;
            myDimensions.myMeasurement = usedMeasurement;
        }
    }
}
