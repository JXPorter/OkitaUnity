using UnityEngine;
using System.Collections;
using System.Runtime.CompilerServices;
public class OutParam: MonoBehaviour
{
	public GameObject[] GameObjectArray;

	void Start()
	{
		ArrayList aList = new ArrayList ();
		GameObject[] gameObjects = (GameObject[])GameObject.FindObjectsOfType (typeof(GameObject));
		foreach(GameObject go in gameObjects)
		{
			if(go.name == "Sphere")
			{
				aList.Add (go);
			}
		}
		GameObjectArray = aList.ToArray (typeof(GameObject)) as GameObject[];
	}

	void Update()
	{
		sortObjects (GameObjectArray, out GameObjectArray);
		for(int i = 0; i < GameObjectArray.Length; i++)
		{
			Vector3 PositionA = GameObjectArray [i].transform.position;
			Debug.DrawRay(PositionA, new Vector3(0,i*0.1f,0), Color.red);
		}
	}

	// This is an inefficient Bubble Sort
	void sortObjects(GameObject[] objects, out GameObject[] sortedObjects)  // this method takes in a GameObject array and will return (out) a sorted Game Object array based on how close the object is to this script
	{
		for(int i = 0; i < objects.Length-1; i++)  // since we are comparing two positions we don't want to compare beyond the length of the array, which would result in an IndexOut Of Range Exception
		{
			Vector3 PositionA = objects [i].transform.position;
			Vector3 PositionB = objects [i + 1].transform.position;
			Vector3 VectorToA = PositionA - transform.position;
			Vector3 VectorToB = PositionB - transform.position;
			float DistanceToA = VectorToA.magnitude;
			float DistanceToB = VectorToB.magnitude;
			if(DistanceToA > DistanceToB)    // if DistanceToA is greater than B then we are going to swap the objects
			{
				GameObject temp = objects [i];  // create a temp memory location to store the object in the index i of objects, b/c it is going to get written over in the swap
				objects [i] = objects [i + 1];  // This will result in two copies of the same object in the array, since both are holding onto the same GameObject for just this statement
				objects [i + 1] = temp; // then to finish the swap we replace objects[i+1] with the value held in temp (which is objects[i])
			}
		}
		sortedObjects = objects; // sends the sorted array back and the out parameter pushes the array back up out of the function into where it was called on
	}


	//	// INTRO TO OUT KEYWORD LESSON
	//	void sevenOut (out int s)  // the out keyword functions sort of like return, but allows us to get more than one value from a function, or even to produce many
	//	// useful operations on incoming values as well (see inAndOut()).
	//	// We can also use the function as a pure function as long as none of the variables inside of the function rely on anything at the class level. So the code can be copied and
	//	// moved to any other class easily.
	//	{
	//		s = 7;
	//	}
	//
	//	void inAndOut (int inComing, out int outGoing)
	//	{
	//		outGoing = inComing * 2;
	//	}
	//	void Start()
	//	{
	//		int outValue = 0; // the variable outValue is initialized before the function is used and then it's assigned a new value when the function is executed
	//		print (outValue); // writes 0 to the console
	//		inAndOut(6, outValue);
	//		print (outValue); // writes 12 to the console
	//
	//		int i; // new int
	//		sevenOut (out i); // i is now 7
	//		print(i); // prints 7 to the console
	//	}
}


////Original Code
//public class OutParam : MonoBehaviour {
//	public GameObject[] GameObjectArray;
//	// Use this for initialization
//	void Start () {
//		
//		ArrayList aList = new ArrayList();
//		GameObject[] gameObjects = (GameObject[])GameObject.FindObjectsOfType( typeof(GameObject) );
//		foreach( GameObject go in gameObjects )
//		{
//			if( go.name == "Sphere" )
//			{
//				aList.Add( go );
//			}
//		}
//		GameObjectArray = aList.ToArray( typeof( GameObject ) ) as GameObject[];
//	}
//	
//	GameObject[] sortObjects( GameObject[] objects )
//	{
//		for( int i = 0; i < objects.Length-1; i++ )
//		{
//			Vector3 PositionA = objects[i].transform.position;
//			Vector3 PositionB = objects[i+1].transform.position;
//			
//			Vector3 VectorToA = PositionA - transform.position;
//			Vector3 VectorToB = PositionB - transform.position;
//
//			float DistanceToA = VectorToA.magnitude;
//			float DistanceToB = VectorToB.magnitude;
//			
//			if( DistanceToA > DistanceToB ) {
//				GameObject temp = objects[i];
//				objects[i] = objects[i+1];
//				objects[i+1] = temp;
//			}
//		}
//		
//		return objects;
//	}
//	
//	// Update is called once per frame
//	void Update () {
//		GameObjectArray = sortObjects( GameObjectArray );
//		for( int i = 0; i < GameObjectArray.Length; i++ )
//		{
//			Vector3 PositionA = GameObjectArray[i].transform.position;
//			Debug.DrawRay( PositionA, new Vector3( 0, i * 0.1f, 0 ), Color.red );
//		}
//	}
//}
