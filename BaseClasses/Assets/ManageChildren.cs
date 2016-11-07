using UnityEngine;
using System.Collections;
public class ManageChildren : MonoBehaviour
{
	public Mesh ChildMesh;
	public Material ChildMaterial;
	BaseClass[] children;
	void Start()
	{
		// in Start() we instantiate ChildA() and ChildB() and assign them to the BaseClass[]. This is valid because they both derive BaseClass.
		// B/C BaseClass had the abstract functions MoveForward() and ChildUpdate() they can be called in the Update() in the Manager. 
		children = new BaseClass[2];
		children [0] = new ChildA ();
		children [0].Initialize (ChildMesh, ChildMaterial);
		children [1] = new ChildB ();
		children [1].Initialize (ChildMesh, ChildMaterial);
	}

	void Update()
	{
		for(int i = 0; i < children.Length; i++)
		{
			children [i].MoveForward (i*0.1f+0.1f, i*3.0f+1.5f);
			children [i].ChildUpdate ();
			children [i].Speak ();
		}
	}
}
//// Original Code
//public class ManageChildren : MonoBehaviour
//{
//	
//	public Mesh ChildMesh;
//	public Material ChildMaterial;
//	BaseClass[] children;
//	
//	// Use this for initialization
//	void Start()
//	{
//		children = new BaseClass[2];
//		
//		children [0] = new ChildA();
//		children [0].Initialize(ChildMesh, ChildMaterial);
//		
//		children [1] = new ChildB();
//		ChildB cb = new ChildB();
//		Debug.Log(cb.MyColor);
//		children [1].Initialize(ChildMesh, ChildMaterial);
//	}
//	
//	// Update is called once per frame
//	void Update()
//	{
//		
//		for (int i = 0; i < children.Length; i++)
//		{
//			children [i].MoveForward(i * 0.1f + 0.1f, i * 3.0f + 1.5f);
//			children [i].ChildUpdate();
//			children [i].Speak();
//		}
//	}
//}