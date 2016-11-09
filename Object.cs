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
		
		public Object(string name, string desc, string hist, string image_file)
			{ InitializerA(	 name,		  desc,		   hist,		image_file); }

		private InitializerA(string name, string desc, string hist, string image_file)
		{	attribute.name = name;
            attribute.description = desc; //Desc, hist, and imageFile hold filenames with the extension
            attribute.history = hist;
            this.imageFile = image_file;
            myRelationships = new List<relationship>();
        }

		protected struct relationship { //A relationship.  Including the type of relationship and who it is with.
		    public relationshipTypes type;
		    public Object myRelationship;
		}
		
		private List<Attribute> attributes  = new List<Attribute>
		{	new Attribute("Name", ""),
			new Attribute("Description", ""),
			new Attribute("Histroy", "")
		};
		
		//private List<string> Gallery = new List<string> {};
		
		public class Attribute
		{	public class Attribute_ID
			{	public   Attribute_ID(string name)
					{ called = name;	ind = (uint)AIDs.Count() + 1; }
				public uint	  ind	{ get; set; }
				public string called{ get; set; }
				/*public static bool operator ==(Attribute_ID Left, Attribute_ID Right) { return (Left.ind == Right.ind); }
				public static bool operator !=(Attribute_ID Left, Attribute_ID Right) { return (Left.ind != Right.ind); }
				public static bool operator <=(Attribute_ID Left, Attribute_ID Right) { return (Left.ind <= Right.ind); }
				public static bool operator >=(Attribute_ID Left, Attribute_ID Right) { return (Left.ind >= Right.ind); } //It's best to minimize these*/
			}
			public Attribute(string name, string txt)
			{	foreach (Attribute_ID AID in AIDs) if (name == AID.called) Field = AID;
				if (null == Field)
				{	AIDs.Add(new Attribute_ID(name));/*
				*/	Field = AIDs.Last();				}
				text = txt;
			}
			public static List< Attribute_ID > AIDs;
			public				Attribute_ID  Field = null;
			public string						text;
			public string[] DescText {
				get {string[] fullDesc;
					if (text /*is directory*/) fullDesc = File.ReadAllLines(text);
					else fullDesc = text;
					return fullDesc;
				}
				set { if(text /*is directory*/)  File.WriteAllLines(text, value);
					else text = value;
				}
			} //Gets and Sets the description text
		}

		public string Name		{ get; set; }
		public string DescFile	{ get; set; }
		public string Hist		{ get; set; }
		public string ImageFile	{ get; set; }

		
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
