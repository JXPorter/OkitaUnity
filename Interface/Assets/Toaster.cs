using UnityEngine;
using System.Collections;
public class Toaster : IThing
{
	private string ToasterName; // we need a private local variable specific to the class that holds onto string name, which was supplied in the interface
	// We use ToasterName in the Toaster class. This isolates the local data but uses the interface property for the variable ThingName that was created in the IThing interface.
	public string ThingName
	{
		get
		{ 
			return ToasterName;
		}
		set
		{ 
			ToasterName = value; // the keyword value is used in the get; set; function to access the interface's variable. This accessor statement is used for interface implementation.
		}
		// keyword value is specific to the accessor
	}
	public void SayHello()
	{
		Debug.Log ("howdy doodly doo.");
	}
	// you can automatically stub out a code template by pressing CMD I on a Mac. This pulls up the Show Code Generation menu.
//	public string ThingName {
//		get {
//			throw new System.NotImplementedException ();
//		}
//		set {
//			throw new System.NotImplementedException ();
//		}
//	}
}

//// Original Code
//public class Toaster : IThing
//{
//	private string ToasterName;
//	
//	public string ThingName
//	{
//		get
//		{
//			return ToasterName;
//		}
//		set
//		{
//			ToasterName = value;
//		}
//	}
//	
//	public void SayHello()
//	{
//		Debug.Log("howdy doodly do.");
//	}
//}