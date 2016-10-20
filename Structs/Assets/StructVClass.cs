using UnityEngine;
using System.Collections;

public class StructVClass : MonoBehaviour {

	public struct PlayerData // NOTE: we can declare each variable in the struct to different data types.
	 // A Class is a reference type, while a Struct is a value type. When you create a struct and assign a value to it, a new unique copy is made of the struct. So each new 
	// struct can be editted and manipulated independently of the other. However, when you assign a value to a class instance, then when you change the class, then all instances/references
	// will also be changed however the class is affected. To accomplish the same behavior as a struct with a class, we need to assign each field separately e.g mc2.a = mClass.a. 
	{
		public Vector3 pos;
		public int hitPoints;
		public int Ammunition;
		public float RunSpeed;
		public float WalkSpeed;
	}
	PlayerData playerData;

	struct MyStruct
	{
		public int a;
	}
	class MyClass
	{
		public int a;
	}

	// Use this for initialization
	void Start () 
	{
		MyClass mClass = new MyClass ();
		MyStruct mStruct = new MyStruct ();
		mClass.a = 1;
		mStruct.a = 1;
		MyStruct ms = mStruct;
		ms.a = 3;
		Debug.Log (ms.a + " and " + mStruct.a);
		MyClass mc = mClass;
		mc.a = 3;
		Debug.Log (mc.a + " and " + mClass.a);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
