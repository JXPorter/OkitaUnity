using UnityEngine;
using System.Collections;

public class CollisionStack : MonoBehaviour
{
	// store the stack and array
	public GameObject[] HitList;
	public GameObject[] QueueList;
	public Stack HitStack;
	public Queue HitQueue;         // Queues are similar to Stacks, but they are FIFO - first in first out, instead of LIFO

	void Start()
	{
		HitStack = new Stack ();
		HitQueue = new Queue ();
	}
	void OnTriggerEnter(Collider other)   // use the incoming parameter other and the game Object that collider is attached to
	{
		if (!HitStack.Contains (other.gameObject))   // Stack contains a member function called Contains() where we can use other.gameObject to check through entire stack
			// to see if object has already been added. if not, then we use Push() to add the gameObject component of other to stack.
		{
			HitStack.Push (other.gameObject);
			HitList = new GameObject[HitStack.Count];    // Stack copies its contents for viewing in the Inspector
			HitStack.CopyTo (HitList, 0);
		}

		// for HitQueue
		// this does the same thing as the HitStack
		// when the capsule touches another object its added to the queue, and then copied to a list so that we can see the objects in the Inspector
		if(!HitQueue.Contains(other.gameObject))
		{
		    QueueList = new GameObject[HitQueue.Count];
			HitQueue.Enqueue (other.gameObject);
			HitQueue.CopyTo (QueueList, 0);
		}
	}

	void Update()
	{
		if(HitStack.Count > 0)
		{
			GameObject lastObject = HitStack.Peek () as GameObject;      // Peek() observes the last object added to the stack. assigns the data to lastObject
			Debug.DrawLine (transform.position, lastObject.transform.position);
			if(HitList[0] == lastObject)
			{
				StartCoroutine ("popTheStack");  
			}
		}

		// for HitQueue
		if(HitQueue.Count > 0)
		{
			GameObject firstObject = HitQueue.Peek () as GameObject;
			Debug.DrawLine (transform.position, firstObject.transform.position, Color.red);
			if(QueueList[0] == firstObject)
			{
				StartCoroutine ("dequeueTheQueue");
			}
		}
		
	}
	IEnumerator popTheStack()                  // To remove an object from the stack, we use Pop(). So when a condition is met, we can reduce the stack by one object.
	{
		// this function will be started as a Coroutine. Every 2 seconds we'll pop the stack and draw a line to the next object at the top of the stack.
		// After moving the capsule around in the scene, we'll collect some targets to draw a line to. 
		// Every 2s we move down the list and reduce the number of items in the stack
		yield return new WaitForSeconds (2);
		if(HitStack.Count > 0)
		{
			HitStack.Pop ();
			HitList = new GameObject[HitStack.Count];
			HitStack.CopyTo (HitList, 0);
			StopCoroutine ("popTheStack");
		}
	}

	IEnumerator dequeueTheQueue()
	{
		// When we drag the capsule around the scene we will see a Gizmo line drawn from both the first and the last objects that the capsule touched.
		yield return new WaitForSeconds (2);
						if(HitQueue.Count > 0)
						{
			HitQueue.Dequeue ();                       // we used Dequeue to cut our queue down every two seconds.
			QueueList = new GameObject[HitQueue.Count];
			HitQueue.CopyTo (QueueList, 0);
			StopCoroutine ("dequeueTheQueue");
						}
	}
}

//// Original Code
//public class CollisionStack : MonoBehaviour {
//	public GameObject[] HitList;
//	public GameObject[] QueueList;
//	public Stack HitStack;
//	public Queue HitQueue;
//	#region Start
//	void Start()
//	{
//		HitStack = new Stack();
//		HitQueue = new Queue();
//	}
//	#endregion
//	
//	
//	void OnTriggerEnter( Collider other )
//	{
//		#region TriggerStack
//		if( !HitStack.Contains( other.gameObject ) )
//		{
//			HitStack.Push( other.gameObject );
//			HitList = new GameObject[HitStack.Count];
//			HitStack.CopyTo(HitList, 0);
//		}
//		#endregion
//		#region TriggerQueue
//		if( !HitQueue.Contains( other.gameObject ) )
//		{
//			HitQueue.Enqueue( other.gameObject );
//			QueueList = new GameObject[HitQueue.Count];
//			HitQueue.CopyTo(QueueList, 0);
//		}
//		#endregion
//	}
//	
//	void Update () {
//		#region UpdateStack
//		if( HitStack.Count > 0 )
//		{
//			GameObject lastObject = HitStack.Peek() as GameObject;
//			Debug.DrawLine( transform.position, lastObject.transform.position );
//			if( HitList[0] == lastObject )
//			{
//				StartCoroutine("popTheStack");
//			}
//		}
//		#endregion
//		#region UpdateQueue
//		if( HitQueue.Count > 0 )
//		{
//			GameObject firstObject = HitQueue.Peek() as GameObject;
//			Debug.DrawLine( transform.position, firstObject.transform.position, Color.red );
//			if( QueueList[0] == firstObject )
//			{
//				StartCoroutine("dequeueTheQueue");
//			}
//		}
//		#endregion
//	}
//	#region popStack
//	IEnumerator popTheStack()
//	{
//		yield return new WaitForSeconds(2);
//		if( HitStack.Count > 0 )
//		{
//			HitStack.Pop();
//			HitList = new GameObject[HitStack.Count];
//			HitStack.CopyTo(HitList, 0);
//			StopCoroutine("popTheStack");
//		}
//	}
//	#endregion
//	#region dequeueQueue
//	IEnumerator dequeueTheQueue()
//	{
//		yield return new WaitForSeconds(2);
//		if( HitQueue.Count > 0 )
//		{
//			HitQueue.Dequeue();
//			QueueList = new GameObject[HitQueue.Count];
//			HitQueue.CopyTo(QueueList, 0);
//			StopCoroutine("dequeueTheQueue");
//		}
//	}
//	#endregion
//}
