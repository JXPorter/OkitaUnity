using UnityEngine;
using System.Collections;

public class Monster : MonoBehaviour 
{
	// class to determine which state monster is in
	public enum MonsterState
	{
		standing,
		wandering,
		chasing,
		attacking
	}
	public MonsterState mState;

	// Use this for initialization
	void Start () 
	{
		//mState = MonsterState.standing;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(mState == MonsterState.standing)
		{
			print ("standing monster");
		}
		if(mState == MonsterState.wandering)
		{
			print ("wandering monster");
		}
		if(mState == MonsterState.chasing)
		{
			print ("chasing monster");
		}
		if(mState == MonsterState.attacking)
		{
			print ("attacking monster");
		}
	}
}
