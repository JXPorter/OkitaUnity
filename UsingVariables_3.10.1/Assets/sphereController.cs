using UnityEngine;
using System.Collections;

public class sphereController : MonoBehaviour {
	public float Control;
	public float OtherControl;

	// Use this for initialization
	void Start () 
	{
	
	}

	// Update is called once per frame
	void Update ()
	{
		//transform.position = new Vector3 (Mathf.Sin(Control) * OtherControl, Mathf.Cos(Control) * OtherControl, Control * OtherControl);

		// Alternate way of writing this code
		Vector3 vec = new Vector3();
		vec.x = Mathf.Sin (Control) * OtherControl;
		vec.y = Mathf.Cos (Control) * OtherControl;
		vec.z = Control * OtherControl;

		transform.position = vec;
	}
}
