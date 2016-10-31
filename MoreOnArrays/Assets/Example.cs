using UnityEngine;
using System.Collections;
public class Example : MonoBehaviour
{

	void Start()
	{

//		// Array Practice Code
//		int[] primes = { 1, 3, 5, 7, 11, 13, 17, 23, 27, 31 };
//		int[] fibonacci = {0,1,1,2,3,5,8,13,21,34,55,89,144 };
//		int[] powersOfTwo = { 1,2,4,8,16,32,64,128,256,512,1024 };
//		ArrayList Numbers = new ArrayList{ primes, fibonacci, powersOfTwo};
//		int numArrays = Numbers.Count;
//		for(int i = 0; i < numArrays; i++)
//		{
//			int[] Nums = Numbers [i] as int[];
//			int items = Nums.Length;
//			for(int j = 0; j < items; j++)
//			{
//				int Num = Nums [j];
//				print (Num);
//			}
//		}
	}

	void Update()
	{
		GameObject[] gos = GameObject.FindGameObjectsWithTag ("Monster");
		ArrayList distances = new ArrayList ();
		//print (gos.Length);
		foreach(GameObject g in gos)
		{
			Vector3 vec = g.transform.position - transform.position;
			float distance = vec.magnitude;
			distances.Add (distance);
		}
		float closestValue = (float)distances[0];
		GameObject closestObject = gos [0];
		for(int i =0; i < gos.Length; i++)
		{
			float d = (float)distances [i];
			if(d < closestValue)
			{
				closestObject = gos [i];
				closestValue = (float)distances [i];
			}
		}
		//print (distances.Count);

		Vector3 up = new Vector3 (0,1,0);
		Vector3 start = closestObject.transform.position;
		Debug.DrawRay (start,up, Color.green);




		GameObject go = GameObject.Find ("Cube");
		Vector3 CubePosition = go.transform.position;
		Vector3 Up = new Vector3 (0,1,0);
		Debug.DrawRay (CubePosition, Up);
	}

}
//// Original Code
//public class Example : MonoBehaviour
//{
//	
//	// Use this for initialization
//	void Start()
//	{
//		
//	}
//	
//	// Update is called once per frame
//	void Update()
//	{
//		GameObject[] gos = GameObject.FindGameObjectsWithTag("Monster");
//		ArrayList distances = new ArrayList();
//		foreach (GameObject g in gos)
//		{
//			Vector3 vec = g.transform.position - transform.position;
//			float distance = vec.magnitude;
//			distances.Add(distance);
//		}
//		
//		float closestValue = (float)distances [0];
//		GameObject closestObject = gos [0];
//		
//		for (int i = 0; i < gos.Length; i++)
//		{
//			float d = (float)distances [i];
//			if (d <= closestValue)
//			{
//				closestObject = gos [i];
//				closestValue = d;
//			}
//		}
//        
//		Vector3 up = new Vector3(0, 1, 0);
//		Vector3 start = closestObject.transform.position;
//		Debug.DrawRay(start, up);
//	}
//}
