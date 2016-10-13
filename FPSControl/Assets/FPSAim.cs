using UnityEngine;
using System.Collections;

public class FPSAim : MonoBehaviour
{
	void Start()
	{

	}

	float mouseX;
	float mouseY;
	public bool InvertedMouse;
	void Update()
	{
		Vector3 mousePosition = Input.mousePosition;
		mouseX += Input.GetAxis ("Mouse X");
		Debug.Log ("MouseX: " + mouseX);
		if (InvertedMouse) 
		{
			mouseY += Input.GetAxis ("Mouse Y");
		}
		else
		{
				mouseY -= Input.GetAxis("Mouse Y");
		}
		Debug.Log ("MouseY: " + mouseY);
		//print ("Mouse Position is :" + mousePosition);

		transform.eulerAngles = new Vector3 (mouseY, mouseX, 0);
		Debug.Log ("Camera Rotation: " + transform.eulerAngles);
	}
}

//// Original Code
//public class FPSAim : MonoBehaviour
//{
//	// Use this for initialization
//	void Start()
//	{
//	}
//	
//	// Update is called once per frame
//	float mouseX;
//	float mouseY;
//	public bool InvertedMouse;
//	void Update()
//	{
//		//Vector3 mousePosition = Input.mousePosition;
//		//Debug.Log(mousePosition);
//		//float mouseX = mousePosition.x;
//		//float mouseY = mousePosition.y;
//		//transform.eulerAngles = new Vector3(mouseY * 0.1f, 0, 0);
//		mouseX += Input.GetAxis("Mouse X");
//		if (InvertedMouse)
//		{
//			mouseY += Input.GetAxis("Mouse Y");
//		} else
//		{
//			mouseY -= Input.GetAxis("Mouse Y");
//		}
//		Debug.Log(mouseX);
//		transform.eulerAngles = new Vector3(mouseY, mouseX, 0);
//	}
//}
