﻿using UnityEngine;
using System.Collections;

public class Example : MonoBehaviour
{
	void Start()
	{
			string[] names = new string[]{"stubbs", "rob", "white" };
			for(int i=0; i <names.Length; i++)
			{
				Zombie z = new Zombie (names[i], Random.Range(10,15));
				Debug.Log (z.Name);
				Debug.Log (z.hitPoints);
			}
			//		Zombie rob = new Zombie ("Rob", 10); // as the Zombie class is instanced, it takes in two params.
			//		Debug.Log(rob.Name);
			//		Debug.Log (rob.hitPoints);
	}

	void Update()
	{
		
	}

}
//// Original Code
//public class Example : MonoBehaviour
//{
//	// Use this for initialization
//	void Start()
//	{
//		string[] names = new string[]{"stubbs", "rob", "white"};
//		for (int i = 0; i < names.Length; i++)
//		{
//			Zombie z = new Zombie(names [i], Random.Range(10, 15));
//			Debug.Log(z.Name);
//		}
//	}
//
//	// Update is called once per frame
//	void Update()
//	{
//	
//	}
//}
