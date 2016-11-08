using UnityEngine;
using System.Collections;
public class DelegateFunctions : MonoBehaviour
{
	// A DELEGATE acts like a data type. It is a type of function. A delegate allows us to use a function in a variable. 
	// If you can assign a variable to a function then you can use it like data and pass it between functions, structs, classes through a parameter or assignment.
	// Ensure that the signature of the variable you're storing a function in and the function you're about to delegate match. 

	// First we need to write a new delegate function. Which is like a template signature for any function that is to be delegated.
	// declare a new delegate
	delegate void MyDelegate();

	// now that we have a defined delegate we need to make some functions that match the signature.

	void FirstDelegete()
	{
		Debug.Log ("First delegate called");
	}
	void SecondDelegate()
	{
		Debug.Log ("Second delegate called");
	}

	// A more complex example of a delegate with a more interesting signature
	// Here we have assigned a return value and two arguments to the delegate MyDelegate2
	// To make use of this signature, we wrote two different functions using the same signature.
	delegate int MyDelegate2(int a, int b);

	public int FirstDelegate2(int a, int b)
	{
		return a + b;
	}
	public int SecondDelegate2(int a, int b)
	{
		return a - b;
	}

	void Start()
	{
		// To make use of a delegate you need to make an instance of the function like you would if it were a class object
		MyDelegate del = new MyDelegate(FirstDelegete);   // after this assignment del is now a FirstDelegate()
		del ();     // outputs "First delegate called"
		del = SecondDelegate; // del is reassigned
		del(); // outputs "Second delegate called"

		MyDelegate2 del2 = new MyDelegate2 (FirstDelegate2);
		int add = del2 (7,3);
		Debug.Log (add);    // outputs 10
		del2 = SecondDelegate2;
		int sub = del2 (103, 3);  //outputs 100
		Debug.Log (sub);
	}
}

//// Original Code
//public class DelegateFunctions : MonoBehaviour {
//
//	delegate void Del();
//	delegate int iDel();
//	delegate int lamb(int i);
//	// Use this for initialization
//	void Start () {
//		int a = 10;
//
//		Del d = delegate()
//		{
//			Debug.Log("delegate calling");
//		};
//		d();
//		
//		d = delegate()
//		{
//			Debug.Log( "a/2 = " + a/2 );	
//		};
//		HandlesDel(d);
//		
//		iDel id = delegate() {
//			return 12;
//		};
//		AdsiDel(id);
//		
//	}
//	
//	void HandlesDel(Del del)
//	{
//		del();
//	}
//	
//	void AdsiDel(iDel id)
//	{
//		Debug.Log("adding iDels together: " + id()*2 );
//	}
//	// Update is called once per frame
//	void Update () {
//	
//	}
//}
