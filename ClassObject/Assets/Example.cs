using UnityEngine;
using System.Collections;

public class Example : MonoBehaviour
{
	void Start()
	{
		Vector3 vector = new Vector3 (1, 2, 3);
		transform.position = vector;
		vector.x = 2.0f;
		print ("The camera is located at " + vector);

		// we can also assign plain old data types as an object
		// although POD types like ints, floats, etc don't really need constructors
		int i = new int();
		Debug.Log (i);
	}

	void Update()
	{
		
	}

}


// Original Code
//    // Use this for initialization
//    void Start()
//    {
//        Vector3 vector = new Vector3(1, 2, 3);
//        vector.x = 1.0f;
//        transform.position = vector;
//        int i = new int();
//        Debug.Log(i);
//    }
//	
//    // Update is called once per frame
//    void Update()
//    {
//
//    }
