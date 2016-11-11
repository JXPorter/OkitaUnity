using UnityEngine;
using System.Collections;

public class DestroyMe
{
	public string name;
	
	//constructor
	public DestroyMe(string name)
	{
		this.name = name;
		Debug.Log(name + " says hello.");
	}
	
	public void OnUpdate()
	{
		Debug.Log(name + " is updating.");
	}
	
	~DestroyMe()                            // the destructor can be identified by the ~ preceding the class identifier.
											// Destructors are called anytime that the object is garbage collected
	{
		Debug.Log(name + " says goodbye.");
	}	
}
