using UnityEngine;
using System.Collections;

public class MoreDelegateFunctions : MonoBehaviour 
{
	// When a delegate is first declared, it's useful to add a variable to store it in at the class scope. 
	// This allows other objects in the scene to have access to the delegate.
	// NOTE: Make sure to avoid an Inconsistent Accesibility Error: field type 'type' is less accessible than field 'field'
	//The type of a field cannot be less accessible than the field itself because all public constructs must return a publicly accessible object.

	public delegate void MyDelegate(int a);
	public MyDelegate del;
	public void FirstDelegate (int a)
	{
		Debug.Log ("first delegate: " +a);
	}
	public void SecondDelegate(int a)
	{
		Debug.Log ("second delegate: " +a);
	}

	// Use this for initialization
	void Start () 
	{
		if(del == null) // if del does not have anything assigned to it
		{
			del += FirstDelegate;   // += notation assigns the FirstDelegate() to del.
			del += SecondDelegate; 
			del (3); // prints "first delegate: 3"  and prints "second delegate: 3" 
			// The above code stacks more functions onto our delegate.
			// Once we get into Events and Event Management we will get a clearer picture of what delegate functions are really used for.
			// Events are basically functions that call other functions when something specific is triggerred. 
		}
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
