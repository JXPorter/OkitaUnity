using UnityEngine;
using System.Collections;

public class MonsterGenerator : MonoBehaviour
{
	public int numBoxes = 10;
	public GameObject[] boxes;
	public float spacing = 1.4f;

	void Start()
	{
		boxes = new GameObject[numBoxes];  // create a GameObject[] called boxes with cubes called box
		for(int i =0; i <numBoxes; i++)
		{
			GameObject box = GameObject.CreatePrimitive (PrimitiveType.Cube);
			box.name = "Box " + i;
			box.AddComponent <Monster>(); // added component Monster.cs so that these classes can talk to each other.
			Monster m = box.GetComponent<Monster>(); //as Monster;  // after adding the component we need to Get access to it. We create a Monster variable named m. Then use the
																 // GameObject.GetComponent function to get an object called Monster, and ensure it is of type Monster by using the as keyword
													             // I don't think as Monster is necessary because <Monster> provides the Monster type.
			// can also combine assigning and getting the Monster m variable at the same time
			// Monster m = box.AddComponent<Monster>();

			m.ID = i;             // ID was set in Monster.cs
			m.spacing = spacing;    // spacing has been declared in both Monster.cs and Example.cs
			boxes [i] = box;
		}
	}

	void Update()
	{
//		int i = 0;         // No longer need this code, b/c each instance object will be controlled individually by the Monster script
//		foreach(GameObject go in boxes)
//		{
//			float wave = Mathf.Sin (Time.fixedTime + i);      // this Mathf.Sin function acting upon the constantly changing Time.fixedTime + i will make the objects bob up in down in the air
//			go.transform.position = new Vector3 (i * spacing, wave, 0); // added wave to the y postion of the Vector3 so that the cube will bob up and down. 
//			i++;
//			//print (go.name);
//		}
	}
}
////Original Code
//public class Example : MonoBehaviour
//{
//	public int numBoxes = 10;
//	public GameObject[] boxes;
//	public float spacing;
////	public GameObject[] boxes = new GameObject[10];
////	public GameObject box1;
////	public GameObject box2;
////	public GameObject box3;
////	public GameObject box4;
////	public GameObject box5;
////	public GameObject box6;
////	public GameObject box7;
////	public GameObject box8;
////	public GameObject box9;
////	public GameObject box10;
//
//	//a single int
//	int MyInt;
//	
//	//an array of ints
//	int[] MyInts;
//	
//	//a single object
//	object MyObject;
//	
//	//an array of objects
//	object[] MyObjects;
//
//	// Use this for initialization
//	void Start()
//	{
//		boxes = new GameObject[numBoxes];
//		for (int i = 0; i < numBoxes; i++)
//		{
//			GameObject box =
//				GameObject.CreatePrimitive(PrimitiveType.Cube);
//			//box.AddComponent("Monster");
//			Monster m = box.AddComponent<Monster>() as Monster;
//			//Monster m = box.GetComponent("Monster") as Monster;
//			m.ID = i;
//			boxes [i] = box;
//		}
//	}
//	
//	// Update is called once per frame
//	void Update()
//	{
//		int i = 0;
//		foreach (GameObject go in boxes)
//		{
//			//			go.transform.position = new Vector3(i * 1.0f, 0, 0);
//			float wave = Mathf.Sin(Time.fixedTime + i);
//			go.transform.position = new Vector3(i * spacing, wave, 0);
//			i++;
//			print(i);
//		}
//	}
//}
