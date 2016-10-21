using UnityEngine;
using System.Collections;
using Zombie;

public class Player : MonoBehaviour 
{
	public Monsters monster;
	public int attackPower;

	void AttackMonster ()
	{
		if(monster != null)
		{
			MonsterInfo mi = monster.monsterInfo;  // not sure why this can't find .monsterInfo - 10/20 ???
			Debug.Log (mi.armor);
			if(attackPower >= mi.armor && mi.health > 0)
			{
				monster.TakeDamage (attackPower - mi.armor);
			}
		}
	}
		
}
