using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace StoryPlanner
{
	public class Object //: System.ComponentModel.IEditableObject  //This will be a parent class to all objects
	{
		public enum relationshipTypes {Null, Father, Mother, Sibling, Friend, Enemy}; //Types of relationships... let me know if we need more
		protected string name, description, history, imageFile;
		protected List<relationship> MyRelationships; //List of this objects relationships
		
		public Object(string name, string desc, string hist, string image_file="")
			{ InitializerA(	 name,		  desc,		   hist,		image_file); }

		private void InitializerA(string name, string desc, string hist, string image_file = "") {
			attributes.Find(x => x.Label.called == "Name"		).text = name;
			attributes.Find(x => x.Label.called == "Description").text = desc;
			attributes.Find(x => x.Label.called == "History"	).text = hist;
		//	this.imageFile = image_file;
			MyRelationships = new List<relationship>();
        }

		protected struct relationship { //A relationship.  Including the type of relationship and who it is with.
		    public relationshipTypes type;
		    public Object MyRelationship;
		}
		
		public List<Attribute> attributes = new List<Attribute> {
			new Attribute("Name", ""),
			new Attribute("Description", ""),
			new Attribute("History", "")
		};
		
		

		//private List<string> Gallery = new List<string> {};
		
		public class Attribute //: System.ComponentModel.IEditableObject
		{	public class Attribute_ID
			{	public   Attribute_ID(string name)
					{ called = name;	ind = (uint)AIDs.Count() + 1; }
				public uint	  ind	{ get; set; }
				public string called{ get; set; }
				/*public static bool operator ==(Attribute_ID Left, Attribute_ID Right) { return (Left.ind	== Right.ind); }
				public static bool operator !=(Attribute_ID Left, Attribute_ID Right) { return (Left.ind	!= Right.ind); }
				public static bool operator <=(Attribute_ID Left, Attribute_ID Right) { return (Left.ind	<= Right.ind); }
				public static bool operator >=(Attribute_ID Left, Attribute_ID Right) { return (Left.ind	>= Right.ind); }
				public static bool operator ==(Attribute_ID Left, 		   int Right) { return (Left.ind	== Right	); }
				public static bool operator !=(Attribute_ID Left,		   int Right) { return (Left.ind	!= Right	); }
				public static bool operator <=(Attribute_ID Left,		   int Right) { return (Left.ind	<= Right	); }
				public static bool operator >=(Attribute_ID Left,		   int Right) { return (Left.ind	>= Right	); }
				public static bool operator ==(Attribute_ID Left,		string Right) { return (Left.called == Right	); }
				public static bool operator !=(Attribute_ID Left,		string Right) { return (Left.called != Right	); } //It's best to minimize these*/
			}
			public Attribute(string name, string txt)
			{	if (AIDs == null) AIDs = new List<Attribute_ID>();//Initialization
				else foreach (Attribute_ID AID in AIDs) if (name == AID.called) Label = AID;
				if (Label == (Attribute_ID)null)
				{	AIDs.Add(new Attribute_ID(name));
					Label = AIDs.Last();
				}
				path = txt;
			}

			public  static List< Attribute_ID > AIDs;
			public  			 Attribute_ID  Label = null;

			private string path;
			public  string text	//Gets and Sets the text in "path"
			{	
				get{string[] fullDesc;		// To be used to convert string[] to string
					if (System.IO.Directory.Exists(path)) fullDesc = File.ReadAllLines(path);
					else return path;
					return string.Join(".", fullDesc);
				}
				set{if (System.IO.Directory.Exists(path))
					{	string[] fullDesc = { value };
						File.WriteAllLines(path, fullDesc);
					}else path = value;
				}
				
				/*public  void BeginEdit(){
					Console.WriteLine("Start BeginEdit");
					if (!inTxn) 
					{
						backupData = ;
						inTxn = true;
						Console.WriteLine("BeginEdit - " + this.backupData.lastName);
					}
					Console.WriteLine("End BeginEdit");
				}
				public  void EndEdit()	{}
				public  void CancelEdit(){}*/
			}					//Gets and Sets the text in "path"
			public static bool operator ==(Attribute Left, string Right) { return (Left.Label.called == Right); }
			public static bool operator !=(Attribute Left, string Right) { return (Left.Label.called != Right); }
			public static bool operator ==(string Left, Attribute Right) { return (Left == Right.Label.called); }
			public static bool operator !=(string Left, Attribute Right) { return (Left != Right.Label.called); }
			//public static bool operator <=(Attribute Left,    int Right) { return (Left.Label <= Right/*.Label*/); }
			//public static bool operator >=(Attribute Left,    int Right) { return (Left.Label >= Right/*.Label*/); } //It's best to minimize these
		}

		public string Name		{ get; set; }
		public string DescFile	{ get; set; }
		public string Hist		{ get; set; }
		public string ImageFile	{ get; set; }

		/*public  void BeginEdit(){
			Console.WriteLine("Start BeginEdit");
			if (!inTxn) 
			{
				backupData = attributes;
				inTxn = true;
				Console.WriteLine("BeginEdit - " + this.backupData.lastName);
			}
			Console.WriteLine("End BeginEdit");
		}
		public  void EndEdit()	{}
		public  void CancelEdit(){}
		*/
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
}
