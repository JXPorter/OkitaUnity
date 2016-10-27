using UnityEngine;
using System.Collections;

public class Monsters : MonoBehaviour
{
	void Start()
	{
		Zombie Z = new Zombie ();
		Vampire V = new Vampire ();
		//Z.HitPoints = 10;
		//V.HitPoints = 10;    don't need these defined because they are initialized in the Monster constructor.
		Debug.Log(Z.TakeDamage(5));
		Debug.Log (V.TakeDamage(5));
		Debug.Log (Z.ToString());
		Debug.Log (V.ToString());
	}

	void Update()
	{
		
	}

	class Monster
	{
		// we can create a constructor to set the monster's hitpoints
		// we can also extend the base Monster class to do more things like Create A GameObject and announce its presence
		public int HitPoints;
		public GameObject gameObject;
		//class constructor
		public Monster()
		{
			HitPoints = 10;
			gameObject = GameObject.CreatePrimitive(PrimitiveType.Capsule);
			Debug.Log("A new monster rises!");
		}
		public virtual int TakeDamage(int damage)
		{
			return HitPoints - damage;
		}

	}

	class Zombie : Monster
	{
		public int BrainsEaten = 0;
		public Zombie()
		{
			Debug.Log("zombie constructor");
			gameObject.transform.position = new Vector3(1,0,0);
		}
		public override string ToString ()
		{
			return string.Format ("[Zombie]");
		}
		public override int TakeDamage (int damage)
		{
			return base.TakeDamage (damage);   // the keyword base allows us to refer to the original implmentation of the code. 
		}
	}

	class Vampire : Monster
	{
		public int BloodSucked = 0;
		public override int TakeDamage (int damage) // override keyword allows us to change the original definition of the function marked by the virtual keyword
		{
			return HitPoints - (damage / 2);
		}
	}
}
//// Original Code
//public class Monsters : MonoBehaviour
//{
//
//	// Use this for initialization
//	void Start()
//	{
//		
//	}
//	
//	// Update is called once per frame
//	void Update()
//	{
//		
//	}
//
//	class Monster
//	{
//		public int HitPoints;
//		public GameObject gameObject;
//		
//		public Monster()
//		{
//			HitPoints = 10;
//			gameObject =
//				GameObject.CreatePrimitive(PrimitiveType.Capsule);
//			Debug.Log("A new monster rises!");
//		}
//		
//		public virtual int TakeDamage(int damage)
//		{
//			return HitPoints - damage;
//		}
//	}
//
//	class Zombie : Monster
//	{
//		public int BrainsEaten = 0;
//		
//		public Zombie()
//		{
//			Debug.Log("zombie constructor");
//			gameObject.transform.position = new Vector3(1, 0, 0);
//		}
//		
//		public override string ToString()
//		{
//			return string.Format("[Zombie]");
//		}
//	}
//	
//	class Vampire : Monster
//	{
//		public int BloodSucked = 0;
//		public override int TakeDamage(int damage)
//		{
//			return HitPoints - (damage / 2);
//		}
//	}
//
//
//}
