using UnityEngine;
using System.Collections;
public class Example : MonoBehaviour
{
	// Optional Parameters - allow you to omit arguments for some parameters. Optional parameters are given a default value in the parameter list which is used if it is not overridden.
	// There are some simple rules to follow if you want to make some of the arguments in the parameter list optional.
	// optional parameters must appear after the required parameters and in the order that they were defined in the method, struct, indexer, or delegate.
	// You can make all of the parameters have default values, which means that they'd all be optional parameters.
	// We can use Optional Parameters to add new values to functions that are utilized throughout our code. Though if we don't update those functions, then they will use
	// the optional parameters default value.
	public void ParamUsage(int anInt, float anOptionalFloat = 1)
	{
		Debug.Log ("using an int " + anInt + " a float? " + anOptionalFloat);
	}
	public void ParamUsage(string words)
	{
		Debug.Log ("using a string " + words);
	}
	public void LotsOfParams(int a = 0, int b = 1, int c = 2, int d = 3)
	{
		Debug.Log ("a:" + a + " b:" + b + " c:" + c + " d:" + d);
	}
	public GameObject CreateACube(string cubeName, Vector3 position, float scale = 1.0f)
	{
		GameObject cube = GameObject.CreatePrimitive (PrimitiveType.Cube);
		cube.name = cubeName;
		cube.transform.position = position;
		cube.transform.localScale = new Vector3 (scale, scale, scale);
		return cube;
	}

	public void Variations(ref float a, out float b, float c = 10.0f, float d = 11.0f)
	{
		b = c / a;
		a = c / d;
	}
	// NOTE: ref cannot have a default value. Since ref is a keyword reserved to tell the parameter that it's going to assume the place of another variable that already exists.
	// This means that the value in the argument list cannot be defined since the ref tells the value that it must be modifying something that exists outside the function.

	void Start()
	{
		ParamUsage (1);            // outputs using an int 1 a float? 1     -- note that since we didn't pass a parameter, then the optional parameter default value is used
		ParamUsage (1, 7.0f);           // outputs using an int 1 a float? 7
		ParamUsage ("not a number");    // outputs using a string not a number
		LotsOfParams(0,99);
		// Named Parameters - by naming parameters it is more clear what each value is for and what the assignment is. 
		// just use the name of the argument you want to assign a value to followed by a : and the value you want to assign to it.
		LotsOfParams(b:99);
		// The order is also ignored so long as the identifiers are used
		// However, the position or order of any unnamed arguments must line up with the function's signature. Or else C# will throw an error, e.g. Named
		// Arguments Must Appear After The Positional Arguments
		LotsOfParams(b:99, a:88, d:777, c: 1234); // outputs a:88 b:99 c:1234 d:777
		CreateACube("bob", new Vector3(10,0,0));
	}
}
//// Original Code
//public class Example : MonoBehaviour
//{
//	public void ParamUsage(int anInt = 1, float anOptionalFloat = 1)
//	{
//		Debug.Log("using an int " + anInt + " a float? " + anOptionalFloat);
//	}
//	public void ParamUsage(string words)
//	{
//		Debug.Log("using a string " + words);
//	}
//	public void LotsOfParams(int a = 0, int b = 1, int c = 2, int d = 3)
//	{
//		Debug.Log("a:" + a + "b:" + b + "c:" + c + "d:" + d);
//	}
//
//	public GameObject CreateACube(string cubeName, Vector3 position, float scale = 1.0f)
//	{
//		GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
//		cube.name = cubeName;
//		cube.transform.position = position;
//		cube.transform.localScale = new Vector3(scale, scale, scale);
//		return cube;
//	}
//	public void Variations(ref float a, out float b, float c=10.0f, float d=11.0f)
//	{
//		b = c / a;
//		a = c / d;
//	}
////	public void bad( ref int a = 1 ) {
////		Debug.Log ( "test: " + a );
////	}
//
//	void Start()
//	{
//		CreateACube(scale : 6.0f, cubeName : "henry", position : new Vector3(2.0f, 0, 0));
//		LotsOfParams(0, 99);
//		LotsOfParams(b: 99);
//		LotsOfParams(b: 99, a: 88, d: 777, c: 1234);
//		ParamUsage(1);
//		ParamUsage(1, 7.0f);
//		ParamUsage("not a number");
//	}
//}