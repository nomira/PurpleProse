using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace StoryPlanner
{
    class room
    {
        public enum measurement { Inches, Centimeters, Feet, Meters, Yard, Lightyear };  //Should probably go in the location class
        private struct dimensions {
            public double x;
            public double y;
            public measurement usedMeasurement;
        }
        dimensions myRoom;
        private string myDescription;

        public room(double x, double y, measurement measuredIn, string descriptionFile) {
            myRoom = new dimensions();
            myRoom.x = x;
            myRoom.y = y;
            myRoom.usedMeasurement = measuredIn;
            this.myDescription = descriptionFile;
        }

        public string[] description { //Get and set the description
            set {
                File.WriteAllLines(myDescription, value);
             }
            get {
                string[] theWords;
                theWords = File.ReadAllLines(myDescription);
                return theWords;
            }
        }
        public double[] getDimensions { //The first element in the array is x, the second is y
            set {
                myRoom.x = value[0];
                myRoom.y = value[1];
            }
            get {
                double[] myDim = new double[2];
                myDim[0] = myRoom.x;
                myDim[1] = myRoom.y;
                return myDim;
            }
        }
        public measurement measuringIn {
            set {
                myRoom.usedMeasurement = value;
            }
            get {
                return myRoom.usedMeasurement;
            }
        }
    }
}
