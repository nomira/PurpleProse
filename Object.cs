using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
//INotifyPropertyChanging
//INotifyPropertyChanged

namespace StoryPlanner
{
	public class Object  //This will be a parent class to all objects
	{
		public enum relationshipTypes {Null, Father, Mother, Sibling, Friend, Enemy}; //Types of relationships... let me know if we need more
		public string Name { get; set; }
		protected string description, history, image;
		protected List<relationship> MyRelationships; //List of this objects relationships
		public static System.IO.FileNotFoundException InvalidTextFile;
		private static List<Object> BackupData;
		private static bool inTxn = false;
		
		public Object(Object Original) {
			Name = Original.Name;
			description = Original.description;
			image = Original.image;
			MyRelationships = Original.MyRelationships;
		//	attributes = copy.attributes;
		}

		public Object(string name, string desc, string hist, string pict = "") {
			if (!string.IsNullOrEmpty(name)) Name = name;
			if (!string.IsNullOrEmpty(desc)) description = desc; //desc, hist, and imageFile hold filenames with extension
			if (!string.IsNullOrEmpty(hist)) history = hist;
			if (!string.IsNullOrEmpty(pict)) ImageFil = pict;
			MyRelationships = new List<relationship>();
		}
		protected struct relationship { //A relationship.  Including the type of relationship and who it is with.
		    public relationshipTypes type;
		    public Object MyRelationship;
		}

		public string GetFQPath(string path) {
			if (System.IO.File.Exists(path)) return path;
			else throw InvalidTextFile;
		}
		public string[] GetText(string path) {
			if (!System.IO.File.Exists(path)) throw InvalidTextFile;
			else return File.ReadAllLines(path);
		}

		public void SetMethod(string path, ref string value) {
			if		(System.IO.File.Exists(value)) path = value;
			else if (System.IO.File.Exists(path )){
				string[] fullDesc = { value };
				File.WriteAllLines(path, fullDesc);		
		   }else throw InvalidTextFile;
		}
		public void SetMethod(string path, ref string[] value) {
			if		(System.IO.File.Exists(value[0])) path = value[0];
			else if (System.IO.File.Exists(path    )) File.WriteAllLines(path, value);
			else throw InvalidTextFile;
		}

		public string   DescrptS { get{return GetFQPath(description);} set{SetMethod(description, ref value);} }//Gets and Sets the file name that contains the description of the object
		public string[] DescrptP { get{return GetText  (description);} set{SetMethod(description, ref value);} }//Gets and Sets the description text
		public string   HistoryS { get{return GetFQPath(history    );} set{SetMethod(history	, ref value);} }//Gets and sets the file name that contains the history of the object
		public string[] HistoryP { get{return GetText  (history    );} set{SetMethod(history	, ref value);} }//Gets and Sets the history text
		public string   ImageFil { get{return GetFQPath(image      );} set{SetMethod(image		, ref value);} }//Gets and sets the file name that contains the image of the object

		
		public void EstablishRelationship(Object relateMe, relationshipTypes myType) { //Create a new relationship
		    relationship newRelationship = new relationship();
		    newRelationship.MyRelationship = relateMe;
		    newRelationship.type = myType;
		    MyRelationships.Add(newRelationship);
		}
		public void RemoveRelationship(Object removeMe) { //Removes a relationship
		    foreach (relationship theRelationships in MyRelationships) {
		        if (theRelationships.MyRelationship == removeMe) MyRelationships.Remove(theRelationships);
		    }
		}
		public relationshipTypes WhatsTheRelationshipTo(Object myName) { //Return relationship type to given object
		    foreach(relationship theRelationship in MyRelationships)
		        { if (theRelationship.MyRelationship.Name == myName.Name) return theRelationship.type; }
		    return relationshipTypes.Null; //If the given object does not have a relationship to this object, return null type
		}
	}

	/*public class Temp_Opener {
		public void Opener(Object it) {
			Proccess.Start
		}
	}*/
}
