using UnityEngine;
using System.Collections;
public class Child : Parent
{
	void Start()
	{
		base.FunctionA (); // adding the keyword base allows us to use the original parent version of this inherited function
		ParentFunction ();
	}

	public override void FunctionA()
	{
		print ("I'm a new version of function A!");
	}
}

//// Original Code
//public class Child : Parent
//{
//	void Start()
//	{
//		base.FunctionA();
//		ParentFunction();
//	}
//	
//	public override void FunctionA()
//	{
//		print("Im a new version of function A");
//	}
//}