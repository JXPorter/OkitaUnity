using UnityEngine;
using System.Collections;
using MyNameSpace; // using our new namespace
using AnotherNameSpace; // using another namespace

public class Example : MonoBehaviour
{
	void Start()
	{
		MyNameSpace.MyClass mc = new MyNameSpace.MyClass ();
		mc.MyFunction ();
	}

	void Update()
	{
		
	}
}

//// Original Code
//using MyNameSpace; //using our new namespace
//using AnotherNameSpace;
//
//public class Example : MonoBehaviour
//{
//
//	// Use this for initialization
//	void Start()
//	{
//		MyNameSpace.MyClass mc = new MyNameSpace.MyClass();
//		mc.MyFunction();
//		AnotherClassInMyNamespace AnotherClass = new AnotherClassInMyNamespace();
//		AnotherClass.MyFunction();
//	}
//	
//	// Update is called once per frame
//	void Update()
//	{
//	
//	}
//}