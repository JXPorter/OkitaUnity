using UnityEngine;
using System.Collections;

public class Example : MonoBehaviour
{

	public Vector3 pos = Vector3.zero;
	public float speed = 0.1f;

	void Start()
	{
		pos = transform.position;
		Members m = new Members ();
		m.FirstFunction ();
		Input.GetKey (KeyCode.A);
		Input.GetKey (KeyCode.W);
		Input.GetKey (KeyCode.S);
		Input.GetKey (KeyCode.D);
	}

	void Update()
	{
//		bool AKey = Input.GetKey (KeyCode.A);
//		bool WKey = Input.GetKey (KeyCode.W);
//		bool SKey = Input.GetKey (KeyCode.S);
//		bool DKey = Input.GetKey (KeyCode.D);
//
//		if (AKey) 
//		{
//			pos.x = pos.x - speed;
//			Debug.Log ("AKey");
//		}
//		if (WKey) 
//		{
//			pos.z = pos.z + speed;
//			Debug.Log ("WKey");
//		}
//		if (SKey)
//		{
//			pos.z = pos.z - speed;
//			Debug.Log ("SKey");
//		}
//		if (DKey)
//		{
//			pos.x = pos.x + speed;
//			//Debug.Log ("DKey");
//			print ("DKey");
//		}
		transform.position += Movement(speed);
	}

	Vector3 Movement(float dist)
	{
		Vector3 vec = Vector3.zero;
		if (Input.GetKey(KeyCode.A))
		{
			vec.x -= dist;
		}
		if(Input.GetKey(KeyCode.W))
		{
			vec.z += dist;
		}
		if(Input.GetKey(KeyCode.S))
		{
			vec.z -= dist;
		}
		if (Input.GetKey (KeyCode.D)) 
		{
			vec.x += dist;
		}
		return vec;
	}
}

//// Original Code
//public class Example : MonoBehaviour
//{
//	public Vector3 pos = Vector3.zero;
//	public float speed;
//
//	// Use this for initialization
//	void Start()
//	{
//		Members m = new Members();
//		m.FirstFunction();
//		print(ImANumber());
//		print(INeedANumber(1));
////		int val = INeedANumber(3) + INeedANumber(7);
////		print(val);
//		int val = INeedTwoNumbers(3, 7);
//		print(val);
//	}
//
//	bool NumbersAreTheSame(int a, int b)
//	{
//		if (a == b)
//		{
//			return true;
//		} else
//		{
//			return false;
//		}
//	}
//
//
//	int INeedTwoNumbers(int a, float b)
//	{
//		return a * (int)b;
//	}
//
//	int ImANumber()
//	{
//		return 3;
//	}
//
//	int INeedANumber(int number)
//	{
//		return number + 1;
//	}
//	float f = 0;
//	void Update()
//	{
//		f += 0.25f;
//		print(f);
////		print(Input.GetKey(KeyCode.A));
////		bool AKey = Input.GetKey(KeyCode.A);
////		bool SKey = Input.GetKey(KeyCode.S);
////		bool DKey = Input.GetKey(KeyCode.D);
////		bool WKey = Input.GetKey(KeyCode.W);
////		if (AKey)
////		{
////			pos.x = pos.x - 0.1f;
////		}
////		if (DKey)
////		{
////			pos.x = pos.x + 0.1f;
////		}
////		if (WKey)
////		{
////			pos.z = pos.z + 0.1f;
////		}
////		if (SKey)
////		{
////			pos.z = pos.z - 0.1f;
////		}
//		transform.position += Movement(0.2f);
////		transform.position += Movement();
//	}
//
//	Vector3 Movement()
//	{
//		return new Vector3(0.1f, 0.2f, 0.3f);
//	}
//
//	Vector3 Movement(float dist)
//	{
//		Vector3 vec = Vector3.zero;
//		if (Input.GetKey(KeyCode.A))
//		{
//			vec.x -= dist;
//		}
//		if (Input.GetKey(KeyCode.D))
//		{
//			vec.x += dist;
//		}
//		if (Input.GetKey(KeyCode.W))
//		{
//			vec.z += dist;
//		}
//		if (Input.GetKey(KeyCode.S))
//		{
//			vec.z -= dist;
//		}
//		return vec;
//	}
//}
