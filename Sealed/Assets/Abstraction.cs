using UnityEngine;
using System.Collections;
// The Abstract keyword is used to tell inheriting classes that there's a function that they need to implement

public class Abstraction : MonoBehaviour
{
	abstract class BaseClass  // A class with an abstract function within it, must be declared abstract as well.
	{
		public int Counter;
		public abstract void ImportantFunction (); // The abstract keyword implies that this function is a stub. It tells the programmer who is inheriting from the Base Class
		// that there's an important function that they need to implement. But this implementation is up to the dev.
		// e.g. if Monster is the base class, they may have an AttackHuman(), different monsters have a variety of ways of attacking, so this implementation will vary based on monster type.
		// a function preceded by the abstract keyword cannot have a body. Instead you must rely on a child class making the implementation.
	}

	// abstract classes that inherit from abstract classes can be used to add more data fields and functions to provide a variation on the first class
	// The advantage is that we inherit from the first class, but don't need to make any modifications to the Base, as there might be other classes relying on its stability
	abstract class SecondaryClass : BaseClass
	{
		public int Limit;
		public abstract bool AtLimit ();
		public abstract void SetLimit (int l);
	}
		
	sealed class ChildClass : SecondaryClass
	{
		public override void ImportantFunction () // need to use override to tell C# that this function is writing the implementation of ImportantFunction()
		{
			Counter++;
			Debug.Log (Counter);
		}
		public override bool AtLimit()     // need to use override to tell C# that this function is wrting the implementation of the AtLimit() and SetLimit(int l) functions.
		{
			return Counter >= Limit;
		}
		public override void SetLimit (int l)
		{
			Limit = l;
		}

	}

	class SiblingClass : BaseClass
	{
		public override void ImportantFunction()
		{
			Counter--;
			Debug.Log (Counter);
		}
	}
	void Start()
	{
		ChildClass c = new ChildClass ();
		c.SetLimit (2);
		c.ImportantFunction ();  // prints 1
		Debug.Log (c.AtLimit());  // prints False
		c.ImportantFunction(); // prints 2
		Debug.Log(c.AtLimit()); // prints True

	}

	void Update()
	{
		
	}
}


//// Original Code
//public abstract class Abstraction : MonoBehaviour
//{
//	abstract class BaseClass
//	{
//		public int Counter;
//		public abstract void ImportantFunction();
//	}
//	
//	abstract class SecondaryClass : BaseClass
//	{
//		public int Limit;
//		public abstract bool AtLimit();
//		public abstract void SetLimit(int l);
//	}
//
//	sealed class ChildClass : SecondaryClass
//	{		
//		public override void ImportantFunction()
//		{
//			Counter++;
//			Debug.Log(Counter);
//		}
//		
//		public override bool AtLimit()
//		{
//			return Counter >= Limit;
//		}
//		
//		public override void SetLimit(int l)
//		{
//			Limit = l;
//		}
//	}
//
//
////	// Use this for initialization
////	void Start()
////	{
////		ChildClass c = new ChildClass();
////		c.SetLimit(2);
////		c.ImportantFunction(); // prints 1
////		Debug.Log(c.AtLimit());//prints False
////		c.ImportantFunction(); // prints 2
////		Debug.Log(c.AtLimit()); //prints True
////	}
////	
////	// Update is called once per frame
////	void Update()
////	{
////	
////	}
//
//}
