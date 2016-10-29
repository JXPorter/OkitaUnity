using UnityEngine;
using System.Collections;
public class ZombieState : MonoBehaviour
{
	enum ZState
	{
		idleing,
		wandering
	}
	ZState MyState;

	float stateTimer;
	float closestDistance;
	float furthestDistance;
	GameObject closestGameObject;
	GameObject furthestGameObject;

	void Start()
	{
		stateTimer = 0.1f;
		MyState = ZState.idleing;
		// Since the closestDistance variable starts off at 0, we need this to be a large number instead, otherwise nothing will be closer than the default value.
		// This can be fixed with the very large number of Mathf.Infinity
		closestDistance = Mathf.Infinity;
	}

	void Update()
	{
		// this switch statement of different goto labels
		switch(MyState)
		{
		case ZState.idleing:
			goto Idleing;
		case ZState.wandering:
			goto Wandering;
		default:
			break;
		}
		// these goto labels create our basic starting place for building up some more interesting behaviors. 
		// In Ideling, we add in a system to hold in the loop there for moment before moving on.
		Idleing:
		stateTimer -= Time.deltaTime;  // the time passed between each frame
		if(stateTimer < 0.0f)
		{
			MyState = ZState.wandering;
			stateTimer = 3.0f;
			closestDistance = Mathf.Infinity; // must reset these two values just before running the LookAround(), or we won't be able to pick new objects each time it's run
			furthestDistance = 0f; // ""
			LookAround ();
		}
			return;

		Wandering:
		stateTimer -= Time.deltaTime;
		MoveAround ();
			if (stateTimer < 0.0f)
			{
				MyState = ZState.idleing;
				stateTimer = 3.0f;
			}
		return;	    // the return keyword tells the Update() to stop evaluating code at the return and start over from the top.	
	}

	void LookAround()
	{
		// this looks through all og the GameObjects in the scene and prepares an array (called Zombies) populated with every game object
		GameObject[] Zombies = (GameObject[])GameObject.FindObjectsOfType (typeof(GameObject));
		// With the array, we can iterate through each game object looking for another zombie
		foreach(GameObject go in Zombies)
		{
			// this checks each game object to see if it has a ZombieState component attached to it. This ensures that we don't iterate through things
			// like the ground plane, light, or main camera
			ZombieState z = go.GetComponent<ZombieState> ();
			// this line checks to see if the go has no ZombieState attached or an instance of the object itself
			if (z == null || z == this) 
			{
				continue; // tells the foreach loop to move on to the next index in the array
			}
			Vector3 v = go.transform.position - transform.position; // we get a Vector3 which is the difference  between the transform.position of the zombie who is checking
			// the distances to the GameObject go in the array of Zombies.
			float distanceToGo = v.magnitude; // Vector3 v is converted into a float that reps the distance to the zombie we're looking at.
			//Once we have a distance, we compare that value to the closes distance and set the closestGameObject to the GameObject if it's closer than the last closestDistance
			// do the same for furthestDistance
			// this populates the closestGameObject and furthestGameObject values.
			if(distanceToGo < closestDistance)
			{
				closestDistance = distanceToGo;
				closestGameObject = go;
			}
			if(distanceToGo > furthestDistance)
			{
				furthestDistance = distanceToGo;
				furthestGameObject = go;
			}
		}
	}

	void MoveAround()
	{
		Vector3 MoveAway = (transform.position - closestGameObject.transform.position).normalized;  //normalized limits values to a magnitude of 1
		Vector3 MoveTo = (transform.position - furthestGameObject.transform.position).normalized;
		Vector3 directionToMove = MoveAway - MoveTo; // this gives us a push away from the closes object and moves the zombie toward the furthest object
		transform.forward = directionToMove; // turns the zombie in this direction
		gameObject.GetComponent<Rigidbody>().velocity = directionToMove * Random.Range (10, 30) * 0.1f; // gives zombie push in that direction
		// Lines are drawn to show us what is going on - they are drawn closest, furthest, and toward the direction of movement and the zombie.
		Debug.DrawRay (transform.position, directionToMove, Color.blue);
		Debug.DrawLine (transform.position, closestGameObject.transform.position, Color.red);
		Debug.DrawLine (transform.position, furthestGameObject.transform.position, Color.green);
	}
}
//// Original Code
//public class ZombieState : MonoBehaviour
//{
//	
//	enum ZState
//	{
//		idleing,
//		wandering,
//	}
//	ZState MyState;
//	
//	float stateTimer;
//	public float closestDistance;
//	public float furthestDistance;
//	public GameObject closestGameObject;
//	public GameObject furthestGameObject;
//
//	// Use this for initialization
//	void Start()
//	{
//		stateTimer = 0.1f;
//		MyState = ZState.idleing;
//		closestDistance = Mathf.Infinity;
//	}
//	
//	// Update is called once per frame
//	void Update()
//	{
//		switch (MyState)
//		{
//			case ZState.idleing:
//				goto Ideling;
//			case ZState.wandering:
//				goto Wandering;
//			default:
//				break;
//		}
//		
//		Ideling:
//		stateTimer -= Time.deltaTime;
//
//		if (stateTimer < 0.0f)
//		{
//			MyState = ZState.wandering;
//			stateTimer = Random.Range(20, 50) * 0.1f;
//
//			closestDistance = Mathf.Infinity;
//			furthestDistance = 0f;
//			LookAround();
//		}
//		return;
//	
//		Wandering:
//		stateTimer -= Time.deltaTime;
//		MoveAround();
//
//		if (stateTimer < 0.0f)
//		{
//			MyState = ZState.idleing;
//			stateTimer = Random.Range(5, 10) * 0.1f;
//		}
//		return;
//	}
//	
//	virtual public void LookAround()
//	{
//		GameObject[] Zombies = (GameObject[])GameObject.FindObjectsOfType(typeof(GameObject));
//
//		foreach (GameObject go in Zombies)
//		{
//			ZombieState z = go.GetComponent<ZombieState>();
//			if (z == null || z == this)
//			{
//				continue;
//			}
//			
//			Vector3 v = go.transform.position - transform.position;
//			float distanceToGo = v.magnitude;
//			
//			if (distanceToGo < closestDistance)
//			{
//				closestDistance = distanceToGo;
//				closestGameObject = go;
//			}
//			
//			if (distanceToGo > furthestDistance)
//			{
//				furthestDistance = distanceToGo;
//				furthestGameObject = go;
//			}
//		}
//	}
//	
//	void MoveAround()
//	{
//		Vector3 MoveAway = (transform.position - closestGameObject.transform.position).normalized;
//		Vector3 MoveTo = (transform.position - furthestGameObject.transform.position).normalized;
//		Vector3 directionToMove = MoveAway - MoveTo;
//		transform.forward = directionToMove;
//		gameObject.GetComponent<Rigidbody>().velocity = directionToMove * Random.Range(10, 20) * 0.235f;
//		Debug.DrawRay(transform.position, directionToMove, Color.blue);
//		Debug.DrawLine(transform.position, closestGameObject.transform.position, Color.red);
//		Debug.DrawLine(transform.position, furthestGameObject.transform.position, Color.green);
//	}
//}
