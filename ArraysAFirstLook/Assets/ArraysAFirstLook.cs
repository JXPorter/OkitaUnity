using UnityEngine;
using System.Collections;

public class ArraysAFirstLook : MonoBehaviour
{
	public int[] scores = new int[10];
	public GameObject[] GameObjects;
	public int ArrayLength;
	public int[] Primes = new int[]{1,3,5,7,11,13,17}; // populating an array with predefined data

	void Start()
	{
		// using a while loop to process arrays
		int[] scores = new int[10];
		int i = 0;
		while (i < 10)
		{
			scores [i] = Random.Range (0, 100); // setting the scores index to an int between 0-100.
			int score = scores[i]; // getting a value from the array
			print (score);
			i++;
		}
//		float[] DynamicFloats = new float[ArrayLength];
//
//		Debug.Log (GameObjects.Length);
//		for(int i = 0; i < GameObjects.Length; i++)
//		{
//			GameObjects [i].name = i.ToString ();
//		}
//		foreach (GameObject go in GameObjects)
//		{
//			Debug.Log (go.name);
//		}
	}

	void Update()
	{
		
	}
}

//// Original Code
//public class ArraysAFirstLook : MonoBehaviour {
//	public int[] scores = new int[10];
//	public string[] MyStrings = new string[10];
//	public float[] MyFloats = new float[10];
//	public class MyClass {}
//	public MyClass[] MyClasses = new MyClass[10];
//	public GameObject[] MyGameObjects;
//	public int ArrayLength;
//	public int[] Primes = new int[]{ 1, 3, 5, 7, 11, 13, 17 };
//	
//	// Use this for initialization
//	void Start () {
//		float[] DynamicFloats = new float[ArrayLength];
//		
//		
//		Debug.Log( MyGameObjects.Length );
//		for( int i = 0; i < MyGameObjects.Length; i++ ) {
//			MyGameObjects[i].name = i.ToString();
//		}
//		
//		foreach( GameObject go in MyGameObjects ) {
//			Debug.Log( go.name );
//		}
//	}
//	
//	// Update is called once per frame
//	void Update () {
//	
//	}
//}
