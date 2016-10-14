using UnityEngine;
using System.Collections;

public class Example : MonoBehaviour
{
	public GameObject[] gos;
	public GameObject[] allHumans;

	void Start()
	{
		// Creating the zombie game objects
		gos = new GameObject[10];
		for (int i = 0; i < 10; i++) 
		{
			GameObject go = GameObject.CreatePrimitive (PrimitiveType.Cube);
			Vector3 v = new Vector3 ();
			v.x = Random.Range (-10,10);
			v.z = Random.Range (-10,10);
			go.transform.position = v;
			go.name = i.ToString (); // gives each game object a name based on "i" value
			if (i % 2 == 0) 
			{
				go.AddComponent (typeof(ZombieData));
			}
			gos [i] = go;
		}
		// Creating the Human Game Objects
		allHumans = new GameObject[10];
		for (int i = 0; i < 10; i++) 
		{
			GameObject go = GameObject.CreatePrimitive (PrimitiveType.Cube);
			Vector3 v = new Vector3 ();
			v.x = Random.Range (-10,10);
			v.z = Random.Range (-10,10);
			go.transform.position = v;
			//go.name = i.ToString(); // gives each game object a name based on "i" value
			if (i % 2 == 1) 
			{
				go.AddComponent (typeof(HumanData));
				go.name = ("human " + i.ToString()); // gives each game object a name based on "i" value
			}
			allHumans[i] = go;
		}


		// Examples of BREAK and CONTINUE statements
//		for(int i=0; i < 100; i++)
//		{
//			print (i);
//			if (i > 10) 
//			{
//				break; // breaks out of the loop and doesn't repeat the code anymore
//			}
//		}
//		for (int i = 0; i < 100; i++) 
//		{
//			print (i);
//			if (i > 10) 
//			{
//				print ("i is greater than 10");
//				continue;
//			}
//		}
	}

	void Update()
	{
		//in a normal game, there will be many different types of objects in a scene
		// this foreach loop looks through all the game objects and if it finds one with ZombieData component
		// then it adds some data.

		foreach(GameObject go in gos)
		{
			ZombieData zd = (ZombieData)go.GetComponent (typeof(ZombieData)); // Zombie data class is assigned to the variable zd
			if (zd == null) // if the game Object does not have any ZombieData, then zd will not be assigned anything, it remains null
			{
				continue; // go back to the top of loop, and move on to the next item in the array.
			}
			if (zd.hitpoints > 0) 
			{
				break;
			}
			print (go.name);
			zd.hitpoints = 10;

//			// - check to see if a gameObject has the Human Data Component  component, if it does add it to an Array List 
//			// called allHumans, and then continue to the next object in the list.
//			HumanData hd = (HumanData)go.GetComponent(typeof(HumanData));
//			if (hd != null) 
//			{
//				allHumans.Add (go);
//				continue;
//			}
		}
			
	}
}
//// Original Code
//public class Example : MonoBehaviour
//{
//
//	public GameObject[] gos;
//	// Use this for initialization
//	void Start()
//	{
//		gos = new GameObject[10];
//		for (int i = 0; i < 10; i++)
//		{
//			GameObject go = GameObject.CreatePrimitive(PrimitiveType.Cube);
//			Vector3 v = new Vector3();
//			v.x = Random.Range(-10, 10);
//			v.z = Random.Range(-10, 10);
//			go.transform.position = v;
//			go.name = i.ToString();
//                
//			if (i % 2 == 0)
//			{
//				go.AddComponent(typeof(ZombieData));
//			}
//			gos [i] = go;
//		}
//
//		for (int i = 0; i < 100; i++)
//		{
//			print(i);
//
//			if (i > 10)
//			{
//				break;
//			}
//		}
//
//		for (int i = 0; i < 100; i++)
//		{
//			print(i);
//
//			if (i > 10)
//			{
//				print("i is greater than 10!");
//				continue;
//			}
//		}
//	}
//
//	// Update is called once per frame
//	void Update()
//	{
//		foreach (GameObject go in gos)
//		{
//			ZombieData zd = (ZombieData)go.GetComponent(typeof(ZombieData));
//			
//			if (zd == null)
//			{
//				continue;
//			}
//			
//			if (zd.hitpoints > 0)
//			{
//				break;
//			}
//            
//			print(go.name);
//			zd.hitpoints = 10;
//		}
//	}
//}
