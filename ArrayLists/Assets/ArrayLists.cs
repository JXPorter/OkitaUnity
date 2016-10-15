using UnityEngine;
using System.Collections;

// My Code
public class ArrayLists : MonoBehaviour
{
	// store all of the game objects in the scene
	public GameObject[] AllGameObjects;
	public GameObject SpecificObject;
	// example of MessyInts[]
	public int[] messyInts = {12,14,6,1,0,123,92,8};

	void Start()
	{
		// creates an array list of an undetermined size and type
		ArrayList aList = new ArrayList();
		// create an array of all objects in the scene
		Object[] AllObjects = GameObject.FindObjectsOfType(typeof(Object)) as Object[];
		// iterate through all objects
		foreach(Object o in AllObjects)
		{
			// this code iterates through every object found in GameObject.FindObjectsOfType() 
			// there are about 77 total items, but we can check to ensure that only GameObjects are added to our aList
			Debug.Log(o);
			// if the item "o" is of type GameObject then add it to the aList.
			if(o.GetType() == typeof(GameObject))
			{
				aList.Add (o);
			}
		}

		// With the populated array list we can search the array for a specific object. Contains() searches through the list
		// for the specified param and returns true if it finds it, false if not.
		// IndexOf() returns the index of where the SpecificObject is found.
		if (aList.Contains (SpecificObject)) 
		{
			Debug.Log ("Specific Object Index: " + aList.IndexOf(SpecificObject));
		}

		// We can remove the object that this script is attached to with the Remove()
		// this example reduces the size of the array and takes out the Main Camera, which has the array list's
		// component attached. Now the array will just have cubes in it.
		if(aList.Contains(this.gameObject))
		{
			aList.Remove (this.gameObject);
		}

		// initialize the AllGameObjects array to the size of the aList
		AllGameObjects = new GameObject[aList.Count];
		// copy the array list to the AllGameObjects array with the CopyTo()
		aList.CopyTo(AllGameObjects);

		// SORT AND REVERSE
		// To copy the messyInts into a new ArrayList we use AddRange()
		ArrayList sorted = new ArrayList();
		// this adds the messyInts array to the new ArrayList
		sorted.AddRange(messyInts);
		// command to sort the contents of the ArrayList
		sorted.Sort();
		// command to show the sort in reverse order
		sorted.Reverse();
		// puts the new sorted list back into the messyInts array
		sorted.CopyTo(messyInts);
	}

	void Update()
	{
		
	}
}
//// Original Code
//public class ArrayLists : MonoBehaviour
//{
//	public GameObject SpecificObject;
//	public GameObject[] AllGameObjects;
//	public int[] messyInts = {12,14,6,1,0,123,92,8};
//	// Use this for initialization
//	void Start()
//	{
//		//creates an array of an undetermined size and type
//		ArrayList aList = new ArrayList(); 
//		
//		//create an array of all objects in the scene
//		Object[] AllObjects = GameObject.FindObjectsOfType(typeof(Object)) as Object[];
//		
//		//iterate through all objects
//		foreach (Object o in AllObjects)
//		{
//			if (o.GetType() == typeof(GameObject))
//			{
//				aList.Add(o);
//			}
//		}
//		
//		if (aList.Contains(SpecificObject))
//		{
//			Debug.Log(aList.IndexOf(SpecificObject));
//		}
//
//		if (aList.Contains(gameObject))
//		{
//			aList.Remove(gameObject);
//		}
//		
//		//initialize the AllGameObjects array
//		AllGameObjects = new GameObject[aList.Count];
//		
//		//copy the list to the array
//		DistanceComparer dc = new DistanceComparer();
//		dc.Target = gameObject;
//		aList.Sort(dc);
//		
//		aList.CopyTo(AllGameObjects);
//		ArrayList sorted = new ArrayList();
//		sorted.AddRange(messyInts);
//		sorted.Sort();
//		sorted.Reverse();
//		sorted.CopyTo(messyInts);
//		
//
//	}
//	
//	public class DistanceComparer : IComparer
//	{
//		public GameObject Target;
//				
//		public int Compare(object x, object y)
//		{
//			GameObject xObj = (GameObject)x;
//			GameObject yObj = (GameObject)y;
//			Vector3 tPos = Target.transform.position;
//			Vector3 xPos = xObj.transform.position;
//			Vector3 yPos = yObj.transform.position;
//			float xDistance = (tPos - xPos).magnitude;
//			float yDistance = (tPos - yPos).magnitude;
//			
//			if (xDistance > yDistance)
//			{
//				return 1;
//			} else if (xDistance < yDistance)
//			{
//				return -1;
//			} else
//			{
//				return 0;
//			}
//		}
//	}
//}
