using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace ConsoleApplication4
{
	public class Barometer1 : INotifyPropertyChanged, INotifyPropertyChanging 
	{ 
		private double pressure; 

		public  double Pressure 
		{ 
			get { return pressure; } 
			set { 
				if (value != pressure) 
				{ 
					//Maintaining the temporary copy of event to avoid race condition 
					PropertyChangingEventHandler propertyChanging = PropertyChanging; 
					if (propertyChanging != null) 
						{ propertyChanging(this, new PropertyChangingEventArgs("Pressure")); } 

					pressure = value;

					//Maintaining the temporary copy of event to avoid race condition 
					PropertyChangedEventHandler propertyChanged = PropertyChanged; 
					if (propertyChanged != null) 
						{ propertyChanged(this, new PropertyChangedEventArgs("Pressure")); } 
		} } }

		#region INotifyPropertyChanged Members 
		public event PropertyChangedEventHandler PropertyChanged; 
		#endregion 

		#region INotifyPropertyChanging Members 
		public event PropertyChangingEventHandler PropertyChanging; 
		#endregion 
	}


	public class Barometer2 : INotifyPropertyChanged, INotifyPropertyChanging 
	{ 
		private double pressure; 

		public double Pressure 
		{ 
			get{ return pressure; } 

			set{//Using Lambda Expressions, Anonymous methods and Extension methods
				PropertyChanged.SetPropertyValue(
					PropertyChanging, value, () => this.Pressure,
					new  Action<double>(delegate(double newValue) 

					{ pressure = newValue; })); 
			} 
		}

		#region INotifyPropertyChanged Members 
		public event PropertyChangedEventHandler PropertyChanged; 
		#endregion

		#region INotifyPropertyChanging Members 
		public event PropertyChangingEventHandler PropertyChanging; 
		#endregion 
	}
}
