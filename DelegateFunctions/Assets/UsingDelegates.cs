using UnityEngine;
using System.Collections;

public class UsingDelegates : MonoBehaviour 
{
	// Since Delegates are types, we are allowed to pass them to functions as though they were variables as well.
	// The basic idea of the delegate allows you to pick and choose between functions to assign to another function as an argument.
	// This also means that you can assign a function to a variable almost like any other data type.
	delegate int MyDelegate();

	// A delegate doesn't need to have its function declared ahead of its use.
	// just having a function named Del() and declaring it a delegate with return type void is enough to have a signature to work with.
	delegate void Del();


	// Use this for initialization
	void Start ()
	{
		int a = 10;

		// We create a new instance of the delegate with Del d. Then we assign it a task to do when d(); is called.
		// This format looks strange, because we are assigning a function inside of a function. This also means that we can reassign the function after it is used.
		Del d = delegate() 
		{
			Debug.Log ("delegate calling");	
		};
		d ();                   // outputs "delegate calling"
		d = delegate()         // reassigning d with a new function
		{
			Debug.Log ("a/2 = " + a / 2);
		};
	
		HandlesDel (d);          // outputs "a/2 = " 5
		UseDelegate (GetThree);
	}	

	void HandlesDel(Del del)   // Now that Del is a type, it can now be passed between functions as an argument. Instead of dealing with d(); at the end of the Start()
	// we can also pass d to a function that has the Del type as an argument variable.
	// The function HandlesDel(Del del) can accept d as an argument. This means that a function is a type. As a type it can be passed between functions as data.
	// The behavior also has an effect on the data inside of the function. Therefore data is also something that does work, contains logic, and can perform tasks.
	{
		del ();
	}

	int GetThree()
	{
		return 3;
	}
	void UseDelegate(MyDelegate mDelegate)
	{
		int gotNumber = mDelegate ();
		Debug.Log (gotNumber);
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
}
