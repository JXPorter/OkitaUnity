using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
	// store the position of the player
	//Vector3 pos;
	// or we can store the position of the player and share it as static variable with the other classes
	// because this variable will be the same for every zombie that is created, they don't each need thier own
	// instance of it.
	public static Vector3 pos;

	void Start()
	{
		// set the position to where we start off with in the scene
		pos = transform.position;
	}

	void Update()
	{
		// add in a checks for the WASD keys
		bool WKey = Input.GetKey(KeyCode.W);
		bool AKey = Input.GetKey(KeyCode.A);
		bool SKey = Input.GetKey (KeyCode.S);
		bool DKey = Input.GetKey (KeyCode.D);
		if (DKey) 
		{
			pos.z += 0.1f;
		}
		if (AKey) 
		{
			pos.x -= 0.1f;
			Debug.Log ("AKey");
		}
		if (SKey) 
		{
			pos.z -= 0.1f;
		}
		if (DKey)
		{
			pos.x += 0.1f;
		}
		gameObject.transform.position = pos;
		// calls the static function in Zombie
		Zombie.CountZombies();
	}

}

//// ORIGINAL CODE FROM ALEX OKITA
//public class Player : MonoBehaviour
//{
//
//}
//
//
//Vector3 pos;
//// Use this for initialization
//void Start()
//{
//
//}
//// Update is called once per frame
//void Update()
//{
//	bool WKey = Input.GetKey(KeyCode.W);
//	bool SKey = Input.GetKey(KeyCode.S);
//	bool AKey = Input.GetKey(KeyCode.A);
//	bool DKey = Input.GetKey(KeyCode.D);
//	if (WKey)
//	{
//		pos.z += 0.1f;
//	}
//	if (SKey)
//	{
//		pos.z -= 0.1f;
//	}
//	if (AKey)
//	{
//		pos.x -= 0.1f;
//	}
//	if (DKey)
//	{
//		pos.x += 0.1f;
//	}
//	gameObject.transform.position = pos;
//	//add in a check for the A key
//	//bool AKey = Input.GetKey(KeyCode.A);
//	//if (AKey)
//	//{
//	//	Debug.Log("AKey");
//	//	//calls the static function in Zombie
//	//	Zombie.CountZombies();
//	//}
//	//Input MyInput = new Input();
//	//bool AKey = MyInput.GetKey( KeyCode.A );
//	//Debug.Log( AKey ); 
//}
