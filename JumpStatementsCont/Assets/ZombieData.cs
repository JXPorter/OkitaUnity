﻿using UnityEngine;
using System.Collections;

public class ZombieData : MonoBehaviour
{
	public int hitpoints;
	public float speed = 2.0f;
	public bool dead;
	// Use this for initialization
	void Start()
	{

	}
	
	// Update is called once per frame
	void Update()
	{
		if (dead) 
		{
			Destroy (gameObject);
		}

//		if (playerController == null) 
//		{
//			continue;
//		}
//			
//		if(playerController != null)
//		{
//			attackPlayer();
//		}
	}
}
