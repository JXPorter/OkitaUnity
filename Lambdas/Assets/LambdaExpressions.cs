using UnityEngine;
using System.Collections;
public class LambdaExpressions : MonoBehaviour
{
	// LAMBDAS - is basically a function written inside of a function. Being succinct, and brief, is the main goal of a lambda. 
	// When we write a bunch of different functions, we should keep tasks separate. A function should just do one specific thing. When the task
	// involves something more detailed which might require 1 or 2 other functions to get involved, it's sometimes easier to write a lambda instead.

	// Lambda statement basic setup is   delegate() => (input) => expression.
	// or we can extend it with delegate() => (input) => expression => {statement};


	// create a delegate signature
//	delegate int MyDelegate(int i);
//
//	void Start()
//	{
//		// assign a new delegate and assign the expression at the same time
//		MyDelegate myDelegatedTask = (x) => (x * x);            // x becomes x * x
//		// call the new delegated task
//		int y = myDelegatedTask(5);
//		Debug.Log (y);                // outputs 25 to the Console
//	}


	delegate int MyDelegate(int i);

	void Start()
	{
		// the two function declarations for myLambda and myDelegate do the exact same thing. 
		// the format for the lambda is shorter, but it's harder to read, unless you know what a lambda is and how it's used.
		MyDelegate myLambda = (x) => x * x;
		int y = myLambda (5);
		Debug.Log (y);                        // outputs 25

		MyDelegate myDelegate = delegate(int i) 
		{
			return i * i;
		};
		int z = myDelegate (5);
		Debug.Log (z);                      // outputs 25
	}
}



//// Original Code
//public class LambdaExpressions : MonoBehaviour
//{
//	//create a delegate signature like before
//	delegate int MyDelegate(int i);
//	
//	// Use this for initialization
//	//delegate int MyDelegate(int i);
//	void Start()
//	{
//		MyDelegate myLambda = (x) => x * x; 
//		int y = myLambda(5);
//		Debug.Log(y);
//		
//		MyDelegate myDelegate = delegate(int i)
//		{
//			return i * i;
//		};
//		int z = myDelegate(5);
//		Debug.Log(z);
//	}
//}
//using UnityEngine;
//using System.Collections;
//
//public class LambdaExpressions : MonoBehaviour
//{
//	delegate void MyDelegate();
//	
//	// Use this for initialization
//	void Start()
//	{
//		MyDelegate myDelegatedTask = 
//			delegate()
//		{
//			Debug.Log("Hello from anon.");
//		}; 
//		
//		myDelegatedTask();
//	}
//}
//using UnityEngine;
//using System.Collections;
//
//public class LambdaExpressions : MonoBehaviour
//{
//	delegate void MyDelegate();
//	// Use this for initialization
//	void Start()
//	{
//		MyDelegate myDelegatedTask = delegate()
//		{
//			Debug.Log("Hello from anon.");
//		}; 
//		myDelegatedTask();
//	}
//}
