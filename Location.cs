using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

/* This is what I have thus far for the Location class and sub classes.
 * If you think that some of these members or classes are over kill and will be useless (like the room class) feel free to remove them in an update.
 * I'm putting this up now because you all wanted it ASAP; however, I might not be done.
 * If we really need to use getters and setters for everything, I'm wondering if we could just make a type called SmallString
 * that would inherit from string and contain the getters and setters of all our small strings.  Beause although I always minimize properties blocks
 * they still clutter things up.
 */

namespace StoryPlanner
{	
	extern abstract class Object;	// I'm concerned with how Joe named the class Object,
									// which appears to be synonomus to the object key word in many cases, and all my errors pertain to the global base class. 
	public class Location : Object
	{	private string map_file;
		public  string Map_file {	//Gets the file name that contains the map
			get { return map_file;  }
			set { map_file = value; }
		}
		
		private string size;		//Ex: 125 Leagues squared.	We could trun this into it its own object of class Size{ uint value; units; dimensions; }
		public  string Size {
			get { return size;  }
			set { size = value; }
		}
	}

	public class Region	: Location
	{	private string terrain;
		public  string Terrain {
			get { return terrain;  }
			set { terrain = value; }
		} //If we make getters and setters here, we are going to need to do the same for all other small strings
	}

	public class Country: Location
	{	private Region regio;
		public  Region Regio {
			get { return regio;  }
			set { regio = value; }
		}
	
		private string _ocracy; //Ex: Theocracy Democracy
		public  string _Ocracy {
			get { return _ocracy;  }
			set { _ocracy = value; }
		}
		private string values ; //Ex: Totalatarian, Left_wing right_wing
		public  string Values {
			get { return values;  }
			set { values = value; }
		}
		private string economy; //Ex: Communist, Market; Free Restricted Controled
		public  string Economy {
			get { return economy;  }
			set { economy = value; }
		}
	}

	public class City	: Location
	{	private Region regio;
		public  Region Regio {
			get { return regio;  }
			set { regio = value; }
		}
		private Country state;
		public  Country State {
			get { return state;  }
			set { state = value; if(state.Regio != null) regio = state.Regio; }
		}
	}

	public class Building:Location
	{	private string stories; //Since we won't be doing any math with this I don't see the point in limiting it to an uint.
		public  string Stories {
			get { return stories;  }
			set { stories = value; }
		}
	  /*private string material;//Ex: brick		I think this should be left in the description
		public  string Material {
			get { return material;  }
			set { material = value; }
		}*/
	}

	public class Room	: Location
	{	private Building complex;
		public  Building Complex {
			get { return complex;  }
			set { complex = value; }
		}
	}


}