using UnityEngine;
using System.Collections;

public class Zombie
{
	public string Name;
	public int brainsEaten;
	public int hitPoints;
	GameObject ZombieMesh;

	public Zombie(string n, int hp)      // our class constructor that takes two parameters
	{
		Name = n;
		brainsEaten = 0;
		hitPoints = hp;
		ZombieMesh = GameObject.CreatePrimitive (PrimitiveType.Capsule);
		ZombieMesh.name = n;             // this gives the name of n to the game object in the Hierarchy panel.
		Vector3 pos = new Vector3 ();
		pos.x = Random.Range (-10,10);
		pos.y = 0f;
		pos.z = Random.Range (-10,10);
		ZombieMesh.transform.position = pos;
	}
		

	void Update()
	{
	}

}
//// Original Code
//class Zombie
//{
//	public string Name;
//	public int brainsEaten;
//	public int hitPoints;
//	GameObject ZombieMesh;
//	
//	public Zombie(string n, int hp)
//	{
//		Name = n;
//		brainsEaten = 0;
//		hitPoints = hp;
//		ZombieMesh = GameObject.CreatePrimitive(PrimitiveType.Capsule);
//		Vector3 pos = new Vector3(
//			Random.Range(-10, 10), 0,
//			Random.Range(-10, 10));
//		ZombieMesh.transform.position = pos;
//	}
//}
