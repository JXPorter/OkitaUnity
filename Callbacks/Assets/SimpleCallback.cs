using UnityEngine;
using System.Collections;

// CALLBACKS - a callback is a function that is executed when some other function is done with its work. E.g. it can be used when we start spawning monsters in a level and want
// to know when all of the monsters have finished populating the level. A reference between objects can't be made unless both are present in the scene at the same time.
// Managing when and how a function is called is a simple matter of setting up a delegate to call when a task is done. Once the task is complete, the delegate is called and
// any assigned functions are executed. 
// NOTE: A function that uses a function as a callback receives the value of that function once the callback is complete.
//
//public class SimpleCallback : MonoBehaviour
//{
//	public delegate void delegateCaller();             // create a delegate called delegateCaller() that allows us a place to assign functions
//	delegateCaller caller = FunctionToCall();   // a delegateCaller called caller is assigned FunctionToCall().
//	public static void FunctionToCall()
//	{
//		Debug.Log ("You called?");
//	}
//
//	void Start()
//	{
//		StartCoroutine (StartsATask());          // we begin our coroutine called StartsATask()
//	}
//
//	IEnumerator StartsATask()                 // we create a coroutine called StartsATask()
//	{
//		Debug.Log ("starting");           
//		yield return new WaitForSeconds (1);    //tells Unity to hold off on executing the next line for 1 second
//		Debug.Log ("finishing");
//		caller ();                            // calls the assigned delegate caller() which was assigned FunctionToCall(). FunctionToCall() is the callback in this case.
//	}
//
//	void Update()
//	{
//		
//	}
//}

//// DYNAMIC CALLBACK ASSIGNMENT - to gain flexiblity we will want to be able to switch what function is called back. Which means that different coroutines can be launched
//// with different calls being made when they complete.
//public class SimpleCallback : MonoBehaviour
//{
//	delegate void delegateCaller();
//	public void PersonalCall()
//	{
//		Debug.Log ("wassap?");
//	}
//
//	public void BusinessCall()
//	{
//		Debug.Log ("Thank you for calling");
//	}
//
//	void Start()
//	{
//		StartCoroutine(StartsATask(PersonalCall));
//		StartCoroutine (StartsATask(BusinessCall));
//	}
//	IEnumerator StartsATask(delegateCaller callThis)  // 
//	{
//		Debug.Log ("starting");
//		yield return new WaitForSeconds (1);
//		Debug.Log ("finishing");
//		callThis ();
//	}
//
//	void Update()
//	{
//		
//	}
//}

public class SimpleCallback : MonoBehaviour
{
	public delegate void delegateCaller();

	public delegate void delegateWWW(WWW www);

	void Start()
	{
		StartCoroutine (getWWW("http://unity3d.com/robots.txt", readText));
		StartCoroutine (getWWW("http://dingo.care2.com/pictures/greenliving/uploads/2011/05/cat-eye-closeup.jpg", readTexture));  // gets an image from the net
	}

	public void readText(WWW www)
	{
		Debug.Log (www.text);
	}

	public void readTexture(WWW www)
	{
		Texture2D texture = www.texture;
		gameObject.GetComponent<Renderer> ().material.SetTexture ("_MainTex", texture);   // this reads an image from the internet and assigns it to the MainTex of the 
																						 // default shader that is added to a default sphere.
	}

	IEnumerator getWWW(string url, delegateWWW funcWWW)
	{
		WWW www = new WWW (url);
		yield return www;
		funcWWW (www);
	}

	void Update()
	{
		
	}


}
//// Original Code
//public class SimpleCallback : MonoBehaviour {
//	
//	public delegate void delegateCaller();
//	
//	public delegate void delegateWWW( WWW www );
//	
//	delegateCaller caller = FunctionToCall;
//
//	void Start () {
//		
//		StartCoroutine( getWWW( "http://unity3d.com/robots.txt" , readText)  );
//		StartCoroutine( getWWW( "http://upload.wikimedia.org/wikipedia/commons/thumb/e/ea/Clementine_albedo_simp750.jpg/800px-Clementine_albedo_simp750.jpg" , readTexture)  );
//	}
//	bool isDone;
//	void Update()
//	{
//		if( isDone )
//		{
//			//do something
//		}
//	}
//	public void readTexture( WWW www )
//	{
//		Texture2D texture = www.texture;
//		gameObject.GetComponent<Renderer>().material.SetTexture( "_MainTex", texture );
//	}
//	
//	public void readText( WWW www )
//	{
//		Debug.Log( www.text );
//	}
//	
//	IEnumerator getWWW( string url, delegateWWW funcWWW)
//	{
//		WWW www = new WWW(url);
//		yield return www;
//		funcWWW( www );
//	}
//	
//	static void FunctionToCall()
//	{
//		Debug.Log( "You called?" );
//	}
//	
//	void StartingMessage()
//	{
//		Debug.Log( "im starting" );
//	}
//	
//	void EndingMessage()
//	{
//		Debug.Log( "im done" );
//	}
//	
//	IEnumerator StartEndTask(delegateCaller startFunc, float delay, delegateCaller endFunc)
//	{
//		startFunc();
//		yield return new WaitForSeconds( delay );
//		endFunc();
//	}
//	
//	IEnumerator StartsATask()
//	{
//		Debug.Log( "starting" );
//		yield return new WaitForSeconds(1);
//		Debug.Log( "finishing" );
//		caller();
//	}
//
//	public void PersonalCall()
//	{
//		Debug.Log ( "this is function" );
//	}
//	
//	public void BusinessCall()
//	{
//		Debug.Log ( "Thank you for calling." );
//	}
//	
//	IEnumerator StartsPerClassTask( SimpleCallback callThis )
//	{
//		Debug.Log( "starting" );
//		yield return new WaitForSeconds(2);
//		Debug.Log( "finishing" );
//
//		//this is quite specific
//		callThis.PersonalCall();
//	}
//
//}