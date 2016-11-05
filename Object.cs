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
            this.description = desc; //desc, hist, and imageFile hold filenames with extension
            this.history = hist;
            this.imageFile = imageFile;
            myRelationships = new List<relationship>();
        }
        protected struct relationship { //A relationship.  Including the type of relationship and who it is with.
            public relationshipTypes type;
            public Object myRelationship;
        }

        public string Name { //Gets and Sets the name of the object
            get {
                return name;
            }
            set {
                name = value;
            }
        }
        public string DescFile { //Gets and Sets the file name that contains the description of the object
            get
            {
                return description;
            }
            set {
                description = value;
            }
        }
        public string Hist { //Gets and sets the file name that contains the history of the object
            get
            {
                return history;
            }
            set {
                history = value;
            }
        }
        public string ImageFile{ //Gets and sets the file name that contains the image of the object
            get
            {
                return imageFile;
            }
            set {
                imageFile = value;
            }
        }
        public string[] DescText { //Gets and Sets the description text
            get
            {
                string[] myDesc = File.ReadAllLines(description);
                return myDesc;
            }
            set {
                File.WriteAllLines(description, value);
            }
        }
        public string[] HistText { //Gets and Sets the history text
            get
            {
                string[] myHist = File.ReadAllLines(history);
                return myHist;
            }
            set {
                File.WriteAllLines(history, value); //Writes the history to the file
            }
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
