using UnityEngine;
using System.Collections;

public class Concurrent : MonoBehaviour
{
//	void Start()
//	{
//		StartCoroutine(DelayStatement());
//	}

//	IEnumerator DelayStatement ()                    // function is defined with the IEnumerator interface and identified as DelayStatement.
//	{
//		Debug.Log ("Started at: " + Time.fixedTime);
//		yield return new WaitForSeconds (3.0f);       // creates a concurrent task that then pauses the DelayStatement code block at the yield
//													// once the yield is done it releases the function's operation and allows it to move to the next statement.
//		Debug.Log ("Ended at: " + Time.fixedTime);
//	}

//	public bool StartCoroutines;
//	void Update()
//	{
//		if (StartCoroutines)                          
//		{
//			for(int i = 0; i < 3; i++)
//			{
//				StartCoroutine_Auto (DelayStatement(i));
//			}
//			StartCoroutines = false;
//		}
//	}
//	IEnumerator DelayStatement(int i)						// the three concurrent tasks 0,1,2 started in order. After their WaitForSeonds(), they finish in the same order.
//	{														// Concurrent coroutines are useful for many tasks. In combo with events they can add a great amount of behavioral variety.
//		Debug.Log (i + ") Started at: " + Time.fixedTime);
//		yield return new WaitForSeconds (3.0f);
//		Debug.Log (i + ") Ended at: " + Time.fixedTime);
//	}
	// The above code outputs 0) Started at: 0.9, 1) Started at: 0.9, 2) Started at: 0.9 
	// 0) Ended at: 3.92, 1) Ended at: 3.92, 2) Ended at: 3.92

	// Setting up a Timer
	// Timers like this are not great CPU hogs, but on a mobile device a lot of them can use plenty of CPU resources. With a coroutine we get the same behaviour, but w/o needing to check a timer every frame.
//	public float NextTime;
//	public float WaitTime = 3;
//	void Update()
//	{
//		if (Time.fixedTime > NextTime) 
//		{
//			Debug.Log ("do some task");
//			NextTime = Time.fixedTime + WaitTime;
//		}
//	}

//	// This code uses a repeating timer, but with a coroutine
//	public bool KeepRepeating = true;
//	public bool RestartCoroutine = false;
//	public float RepeatTime = 2.0f;
//
//	void Start()
//	{
//		StartCoroutine (RepeatTimer(RepeatTime));
//	}
//	IEnumerator RepeatTimer (float t)
//	{
//		while (KeepRepeating)
//		{
//			Debug.Log ("Starting timer");
//			yield return new WaitForSeconds (t);   // any code before this yield statement will be executed normally. So you can set up new game objects, add components,
//			// and build any number of systems before the yield. Once the WaitForSeconds() finishes, all the following lines are executed normally.
//			Debug.Log ("Restarting timer");
//		}
//	}
//	void Update()
//	{
//		if(RestartCoroutine)
//		{
//			KeepRepeating = true;
//			StartCoroutine (RepeatTimer(RepeatTime));
//			RestartCoroutine = false;
//		}
//	}

	// Adding ADDITIONAL YIELD statements means that we can have the loop start, do one thing, wait for a moment, do a second thing, and start again.

//	public bool KeepRepeating = true;
//
//	IEnumerator RepeatTimer(float t)
//	{
//		while (KeepRepeating) 
//		{
//			Debug.Log ("do first thing");
//			yield return new WaitForSeconds (t);
//			Debug.Log ("do second thing");
//			yield return new WaitForSeconds (t);
//			Debug.Log ("do third thing");
//			yield return new WaitForSeconds (t);
//			Debug.Log ("start over...");
//		}
//	}


//	// We can make the above code even more interesting by ADDING IN LOGIC, for example:
//
//	public bool KeepRepeating = true;
//
//	void Start()
//	{
//		StartCoroutine (RepeatTimer (2));
//	}
//	IEnumerator RepeatTimer(float t)
//	{
//		while (KeepRepeating) 
//		{
//			int random = Random.Range (0, 3);
//			Debug.Log ("pick an option: " + random);
//			yield return new WaitForSeconds (t);
//			switch (random) {
//			case 0:
//				Debug.Log ("doing first option");
//				yield return new WaitForSeconds (t);
//				break;
//			case 1:
//				Debug.Log ("doing second option");
//				yield return new WaitForSeconds (t);
//				break;
//			case 2:
//				Debug.Log ("doing third option");
//				yield return new WaitForSeconds (t);
//				break;
//			default:
//				Debug.Log ("doing some other option");
//				yield return new WaitForSeconds (t);
//				break;
//			}
//		}
//	}

	// RANDOM DECISIONS WITH LOGIC 
	// This system keeps several tasks in order while allowing for random logic decisions
	// STOPPING COROUTINES - to terminate any coroutines that endlessly loop, use StopAllCoroutines();

	public bool KeepRepeating = true;
	public float WaitTime = 1;
	public bool StopTheRoutine;

	void Start()
	{
		StartCoroutine(DayInTheLife(WaitTime));
		//StartCoroutine ("DayInTheLife", 2);  // to start/stop a specific coroutine use this syntax
											 // this starts the coroutine by a string to identify the function. The 2nd param
											 // is the value given to the coroutine if it acceptss any arguments.
	}

	void Update()
	{
		if (StopTheRoutine) 
		{
			StopAllCoroutines ();              // This will stop all the coroutines
			//StopCoroutine ("DayInTheLife");   // this specifies which coroutine to stop by identifying it with a string
			StopTheRoutine = false;
		}
	}

	IEnumerator DayInTheLife(float t)
	{
		while (KeepRepeating) 
		{
			int rand = Random.Range (0,3);
			Debug.Log ("I woke up, then...");
			yield return new WaitForSeconds (t);
			switch (rand)
			{
			case 0: 
				Debug.Log ("drink some coffee with...");
				yield return new WaitForSeconds (t);
				goto hadCoffee;
				break;
			case 1:
				Debug.Log ("ate toast with...");
				yield return new WaitForSeconds (t);
				goto hadToast;
				break;
			case 2:
				Debug.Log ("ate brains with...");
				yield return new WaitForSeconds (t);
				goto hadBrains;
				break;
			}

		hadCoffee: 
			rand = Random.Range (0, 3);
			switch (rand) 
			{
			case 0:
				Debug.Log ("cream...");
				yield return new WaitForSeconds (t);
				break;
			case 1:
				Debug.Log ("cream and sugar...");
				yield return new WaitForSeconds (t);
				break;
			case 2:
				Debug.Log ("nothing in it...");
				yield return new WaitForSeconds (t);
				break;
			}
			Debug.Log ("then i went to...");
			yield return new WaitForSeconds (t);
			goto goWork;

		hadToast:
			rand = Random.Range (0, 3);
			switch (rand) 
			{
			case 0:
				Debug.Log ("butter and jam...");
				yield return new WaitForSeconds (t);
				break;
			case 1:
				Debug.Log ("butter...");
				yield return new WaitForSeconds (t);
				break;
			case 2: 
				Debug.Log ("nothing on it...");
				yield return new WaitForSeconds (t);
				break;
			}
			Debug.Log ("then I went to...");
			yield return new WaitForSeconds (t);
			goto goWork;

		hadBrains:
			rand = Random.Range (0, 3);
			switch (rand) 
			{
			case 0:
				Debug.Log ("with ear and nose...");
				yield return new WaitForSeconds (t);
				break;
			case 1:
				Debug.Log ("just an ear...");
				yield return new WaitForSeconds (t);
				break;
			case 2:
				Debug.Log ("strawberries and bananas...");
				yield return new WaitForSeconds (t);
				break;
			}
			Debug.Log ("then i went to...");
			yield return new WaitForSeconds (t);
			goto goWork;

		goWork:
			rand = Random.Range (0, 3);
			switch (rand)
			{
			case 0:
				Debug.Log ("the office...");
				yield return new WaitForSeconds (t);
				break;
			case 1:
				Debug.Log ("the gym...");
				yield return new WaitForSeconds (t);
				break;
			case 2: 
				Debug.Log ("the graveyard...");
				yield return new WaitForSeconds (t);
				break;
			}
			Debug.Log ("and after went home to sleep...");
			yield return new WaitForSeconds (t);

		}
	}
}
//// Original Code
//public class Concurrent : MonoBehaviour
//{
//	
//	public bool StartCoroutines;
//	
//	public float NextTime;
//	public float WaitTime = 3;
//	
//	public bool KeepRepeating = true;
//	public bool RestartCoroutine = false;
//	public float RepeatTime = 2.0f;
//	public int next = -1;
//	
//
//	
//	IEnumerator Gulp(int gulps)
//	{
//		int gulp = 0;
//		while (gulp < gulps)
//		{
//			Debug.Log("Gulp...");
//			yield return new WaitForSeconds(0.4f);
//			++gulp;
//		}
//	}
//
//	IEnumerator DayInTheLife(float t)
//	{
//		while (KeepRepeating)
//		{
//			int rand = Random.Range(0, 3);
//			Debug.Log("I woke up, then...");
//			yield return new WaitForSeconds(t);
//			
//			switch (rand)
//			{
//				case 0:
//					Debug.Log("drank some coffee with...");
//					yield return new WaitForSeconds(t);
//					StartCoroutine("Gulp", 3);
//					goto hadCoffee;
//					break;
//				case 1:
//					Debug.Log("ate toast with...");
//					yield return new WaitForSeconds(t);
//					goto hadToast;
//					break;
//				case 2:
//					Debug.Log("ate brains with...");
//					yield return new WaitForSeconds(t);
//					goto hadBrains;
//					break;
//			}
//			
//			hadCoffee:
//			rand = Random.Range(0, 3);
//			switch (rand)
//			{
//				case 0:
//					Debug.Log("cream...");
//					yield return new WaitForSeconds(t);
//					break;
//				case 1:
//					Debug.Log("cream and sugar...");
//					yield return new WaitForSeconds(t);
//					break;
//				case 2:
//					Debug.Log("nothing in it...");
//					yield return new WaitForSeconds(t);
//					break;
//			}
//			
//			Debug.Log("then i went to...");
//			yield return new WaitForSeconds(t);
//			goto goWork;
//		
//			hadToast:
//			rand = Random.Range(0, 3);
//			switch (rand)
//			{
//				case 0:
//					Debug.Log("butter and jam...");
//					yield return new WaitForSeconds(t);
//					break;
//				case 1:
//					Debug.Log("butter...");
//					yield return new WaitForSeconds(t);
//					break;
//				case 2:
//					Debug.Log("nothing on it...");
//					yield return new WaitForSeconds(t);
//					break;
//			}
//			
//			Debug.Log("then i went to...");
//			yield return new WaitForSeconds(t);
//			goto goWork;
//		
//			hadBrains:
//			rand = Random.Range(0, 3);
//			switch (rand)
//			{
//				case 0:
//					Debug.Log("with ear and nose...");
//					yield return new WaitForSeconds(t);
//					break;
//				case 1:
//					Debug.Log("just an ear...");
//					yield return new WaitForSeconds(t);
//					break;
//				case 2:
//					Debug.Log("strawberries and banannas...");
//					yield return new WaitForSeconds(t);
//					break;
//			}
//			
//			Debug.Log("then i went to...");
//			yield return new WaitForSeconds(t);
//			goto goWork;
//
//			goWork:
//			rand = Random.Range(0, 3);
//			switch (rand)
//			{
//				case 0:
//					Debug.Log("the office...");
//					yield return new WaitForSeconds(t);
//					break;
//				case 1:
//					Debug.Log("the gym...");
//					yield return new WaitForSeconds(t);
//					break;
//				case 2:
//					Debug.Log("the graveyard...");
//					yield return new WaitForSeconds(t);
//					break;
//			}
//			
//			Debug.Log("and after went home to sleep...");
//			yield return new WaitForSeconds(t);
//		}
//	}
//	
//	IEnumerator RepeatTimer(float t)
//	{
//		while (KeepRepeating)
//		{
//			int random = Random.Range(0, 3);
//			
//			Debug.Log("pick a an option: " + random);
//			
//			yield return new WaitForSeconds(t);
//			
//			switch (random)
//			{
//				case 0:
//					Debug.Log("doing first option");
//					yield return new WaitForSeconds(t);
//					break;
//				
//				case 1:
//					Debug.Log("doing second option");
//					yield return new WaitForSeconds(t);
//					break;
//				
//				case 2:
//					Debug.Log("doing third option");
//					yield return new WaitForSeconds(t);
//					break;
//
//				default:
//					Debug.Log("doing some other option");
//					yield return new WaitForSeconds(t);
//					break;
//			}
//		}
//	}
//	
//	public bool StopTheRoutine;	
//	
//	public GameObject[] lotsOfObjects;
//	
//	IEnumerator FillUpObjects()
//	{
//		lotsOfObjects = new GameObject[40000];
//		for (int i = 0; i < 40000; i++)
//		{
//			GameObject g = GameObject.CreatePrimitive(PrimitiveType.Cube);
//			g.name = i.ToString() + "_cube";
//			float rx = Random.Range(-1000, 1000);
//			float ry = Random.Range(-1000, 1000);
//			float rz = Random.Range(-1000, 1000);
//			g.transform.position = new Vector3(rx, ry, rz);
//			g.transform.localScale = new Vector3(10, 10, 10);
//			lotsOfObjects [i] = g;
//			yield return null;
//		}
//	}
//	
//	IEnumerator MultiStep()
//	{
//		Debug.Log("First");
//		yield return null;
//		Debug.Log("Second");
//		yield return null;
//		Debug.Log("Third");
//		yield return null;
//		Debug.Log("Fourth");
//		yield return null;
//	}
//	
//	void Start()
//	{
//		StartCoroutine("DayInTheLife", 2);
//	}
//	
//	void Update()
//	{
//		if (Input.GetMouseButtonDown(0))
//		{
//			MultiStep();
//		}
//		
//		if (StopTheRoutine)
//		{
//			StopCoroutine("DayInTheLife");
//			StopTheRoutine = false;
//		}
//		
//		if (RestartCoroutine)
//		{
//			KeepRepeating = true;
//			StartCoroutine(RepeatTimer(RepeatTime));
//			RestartCoroutine = false;
//		}
//		
//		if (StartCoroutines)
//		{
//			for (int i = 0; i < 3; i++)
//			{
//				StartCoroutine_Auto(DelayStatement(i));
//			}
//			StartCoroutines = false;
//		}
//	}
//	
//	
//	IEnumerator DelayStatement(int i)
//	{
//		Debug.Log(i + " ) Started at: " + Time.fixedTime);
//		
//		yield return new WaitForSeconds(3.0f);
//		
//		Debug.Log(i + " ) Ended at: " + Time.fixedTime);
//	}
//}
