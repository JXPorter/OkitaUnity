namespace Zombie
// Namespace allow us to create a new set of data than can be shared between classes. E.g. in your game you'll have a detailed set of rules and objects
// that the rest of your game classes will want to share. The best way to keep all of these classes organized is for any sort of shared data to originate
// from the same namespace.
// Once this namespace is created and named, we're able to use any class within it from any other class we create in our game project.
{
	using UnityEngine;
	using System.Collections;

	public class MonsterInfo : MonoBehaviour 
	{
		public int health;
		public int armor;
		public int attack;
		public MonsterInfo()
		{
			health = 10;
			armor = 1;
			attack = 3;
		}

		// Use this for initialization
		void Start () {
		
		}
		
		// Update is called once per frame
		void Update () {
		
		}
	}
}
