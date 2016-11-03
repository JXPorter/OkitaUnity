using UnityEngine;
using System.Collections;
// Once the sealed keyword is placed before the class, it is finalized and the no class can inherit from this sealed class
public sealed class FinalizedObject : MonoBehaviour
{
	// Testing out our CountdownTimer class
	public CountdownTimer countdown;
	//public CountupTimer countdown;

	void Start()
	{
		countdown = new CountdownTimer ();
		countdown.SetTime (3.0f);
		countdown.BeginTimer ();
	}

	void Update()
	{
		if(countdown.Ended())
		{
			Debug.Log ("Your time is up " + Time.fixedTime + " has elapsed.");
		}
	}
}

//// Unity prevents you from trying to inherit from a sealed class - this results in an Error in the Console window
//public class InheritsFromSeal : FinalizedObject
//{
//	void Start()
//	{
//	}
//
//	void Update()
//	{
//	}
//}


//// Original Code
//public sealed class FinalizedObject : MonoBehaviour
//{
//	CountdownTimer countdown;
//	void Start()
//	{
//		countdown = new CountdownTimer();
//		countdown.SetTime(3.0f);
//		countdown.BeginTimer();
//	}
//	void Update()
//	{
//		if (countdown.Ended())
//		{
//			Debug.Log("end");
//		}
//	}
//}
