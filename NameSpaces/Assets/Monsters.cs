using UnityEngine;
using System.Collections;
using Zombie;

// I am using the Zombie namespace that I created before, so that I can use the MonsterInfo class to store the game related info when I create another monster

public class Monsters : MonoBehaviour 
{
	MonsterInfo monster = new MonsterInfo();

	// Use this for initialization
	void Start ()
	{
		MonsterInfo m = monster;
		Debug.Log ("Monster health = " + m.health);
		Debug.Log ("Monster armor =  " + m.armor);
		Debug.Log ("Monster attack = " + m.attack);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void TakeDamage(int damage)
	{
		MonsterInfo.health -= damage;
	}
}
