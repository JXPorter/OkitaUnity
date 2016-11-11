using UnityEngine;
using System.Collections;
using System;

//public class EventListener : MonoBehaviour
//{
//	public bool isClose;
//	void Start()
//	// In this Start() of the EventListener, we find the EventDispatcher component of the Main Camera where we assigned the EventDispatcher class.
//	// Once we've found dispatcher in the Main Camera by using GetComponent<EventDispatcher>(), we can then assign the event a new function. 
//	{
//		EventDispatcher dispatcher = GameObject.Find ("Main Camera").GetComponent<EventDispatcher> ();
//		//dispatcher.OnEvent += CallMeMaybe;        // to add a function to Class.Event you use a += and the function name, in this case, dispatcher.OnEvent += CallMeMaybe; without () on the function name.
//		//dispatcher.ProperEvent += CallMePlease;
//		// above dispatcher has OnEvent calling the EventListeners CallMeMaybe function and ProperEvent calls the CallMePlease function
//		dispatcher.ProperEvent += ProximityEvent;    // when ProperEvent() in EventDispatcher is called, ProximityEvent() in EventListner is also called.
//	}
////	void CallMeMaybe()
////	{
////		Debug.Log ("here's my number");
////	}
////
////	void CallMePlease(object sender, EventArgs e)  // having these params allows us to pass in event specific info
////	{
////		Debug.Log (sender);
////		MyEventArgs args = (MyEventArgs)e;
////		Debug.Log (args.MyNumber);
////	}
//
//	public virtual void ProximityEvent(object sender, EventArgs e)
//	{
//		Transform t = sender as Transform;
//		Vector3 targetVector = t.position - transform.position;
//		float distanceToTarget = targetVector.magnitude;
//		if (distanceToTarget > 10) {
//			gameObject.GetComponent<Light> ().intensity = 0.1f;
//		} else {
//			gameObject.GetComponent<Light> ().intensity = 2.0f;
//		}
//		Debug.Log (distanceToTarget);
////		EventArgs<float> eVal = (EventArgs<float>)e;    // this takes the EventArgs e and cast it to the proper generic version of the function we're looking for.
////														// EventArgs<float> eVal is the proper form for setting up a variable for a generic type.
////		if (eVal.Value > 10) {
////			gameObject.GetComponent<Light> ().intensity = 0.1f;
////		} else {
////			gameObject.GetComponent<Light> ().intensity = 2.0f;
////		}
////		Debug.Log (eVal.Value);
//	}
//	// To clean up after an object is destroyed, you should take the function out of the EventHandler. Use -= ProximityEvent to pull the function back out of the 
//	// EventDispatcher's event handler. This is important, otherwise there will be a NullReferenceException Error where the function's object used to be in the event handler.
//	void OnDestroy()
//	{
//		EventDispatcher dispatcher = GameObject.Find ("Main Camera").GetComponent<EventDispatcher> ();
//		dispatcher.ProperEvent -= ProximityEvent;
//	}
//}

// Original Code
public class EventListener : MonoBehaviour
{
	public bool isClose;

	// Use this for initialization
	void Start()
	{
		EventDispatcher dispatcher =
			GameObject.Find("Main Camera").GetComponent<EventDispatcher>();
		dispatcher.ProperEvent += ProximityEvent;
	}

	public virtual void ProximityEvent(object sender, EventArgs e)
	{
		Transform t = sender as Transform;
		Vector3 targetVector = t.position - transform.position;
		float distanceToTarget = targetVector.magnitude;

		if (distanceToTarget > 10)
		{
			gameObject.GetComponent<Light>().intensity = 1.0f;
		} else
		{
			gameObject.GetComponent<Light>().intensity = 3.0f;
		}
		Debug.Log(distanceToTarget);
	}
	
	void OnDestroy()
	{
		EventDispatcher dispatcher =
			GameObject.Find("Main Camera").GetComponent<EventDispatcher>();
		dispatcher.ProperEvent -= ProximityEvent;
	}
}
