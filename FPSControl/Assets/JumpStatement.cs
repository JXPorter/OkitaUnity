using UnityEngine;
using System.Collections;

public class JumpStatement : MonoBehaviour 
{
	// using the Return statement
	// The Return keyword turns a function into data
	int MyNumber()
	{
		return 7;
	}

	int MyAdd(int a, int b)
	{
		return a + b;
	}
	int MyAddiply(int a, int b, int c)
	{
		return (a + b) * c;
	}
	// Use this for initialization
	void Start ()
	{
		int a = MyNumber ();
		print (a);

		int b = MyAdd(6,8);
		print(b);

		print( MyAdd (-2, -3));

		print (MyAddiply(5,6,4));
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
}
