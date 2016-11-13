using UnityEngine;
using System.Collections;
using System.Collections.Generic;             // this directive includes Dictionary type

public class Dictionaries : MonoBehaviour
{
	// declare a new Dictionary called MyDictionary  - this data type allows us to use a string to find a value in the Dictionary
	// The structure of Dictionary is <first type, second type> where the first type you use is called a key and second type is the value 
	// that is associated with that key. They key must always be unique throughout the dictionary.
	public Dictionary<string,int> MyDictionary;
	public string[] objectNames;
	public int[] objectCounts;

	public GameObject[] ObjectStack;

	void Start()
	{
//		MyDictionary = new Dictionary<string,int> ();
//		MyDictionary.Add ("Zombies",10);         // adds a value to the dictionary - pushes a string with associated values into the variable
//		// prints 10
//		Debug.Log(MyDictionary["Zombies"]);     // to retrieve values we use ["KeyName"], which looks like we are addressing an array. This returns the associated value.
//	
//		Dictionary<int, Object> obs = new Dictionary<int, Object> ();
//		Object[] allObjects = GameObject.FindObjectsOfType (typeof(Object)) as Object[];
//		for(int i = 0; i < allObjects.Length; i++)
//		{
//			obs.Add(i, allObjects[i]);          // adds each of the objects to the obs dictionary with a key of i and a value of allObjects[i]
//			Debug.Log (obs[i]);					// prints out all of the objects in the scene to the console panel
//			//Debug.Log (obs[19]);              // this should print out the name of the object at index 19 of obs dictionary
//		}
//
//		// lists GameObject names in the scene
//		Dictionary<string, int> SceneDictionary = new Dictionary<string, int>();   // create a new Dictionary called SceneDictionary
//		// get array of all of the objects in the scene
//		GameObject[] gos = GameObject.FindObjectsOfType(typeof(GameObject)) as GameObject[];
//		// iterate through them and add them to the dictionary
//		foreach(GameObject go in gos)
//		{
//			// check if we've already found an object with the GameObject's name
//			// the argument passed to ContainsKey must match the type used to initialze the dictionary, in this case a string.
//			bool containsKey = SceneDictionary.ContainsKey(go.name);
//
//			// Logic - if the dictionary already contains this key, then we need to increment the value in the dictionary of that key += 1.
//			// If the value is new and ContainsKey = false, then we add a new entry to the dictionary.
//			if (containsKey) {
//				SceneDictionary [go.name] += 1;
//			} else {
//				SceneDictionary.Add (go.name, 1);
//			}
//		}
//		// initialize the size of the string[] and the int[] to the size of the dictionary
//		SceneDictionary.Remove("Main Camera");             // If we don't want the Main Camera in the list, use this statement before copying the Dictionary to the string and int []s
//		objectNames = new string[SceneDictionary.Keys.Count];
//		objectCounts = new int[SceneDictionary.Values.Count];
//		SceneDictionary.Keys.CopyTo (objectNames, 0);      // assign all of the values of the keys to the objectNames[].
//		SceneDictionary.Values.CopyTo (objectCounts, 0);   // assign all of the values of the keys to the objectCounts[].

		// STACKS - an array with some added features. You get a Push(), a Pop(), and a Peek() function. The top of the stack is where all the functions perform operations
		// Push() - adds an object to the top of the stack.
		// Peek() - lets you look at the contents of the object on top of the stack
		// Pop() - means to take the item off the top of the stack.

		GameObject[] gos = GameObject.FindObjectsOfType(typeof(GameObject)) as GameObject[];
			// create a new stack
		Stack objectStack = new Stack();
		// assign objects to the stack using Push()
		foreach(GameObject go in gos)
		{
			objectStack.Push (go);
		}
		// initialize the class scope ObjectStack to view in the Inspector panel
		ObjectStack = new GameObject[objectStack.Count];
		// copy the stack to the array in Unity
		objectStack.CopyTo(ObjectStack, 0);
	}



	void Update()
	{
		
	}
}

//// Original Code
//public class Dictionaries : MonoBehaviour
//{
//	public Dictionary<string,int> MyDictionary;
//	public string[] objectNames;
//	public int[] objectCounts;
//	
//	public GameObject[] ObjectStack;
//	// Use this for initialization
//	void Start ()
//	{
//		GameObject[] gos = GameObject.FindObjectsOfType( typeof( GameObject ) ) as GameObject[];
//		#region Dictionary
//		MyDictionary = new Dictionary<string,int>();
//		MyDictionary.Add("Zombies",10);
//		//prints 10;
//		Debug.Log ( MyDictionary["Zombies"] );
//		
//		//int and object
//		Dictionary<int, Object> obs = new Dictionary<int, Object>();
//		Object[] allObjects = GameObject.FindObjectsOfType( typeof( Object ) ) as Object[];
//
//		for( int i = 0; i < allObjects.Length; i++ ) {
//			obs.Add( i, allObjects[i] );
//			Debug.Log( obs[i] );
//		}
//		
//		//lists GameObject names in the scene
//		Dictionary<string, int> SceneDictionary = new Dictionary<string, int>();
//		foreach( GameObject go in gos )
//		{
//			
//			bool containsKey = SceneDictionary.ContainsKey(go.name);
//			if( containsKey )
//			{
//				SceneDictionary[go.name] += 1;
//			}
//			else
//			{
//				SceneDictionary.Add(go.name, 1);
//			}
//		}
//		objectNames = new string[SceneDictionary.Keys.Count];
//		objectCounts = new int[SceneDictionary.Values.Count];
//		SceneDictionary.Keys.CopyTo(objectNames, 0);
//		SceneDictionary.Values.CopyTo(objectCounts, 0);
//		SceneDictionary.Remove("Main Camera");
//		#endregion
//		
//		#region Stack
//		//create a new stack
//		Stack objectStack = new Stack();
//		//assign objects to the stack using push
//		foreach( GameObject go in gos )
//		{
//			objectStack.Push( go );
//		}
//		//initialize the class scope ObjectStack to view in the inspector panel
//		ObjectStack = new GameObject[objectStack.Count];
//		//copy the stack to the array in Unity
//		objectStack.CopyTo(ObjectStack, 0 );
//		#endregion
//	}
//}
