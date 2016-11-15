using UnityEngine;
using System.Collections;

// RECURSIVE FUNCTION - a function that calls itself from within itself. 
// Take care that it is to set up a loop that never breaks. The first rule for a recursive function is to have a clear condition where the function returns without calling
// on itself. This is how the function breaks out of itself. The reason Recursion repeats itself is that the function calles on itself at some point. 
// Once the function stops calling itself, the recursion terminates. 

public class Recursion : MonoBehaviour
{
//	void Start()
//	{
//		//for loop
//		for (int i = 0; i < 10; i++)
//		{
//			Debug.Log("for " + i.ToString());
//		}
//		
//		//while loop
//		int j = 0;
//		while (j < 10)
//		{
//			Debug.Log("while " + j.ToString());
//			j++;
//		}
//		
//		//do while
//		int k = 0;
//		do
//		{
//			Debug.Log("do " + k.ToString());
//			k++;
//		} while( k < 10 );
//		
//		//for each
//		int[] ints = {0,1,2,3,4,5,6,7,8,9,10};
//		foreach (int l in ints)
//		{
//			Debug.Log("foreach " + l.ToString());
//		}
//		
//		//while alternate
//		IEnumerator m = ints.GetEnumerator();
//		while (m.MoveNext())
//		{
//			Debug.Log("IEnumerator " + m.Current.ToString());
//		}
//		
//		//goto loop
//		int n = 0;
//		Start:
//		Debug.Log("goto " + n.ToString());
//		n++;
//		if (n < 10)
//		{
//			goto Start;
//		}
//	}

	// SIMPLE RECURSION EXAMPLE
//	void Recurse(int i)
//	{
//		if (i > 10) 
//		{
//			return;
//		}
//
//		Debug.Log ("Recurse " + i.ToString());
//		i++;
//		Recurse (i);
//	}
//
//	void Start()
//	{
//		Recurse (0);
//	}
		
	// //  e.g. Once the function stops calling on itself the recursion terminates
	//void CountdownRecursion(int i)
	//{
	//	Debug.Log(i);
	//	if(if > 0)
	//	{
	//		i--;
	//		CountdownRecursion(i);
	//	}
	//}
//}

		// Original Code
	
		GameObject a;
		void Start()
		{
			a = GameObject.CreatePrimitive(PrimitiveType.Sphere);
			int id = 0;
			a.name = "A_" + id;
			for (int i = 0; i < 3; i ++)
			{
				id++;
				GameObject b = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
				b.name = "B_" + id;
				a.transform.localEulerAngles = new Vector3(0, (360 / 3) * i, 0);
				b.transform.localPosition = new Vector3(6.0f, 0, 0);
				b.transform.parent = a.transform;
				
				for (int j = 0; j < 5; j++)
				{
					id++;
					GameObject c = GameObject.CreatePrimitive(PrimitiveType.Capsule);
					c.name = "C_" + id;
					b.transform.localEulerAngles = new Vector3(0, (360 / 5) * j, 0);
					c.transform.localPosition = new Vector3(2.0f, 0, 0);
					c.transform.parent = b.transform;
			
					for (int k = 0; k < 2; k++)
					{
						id++;
						GameObject d = GameObject.CreatePrimitive(PrimitiveType.Cube);
						d.name = "D_" + id;
						c.transform.localEulerAngles = new Vector3(0, (360 / 2) * k, 0);
						d.transform.localPosition = new Vector3(1.0f, 0, 0);
						d.transform.parent = c.transform;
					}
				}
			}
			//ListHierarchy( a );
			ArrayList myList = GetList(a);
			foreach (GameObject g in myList)
			{
				Debug.Log(g.name);
			}
			Debug.Log(myList.Count);
		}
		
		void RotateHieararchy(GameObject go)
		{
			go.transform.Rotate(new Vector3(0, 0.5f, 0));
			for (int i = 0; i < go.transform.GetChildCount(); i++)
			{
				GameObject g = go.transform.GetChild(i).gameObject;
				RotateHieararchy(g);
			}
		}
	
		void ListHierarchy(GameObject go)
		{
			Debug.Log(go.name);
			for (int i = 0; i < go.transform.GetChildCount(); i++)
			{
				GameObject g = go.transform.GetChild(i).gameObject;
				ListHierarchy(g);
			}
		}
		
		public ArrayList GetList(GameObject go)
		{
			ArrayList list = new ArrayList();
			BuildList(go, list);
			return list;
		}
		
		void BuildList(GameObject go, ArrayList l)
		{
			l.Add(go);
			for (int i = 0; i < go.transform.GetChildCount(); i++)
			{
				GameObject g = go.transform.GetChild(i).gameObject;
				BuildList(g, l);
			}
		}
		
	
		// Update is called once per frame
		void Update()
		{
			RotateHieararchy(a);	
		}
	}

//	void Recurse(int i)
//	{
//		if (i > 10)
//		{
//			return;
//		}
//		
//		Debug.Log("Recurse " + i.ToString());
//		
//		i++;
//		Recurse(i);
//	}
//	void Start()
//	{
//		Recurse(0);
//	}

//	// class scope GameObject
//	GameObject a;
//
//	void Start()
//	{
//		a = GameObject.CreatePrimitive (PrimitiveType.Sphere);
//		// create the a as a Sphere
//		// Next we will add in some local offsets and rotations
//		int id = 0;
//		//g is our gameObject to recurse through
//		//GameObject g = new GameObject ("A_" + id);
//		// name the new sphere as we did before
//		a.name = "A_" + id;
//		for(int i = 0; i < 3; i++)
//		{
//			id++;
//			GameObject b = GameObject.CreatePrimitive (PrimitiveType.Cylinder);
//			b.name = "B_" + id;
//			// rotate the parent first!!!
//			a.transform.localEulerAngles = new Vector3(0, (360/3) * i, 0);
//			b.transform.localPosition = new Vector3 (6.0f, 0,0);
//			b.transform.parent = a.transform;
//			for(int j =0; j <5;j++)
//			{
//				id++;
//				GameObject c = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
//				c.name = "C_" + id;
//				// rotate the parent first!
//				b.transform.localEulerAngles = new Vector3(0, (360/5) * j, 0);
//				c.transform.localPosition = new Vector3 (2.0f, 0, 0);
//				c.transform.parent = b.transform;
//				for(int k =0; k<2;k++)
//				{
//					id++;
//					GameObject d = GameObject.CreatePrimitive (PrimitiveType.Cube);
//					d.name = "D_" + id;
//					// rotate the parent first!
//					c.transform.localEulerAngles = new Vector3(0, (360/2)*k,0);
//					d.transform.localPosition = new Vector3 (1.0f, 0,0);
//					d.transform.parent = c.transform;
//				}
//			}
//		}
//		//ListHierarchy (g);
//		// With a complex hierarchy we want to see each one of the game object's name printed to the console panel with the recursive function ListHierachy()
//		// by passing it a game object.
//	}
//
//	void Update()
//	{
//		RotateHierarchy (a);
//	}
//
//	void ListHierarchy(GameObject go)
//	{
//		Debug.Log (go.name);
//		for(int i =0; i < go.transform.GetChildCount(); i++)
//		{
//			GameObject g = go.transform.GetChildCount (i).gameObject;      // NOTE transform.GetChildCount seems to be an obsolete function
//			ListHierarchy (g);
//		}
//	}
//
//	void RotateHierarchy(GameObject go)
//	{
//		go.transform.Rotate (new Vector3(0,0.5f,0));
//		for(int i =0; i < go.transform.GetChildCount(); i++)  
//		{
//			GameObject g = go.transform.GetChild (i).gameObject;
//			RotateHierarchy (g);
//		}
//	}
//}
