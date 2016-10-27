using UnityEngine;
using System.Collections;

public class MrCube : MonoBehaviour {

	string[] names = new string[] 
	{
		"MrCube",
		"MrsCube",
		"MissCube",
		"CubeJr",
		"Cube1",
		"Cube2",
		"Cube3",
		"Cube4"
	};

	Color col;

	// Use this for initialization
	void Start () 
	{
//		GameObject g = GameObject.CreatePrimitive (PrimitiveType.Cube);
//		g.name = "MrCube";
//		g.transform.position = new Vector3 (0,1,0);
//		CreateANamedObject(PrimitiveType.Cube, "MrCube", new Vector3(0,1,0));
//		CreateANamedObject (PrimitiveType.Cube, "MrsCube", new Vector3(0,2,0));
//		CreateANamedObject (PrimitiveType.Cube, "MissCube", new Vector3(0,3,0));
//		CreateANamedObject (PrimitiveType.Cube, "CubeJr", new Vector3(0,4,0));

		// Cleverly using a foreach loop with our CreateANamedObject()
		float y = 1.0f;
		foreach(string s in names)
		{
			CreateANamedObject (PrimitiveType.Cube, col, s, new Vector3(0,y,0));
			y += 1.0f;

		}
	}
	
	// Update is called once per frame
	void Update () 
	{

	}

	void CreateANamedObject (PrimitiveType pt, Color col, string n, Vector3 p)
	{
		GameObject g = GameObject.CreatePrimitive (pt);
		col = Color.green;
		g.GetComponent<Renderer> ().material.color = col;
		g.name = n;
		g.transform.position = p;
	}
}
