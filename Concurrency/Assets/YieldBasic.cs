using UnityEngine;
using System.Collections;

// Concurrency or Coroutines
// IEnumerator allows us the use of the yield keyword. Yield allows the computer to continue with a function and allow something like our Update() to loop
// back to the function using the yield statement. E.g. if we had a task that takes longer than a single Update frame to complete, then we could use a function
// with yield. This works only with a function that is an IEnumerator.

// YieldBasic has a very slow function that fills up the screen with 10000 objects. Without a coroutine this would cause Unity3d to freeze for a few seconds before it could continue
// on executing the next statements in code. So we use a coroutine to keep Unity3d running smoothly.
public class YieldBasic : MonoBehaviour {

	// Use this for initialization
	void Start ()
	{
		StartCoroutine ("FillUpObjects");           // StartCoroutine() calls the IEnumerator as a coroutine. A coroutine is a great method to start an unusually long function
													// and not have to wait for its completion before the rest of some code is executed. We just come back to it later and check on
													// how it's doing.
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	IEnumerator FillUpObjects()								// the return type of this function is IEnumerator
	{
		GameObject[] lotsOfObjects = new GameObject[10000];
		for (int i = 0; i < 10000; i++)
		{
			GameObject g = GameObject.CreatePrimitive (PrimitiveType.Sphere);
			g.name = i.ToString () + " _cube";
			float rx = Random.Range (-1000,1000);
			float ry = Random.Range (-1000,1000);
			float rz = Random.Range (-1000,1000);
			g.transform.position = new Vector3 (rx,ry,rz);
			g.transform.localScale = new Vector3 (10,10,10);
			lotsOfObjects [i] = g;
			yield return null;                                 // we add yield return null so that the IEnumerator interface has something to return.
		}
	}
}
