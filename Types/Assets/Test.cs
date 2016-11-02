using UnityEngine;
using System.Collections;

public class Test : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
		// This code creates two game objects with two different game ids
		GameObject a = GameObject.CreatePrimitive (PrimitiveType.Capsule);
		GameObject b = GameObject.CreatePrimitive (PrimitiveType.Capsule);
		print (a.GetInstanceID());
		print (b.GetInstanceID());
		print (a.GetInstanceID() == b.GetInstanceID());

		// This code creates one variable "c", that contains a game object id, then it sets another int called "d" to have the same game object id.
		// It prints out the values of both c and d, then compares these values.
		int c = GameObject.CreatePrimitive(PrimitiveType.Capsule).GetInstanceID();
		int d = c;
		print (c);
		print (d);
		print (c == d); // true

		float e = 1.0f;
		Debug.Log(e.GetType());

		double f = 22.22;
		Debug.Log (f.GetType());
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
}
