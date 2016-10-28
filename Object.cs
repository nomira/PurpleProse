using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoryPlanner
{
    abstract class Object  //This will be a parent class to all objects
    {
        public enum relationshipTypes {Null, Father, Mother, Sibling, Friend, Enemy}; //Types of relationships... let me know if we need more
        protected string name, description, history, imageFile;
        protected List<relationship> myRelationships; //List of this objects relationships
        public Object(string name, string desc, string hist, string imageFile) { //Constructor to assign values to name, desc, and hist
            this.name = name;
            this.description = desc;
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
        public void establishRelationship(Object relateMe, relationshipTypes myType) { //Create a new relationship
            relationship newRelationship = new relationship();
            newRelationship.myRelationship = relateMe;
            newRelationship.type = myType;
            myRelationships.Add(newRelationship);
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
