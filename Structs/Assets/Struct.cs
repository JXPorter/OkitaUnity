using UnityEngine;
using System.Collections;

// breaking the encapsulation of the class, by moving the struct outside of the class.
// this changes the BoxParameters into a globally accessible struct.
// I made this struct even more cleanly globally accessible by placing it in its own utility file called Global.cs
//public struct BoxParameters
//{
//	public float width;
//	public float height;
//	public float depth;
//	public Color color;
//}
public class Struct : MonoBehaviour
{
	// put the new Struct to use and name it myParameters
	public BoxParameters myParameters;

	void Start()
	{
		myParameters.width = 2;
		myParameters.height = 3;
		myParameters.depth = 4;
		myParameters.color = new Color (1,0,0,1);
	}

	void Update()
	{
		float h = (100 * Mathf.Sin(Time.fixedTime)) /10;
		myParameters.height = h;
		UpdateCube (myParameters);
	}

	void UpdateCube(BoxParameters box)
	{
		Vector3 size = new Vector3 (box.width, box.height, box.depth);
		gameObject.transform.localScale = size;
		gameObject.GetComponent<Renderer>().material.color = box.color;
	}
}
//// Original Code
//public class Struct : MonoBehaviour
//{
////	struct BoxParameters
////	{
////		public float width;
////		public float height;
////		public float depth;
////		public Color color;
////	}
//	
//	//put the new struct to use and name it myParameters
//	//BoxParameters myParameters;
//
//	public BoxParameters myParameters;
//
//	// Use this for initialization
//	void Start()
//	{
//		myParameters.width = 2;
//		myParameters.height = 3;
//		myParameters.depth = 4;
//		myParameters.color = new Color(1, 0, 0, 1);
//	}
//	
//	void UpdateCube(BoxParameters box)
//	{
//		Vector3 size = new Vector3(box.width, box.height, box.depth);
//		gameObject.transform.localScale = size;
//		gameObject.GetComponent<Renderer>().material.color = box.color;
//	}
//	
//	// Update is called once per frame
//	void Update()
//	{
//		float h = (100 * Mathf.Sin(Time.fixedTime)) / 10;
//		myParameters.height = h;
//		UpdateCube(myParameters);
//	}
//}
