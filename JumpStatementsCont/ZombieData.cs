using UnityEngine;
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

		// - check to see if a gameObject has the Human Data Component  component, if it does add it to an Array List 
		// called allHumans, and then continue to the next object in the list.
		HumanData hd = (HumanData)go.GetComponent(typeof(HumanData));
		if (hd != null) 
		{
			allHumans.Add (go);
			continue;
		}
	}
}
