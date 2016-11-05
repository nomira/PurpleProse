using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace StoryPlanner
{
    public abstract class Object  //This will be a parent class to all objects
    {
        public enum relationshipTypes {Null, Father, Mother, Sibling, Friend, Enemy}; //Types of relationships... let me know if we need more
        protected string name, description, history, imageFile;
        protected List<relationship> myRelationships; //List of this objects relationships
        public Object(string name, string desc, string hist, string imageFile) { //Constructor to assign values to name, desc, and hist
            this.name = name;
            this.description = desc; //Desc, hist, and imageFile hold filenames with the extension
            this.history = hist;
            this.imageFile = imageFile;
            myRelationships = new List<relationship>();
        }
        protected struct relationship { //A relationship.  Including the type of relationship and who it is with.
            public relationshipTypes type;
            public Object myRelationship;
        }

        public string getName() { //Returns the name of the object
            return name;
        }
        public string getDescFile() { //Gets the file name that contains the description of the object
            return description;
        }
        public string getHistFile() { //Gets the file name that contains the history of the object
            return history;
        }
        public string getImageFile() { //Gets the file name that contains the image of the object
            return imageFile;
        }
        public void changeName(string newName) {  //Change the name of this object
            name = newName;
        }
        public string[] getDescText() { //Returns the description text
            string[] myDesc = File.ReadAllLines(description);
            return myDesc;
        }
        public string[] getHistText() { //Returns the history text
            string[] myHist = File.ReadAllLines(history);
            return myHist;
        }
        public void writeHist(string[] hist) {
            File.WriteAllLines(history, hist); //Writes the history to the file
        }
        public void writeDesc(string[] desc) {
            File.WriteAllLines(description, desc); //Writes the description to the file.
        }
        public void establishRelationship(Object relateMe, relationshipTypes myType) { //Create a new relationship
            relationship newRelationship = new relationship();
            newRelationship.myRelationship = relateMe;
            newRelationship.type = myType;
            myRelationships.Add(newRelationship);
        }
        public void removeRelationship(Object removeMe) { //Removes a relationship
            foreach (relationship theRelationships in myRelationships) {
                if (theRelationships.myRelationship == removeMe) myRelationships.Remove(theRelationships);
            }
        }
        public relationshipTypes whatsTheRelationshipTo(Object myName) { //Return relationship type to given object
            foreach (relationship theRelationship in myRelationships) {
                if (theRelationship.myRelationship.getName() == myName.getName()) {
                    return theRelationship.type;
                }
            }
            return relationshipTypes.Null; //If the given object does not have a relationship to this object, return null type
        }
    }
}
