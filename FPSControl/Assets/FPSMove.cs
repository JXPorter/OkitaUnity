using UnityEngine;
using System.Collections;

public class FPSMove : MonoBehaviour
{
	void Start()
	{
		
	}

	public float speed = 0.1f;
	void Update()
	{
		if (Input.GetKey (KeyCode.W)) 
		{
			transform.position += transform.forward * speed;
		}
		if (Input.GetKey (KeyCode.S)) 
		{
			transform.position -= transform.forward * speed;
		}
		if (Input.GetKey (KeyCode.A))
		{
			transform.position -= transform.right * speed;
			// NOTE: can also use Vector3.left to mean the same thing as above.
			//transform.position += Vector3.left * speed;
		}
		if (Input.GetKey (KeyCode.D))
		{
			transform.position += transform.right * speed;
		}
	}
}
//// Original Code
//public class FPSMove : MonoBehaviour
//{
//
//	// Use this for initialization
//	void Start()
//	{
//	
//	}
//	
//	// Update is called once per frame
//	public float speed = 0.1f;
//	void Update()
//	{
//		if (Input.GetKey(KeyCode.W))
//		{
//			transform.position += transform.forward * speed;
//		}
//		if (Input.GetKey(KeyCode.S))
//		{
//			transform.position -= transform.forward * speed;
//		}
//		if (Input.GetKey(KeyCode.A))
//		{
//			transform.position -= transform.right * speed;
//		}
//		if (Input.GetKey(KeyCode.D))
//		{
//			transform.position += transform.right * speed;
//		}
//	}
//
//}
