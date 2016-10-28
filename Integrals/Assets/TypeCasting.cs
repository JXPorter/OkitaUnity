using UnityEngine;
using System.Collections;

public class TypeCasting : MonoBehaviour
{
	class Humanoid
	{
		public int hitpoints;
	}

	class Person : Humanoid
	{
		// USER DEFINED TYPE CONVERSION - we create a new function in Person, so we can convert it into a Zombie.
		// the keywords implicit and operator allow us to use the Zombie cast when working with a Person type object
		// Now we can check what the hitpoints of a Person is if it was to be treated as a Zombie type object.
		static public implicit operator Zombie(Person p)
		{
			Zombie z = new Zombie();
			z.hitpoints = p.hitpoints * -1;
			return z;
		}
	}

	class Zombie : Humanoid
	{
	}

	// Use this for initialization
//	void Start()
//	{
//		Humanoid h = new Humanoid();
//		Zombie z = h as Zombie;
//		Debug.Log(z);
//	}
//	void Start()
//	{
//		Humanoid h = new Humanoid();
//		Zombie x = (Zombie)h;
//		Debug.Log(x);
//	}
//	void Start()
//	{
//		Person p = new Person();
//		Zombie z = p as Zombie;
//		Debug.Log(z);
//	}

//	void Start()
//	{
//		Person p = new Person();
//		p.hitpoints = 10;
//		Zombie z = p as Zombie;
//		Debug.Log(z.hitpoints);
//	}
//	void Start()
//	{
//		Zombie z = new Person();
//		Debug.Log(z);
//	}
	void Start()
	{
		Person p = new Person();
		Zombie z = (Zombie)p;
		Debug.Log(z);
	}

	// Update is called once per frame
	void Update()
	{
		
	}
}
