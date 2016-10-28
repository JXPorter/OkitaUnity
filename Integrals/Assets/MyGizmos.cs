using UnityEngine;
using System.Collections;
public class MyGizmos : MonoBehaviour
{
	void Start()
	{
		
	}

	void Update()
	{
		
	}

	void OnDrawGizmos()
	{
		Gizmos.DrawCube (new Vector3(0,0,0), new Vector3(1,2,3)); // draws a cube with a center at origin and of 1 unit wide, 2 tall, and 3 deep

		// Ray r = new Ray(new Vector3(0,0,0), new Vector3 (0,1,0)); // one alternative to writing out a ray.
		// This method breaks out the arguments so that they are less convoluted and easier to read
		Ray r = new Ray(); 
		r.origin = new Vector3 (0,0,0);
		r.direction = new Vector3 (0, 1, 0);
   		Gizmos.DrawRay (r);
	}
}
//// Original Code
//public class MyGizmos : MonoBehaviour
//{
//	// Use this for initialization
//	void Start()
//	{
//	
//	}
//	
//	// Update is called once per frame
//	void Update()
//	{
//	}
//
//	void OnDrawGizmos()
//	{
////		Gizmos.DrawCube(new Vector3(0, 0, 0), new Vector3(1, 2, 3));
//		Ray r = new Ray();
//		r.origin = new Vector3(0, 0, 0);
//		r.direction = new Vector3(0, 1, 0);
//		Gizmos.DrawRay(r);
//	}
//}
