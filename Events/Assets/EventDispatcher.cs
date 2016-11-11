using UnityEngine;
using System.Collections;
using System;                      // The EventArgs type is located in System, so we need to add the using System directive. EventArgs are used to pass parameters to anyone
								   // listening to the event.
//
//// EVENTS - Any number of EventListeners can be added to the scene. 
//// Any number of functions can be added to the event OnEvent in the EventDispatcher class
////public delegate void EventHandler();      // first we need a delegate to assign any functions to
//public delegate void ProperEventHandler(object sender, EventArgs e);     // now a delegate with a parameter list
//
////class MyEventArgs : EventArgs              // Important to know that customized event arguments allow for specific event info to be passed to anyone listening for this event
////{
////	public string MyNumber;
////	public MyEventArgs()
////	{
////		MyNumber = "I just met you";
////	}
////}
//
//public class EventArgs<T> : EventArgs      // Using a generic type event with our EventArgs class. Rather than having to figure out every situation ahead of time, it's easier to use generic event type
//{
//	public EventArgs(T v)             // this does two things: 1. it means we can put any type of data into the EventArgs, 2. we get to pass the generic data to the listener
//	{
//		Value = v;
//	}
//	public T Value;
//}
//public class EventDispatcher : MonoBehaviour
//{
//	public event EventHandler OnEvent;   // the keyword event allows us to assign an event variable to assign functions to. 
//										 // an event means that we can assign a function to a variable. When an event is used all functions assigned to it will be called.
//	public event ProperEventHandler ProperEvent;
//	public bool SendEvent;               // a public bool called SendEvent, initialized to false by default
//	void Start()
//	{
//		
//	}
//
//	private bool isClose;
//	void Update()
//	{
////		if(SendEvent)
////		{
////			OnEvent ();                     // if SendEvent is true, then it will execute OnEvent() and then SendEvent will be set back to false.
////			//ProperEvent(this, new MyEventArgs());  // MyEventArgs() is a class so it needs to be instanced with new before it's used. 
////			// In param list we use this as the sender and new MyEventArgs() as the EventArgs.
////			ProperEvent(this, new EventArgs<float>(3.14f));  // when ProperEvent() in EventDispatcher is called, ProximityEvent() in EventListner is also called.
////			SendEvent = false;
////		}
//
//		GameObject[] Lights = GameObject.FindGameObjectsWithTag ("Lights") as GameObject[];
//		foreach(GameObject l in Lights)
//		{
//			Vector3 targetVector = l.transform.position - transform.position;
//			float distanceToTarget = targetVector.magnitude;
//			EventListener el = l.GetComponent<EventListener> ();     // we need to make a reference to EventListener in the script to determine whether or not we're close to the
//																	// particular object or not. Then we send gameObject.transform as the sender.
//			if(distanceToTarget <= 10 && !el.isClose)
//			{
//				ProperEvent (gameObject.transform, new EventArgs<float> (distanceToTarget));
//				el.isClose = true;
//			}
//			if(distanceToTarget > 10 && el.isClose)
//			{
//				ProperEvent (gameObject.transform, new EventArgs<float> (distanceToTarget));
//				el.isClose = false;
//			}
//		}
//		// Here we use events to check to see if we're near the light target. We use the same sort of function to check for our distance away from the target. If we 're close 
//		// we set isClose to true, and if we're > 10, we set isClose to false. This way we prevent the event from firing every time Update() is evaluated.
//		GameObject target = GameObject.Find ("Point light");
//		Vector3 TargetVector = target.transform.position - transform.position;  // making a distance and light intensity calculation every frame is wasteful, and better served by a simple event when the player approaches or leaves the light
//		float DistanceToTarget = TargetVector.magnitude;
//		if (DistanceToTarget <= 10 && !isClose) 
//		{
//			ProperEvent(this, new EventArgs<float>(DistanceToTarget));
//			isClose = true;
//		} 
//		if(DistanceToTarget > 10 && isClose)
//		{
//			ProperEvent (this, new EventArgs<float> (DistanceToTarget));
//			isClose = false;
//		}
//	}
//}



// Original Code
public delegate void ProperEventHandler(object sender,EventArgs e);

public class EventArgs<T> : EventArgs
{
	public EventArgs(T v)
	{
		Value = v;
	}

	public T Value;
}

public class EventDispatcher : MonoBehaviour
{
	
	public event ProperEventHandler ProperEvent;
	
	// Use this for initialization
	void Start()
	{
	}
	
	// Update is called once per frame
	void Update()
	{
		GameObject[] Lights =
			GameObject.FindGameObjectsWithTag("Lights") as GameObject[];
		foreach (GameObject l in Lights)
		{
			Vector3 targetVector =
				l.transform.position - transform.position;
			float distanceToTarget =
				targetVector.magnitude;
			EventListener el = l.GetComponent<EventListener>();
			if (distanceToTarget <= 10 && !el.isClose)
			{
				ProperEvent(gameObject.transform,
				            new EventArgs<float>(distanceToTarget));
				el.isClose = true;
			}
			
			if (distanceToTarget > 10 && el.isClose)
			{
				ProperEvent(gameObject.transform,
				            new EventArgs<float>(distanceToTarget));
				el.isClose = false;
			}
		}
	}
}
