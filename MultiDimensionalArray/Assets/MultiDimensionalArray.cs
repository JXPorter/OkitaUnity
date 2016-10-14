﻿using UnityEngine;
using System.Collections;
using System;

public class MultiDimensionalArray : MonoBehaviour
{
	void Start()
	{
		GameObject a = new GameObject ("A");
		GameObject b = new GameObject ("B");
		GameObject c = new GameObject ("C");
		GameObject d = new GameObject ("D");
		GameObject e = new GameObject ("E");
		GameObject f = new GameObject ("F");
		GameObject[,] twoDimension = new GameObject[2, 3] 
		{
			{ a, b, c }, { d, e, f }
		};
		InspectArray (twoDimension);

		/* 
		 GameObject[,] twoDimension = new GameObject[2,3];
		for (int i = 0; i < twoDimension.Length; i++) 
		{
			Debug.Log (i); // Outputs 0 - 5 in the Console
		}
		*/
	}

	void Update()
	{
		
	}

	void InspectArray(GameObject[,] gos)
	{
		int columns = gos.GetLength (0);
		Debug.Log ("Columns: " + columns);
		int rows = gos.GetLength (1);
		Debug.Log ("Rows: " + rows);
		for (int c = 0; c < columns; c++) 
		{
			for(int r=0; r <rows; r++)
			{
				Debug.Log (gos[c,r].name);
			}
		}
	}
}

//// Original Code
//public class MultiDimensionalArray : MonoBehaviour {
//	public GameObject[] oneDArray;
//	public GameObject[,] mArray;
//	// Use this for initialization
//void Start () {
//
//	GameObject a = new GameObject("A");
//	GameObject b = new GameObject("B");
//	GameObject c = new GameObject("C");
//	GameObject d = new GameObject("D");
//	GameObject e = new GameObject("E");
//	GameObject f = new GameObject("F");
//	GameObject[,] twoDimension = new GameObject[2,3]{ {a, b, c} , {d, e, f} };
//	GameObject[,,] threeDimension = new GameObject[4,3,2]
//		{
//			{  {a,b} ,{c,d}, {e,f}  },
//			{  {a,b} ,{c,d}, {e,f}  },
//			{  {a,b} ,{c,d}, {e,f}  },
//			{  {a,b} ,{c,d}, {e,f}  }
//		};
//	
//	InspectArray( twoDimension );
//}
//	
//	void InspectArray( GameObject[,] gos ) {
//		
//		int columns = gos.GetLength(0);
//		Debug.Log( "Columns: " + columns );
//
//		int rows = gos.GetLength(1);
//		Debug.Log( "Rows: " + rows );
//		
//		for( int c = 0; c < columns; c++ ) {
//			for( int r = 0; r < rows; r++ ) {
//				Debug.Log( gos[c,r].name );
//			}
//		}
//	}
//	
//	// Update is called once per frame
//	void Update () {
//	
//	}
//}
