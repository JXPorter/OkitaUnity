using UnityEngine;
using System.Collections;

public class RefScript : MonoBehaviour {

	public int x = 2;
	public int y = 3;

	void RefIncrementValue(ref int n)
	{
		n += 4;
	}

	// Use this for initialization
	void Start () 
	{
		print (x);
		RefIncrementValue (ref x);
		print (x);
		RefIncrementValue (ref x);
		print (x);
		RefIncrementValue (ref y);
		print (y);
		RefIncrementValue (ref y);
		print (y);
		RefIncrementValue (ref y);
		print (y);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
