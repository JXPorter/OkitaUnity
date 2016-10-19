using UnityEngine;
using System.Collections;

public class Monster : MonoBehaviour
{
	public int ID;           // this variable will be iterated through when GameObjects are created in Example.cs 
	public float spacing;

	void Start()
	{
		print ("I'm alive");
	}

	void Update()
	{
		float wave = Mathf.Sin (Time.fixedTime + ID);      // this Mathf.Sin function acting upon the constantly changing Time.fixedTime + ID will make the objects bob up in down in the air
		transform.position = new Vector3 (ID * spacing, wave, 0); // added wave to the y postion of the Vector3 so that the cube will bob up and down. 
	}
}
//// Original Code
//public class Monster : MonoBehaviour
//{
//	public int ID;
//
//	// Use this for initialization
//	void Start()
//	{
//		print("im alive!");
//	}
//	
//	// Update is called once per frame
//	void Update()
//	{
//	
//	}
//}
