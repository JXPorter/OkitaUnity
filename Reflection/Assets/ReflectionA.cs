using UnityEngine;
using System.Collections;
using System.Reflection;

// REFLECTION allows us to see the fields, functions, types, and attributes found within a class. You can search through the code without looking at it with your eyes
// and know what fields, functions, types, and attributes exist within the class or code base. With Reflection we can find fields and methods in each class we write,
// without having to memorize our entire project. Also great for working with an already established code base.
public class ReflectionA : MonoBehaviour
{
	class subClassA
	{
		public static int firstInt;
		public string secondInt;
		public int thirdInt;
		public subClassA(int first, int second, int third)
		{
			firstInt = first;
			this.secondInt = second.ToString();
			this.thirdInt = third;
		}

		public void OnUpdate()
		{
			Debug.Log ("subClassA Updating A");
		}
	}

	class subClassB
	{
		public void OnUpdate()
		{
			Debug.Log ("subClassB Updating B");
		}
	}

	class subClassC
	{
		public void NotUpdate()
		{
			
		}
	}
	// make an instance of each class
	subClassA ca;
	subClassB cb;
	subClassC cc;

	void Start()
	{
		ca = new subClassA (1,2,3);
		cb = new subClassB ();
		cc = new subClassC ();

		FieldInfo[] fields = typeof(subClassA).GetFields ();
		foreach(FieldInfo field in fields)
		{
			Debug.Log (field.Attributes + " " + field.FieldType + " " + field.Name);
		}

		// This code reveals all of the functions, fields, and attributes associated with the function and fields of the class. 
		MemberInfo[] memberInfos = typeof(subClassA).GetMembers ();
		foreach(MemberInfo m in memberInfos)
		{
			Debug.Log (m.ToString());
		}
	}

	void Update()
	{
		// our 3 classes are added to an ArrayList
		ArrayList subClasses = new ArrayList ();
		subClasses.Add (ca);
		subClasses.Add (cb);
		subClasses.Add (cc);
		// we use a foreach loop to look at each object in the ArrayList. In this list we look at each of our subclasses, however we might not know
		// whether they have an OnUpdate() function or not. The object o is a boxed look at each item in the ArrayList.
		// Therefore we use (MethodInfo) cast to turn the value into a MethodInfo data type.
		// To do this we use o.GetType() that returns the object's type. This is how we convert the object found in o to its type. Otherwise, we'd have to 
		// use the typeof(type) to get the type's method. Since the type in question could be anything, we can't do this. 
		// After we GetType of object o, then we use the GetMethod("OnUpdate") to check the class for a method called OnUpdate.
		foreach(object o in subClasses)
		{
			MethodInfo method = (MethodInfo)o.GetType ().GetMethod ("OnUpdate");
			if(method != null)                                                  // if function exists, then method is not null, so we can call it.
			{
				method.Invoke (o, null);                // to call OnUpdate() we use this line to invoke the OnUpdate() now stored in MethodInfo method.
														// the first argument tells the function what we're calling the function in, and the null argument
														// tells method.Invoke() what params we're passing to the function, but this function takes no args so it's null.
			}
			// Since subClassC has no OnUpdate(), we don't try to invoke it. If we tried o.OnUpdate() we'd get an error, b/c it does not exist in subClassC.
		}
	}
}
//// Original Code
//using UnityEngine;
//using System.Collections;
//using System.Reflection;
//
//public class ReflectionA : MonoBehaviour
//{
//	
//	class subClassA
//	{
//		public static int firstInt;
//		public string secondInt;
//		public int thirdInt;
//		public subClassA(int first, int second, int third)
//		{
//			firstInt = first;
//			this.secondInt = second.ToString();
//			this.thirdInt = third;
//		}
//		public void OnUpdate()
//		{
//			Debug.Log("subClassA Updating A");
//		}
//	}
//	class subClassB
//	{
//		public void OnUpdate()
//		{
//			Debug.Log("subClassB Updating B");
//		}
//	}
//	class subClassC
//	{
//		public void NotUpdate()
//		{
//		
//		}
//	}
//
//	subClassA ca;
//	subClassB cb;
//	subClassC cc;	
//	
//	// Use this for initialization
//	void Start()
//	{
//		ca = new subClassA(1, 2, 3);
//		cb = new subClassB();
//		cc = new subClassC();
//
//		FieldInfo[] fields = typeof(subClassA).GetFields();
//		foreach (FieldInfo field in fields)
//		{
//			Debug.Log(field.Attributes + " " + field.FieldType + " " + field.Name);
//			
//			if (field.FieldType == typeof(string))
//			{
//				field.SetValue(ca, "I found a string!");
//			}
//		}
//		MemberInfo[] memberInfos = typeof(subClassA).GetMembers();
//		foreach (MemberInfo m in memberInfos)
//		{
//			Debug.Log(m.ToString());
//		}
//		Debug.Log(ca.secondInt);
//	}
//	
//	void Update()
//	{
//		ArrayList subClasses = new ArrayList();
//		subClasses.Add(ca);
//		subClasses.Add(cb);
//		subClasses.Add(cc);
//		foreach (object o in subClasses)
//		{
//			MethodInfo method = (MethodInfo)o.GetType().GetMethod("OnUpdate");
//			if (method != null)
//			{
//				method.Invoke(o, null);
//			}
//		}		
//	}
//}
//
