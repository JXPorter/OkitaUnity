using UnityEngine;
using System.Collections;

// the partial keyword gives us the ability to tack on last minute functionality to the ChildA class.
// NOTE: That using partial tends to lead to scattered code and angry debugging sessions!
public partial class ChildA : BaseClass
{
	#region ChildA_properties
	protected GameObject me;
	#endregion
	public override void Initialize(Mesh mesh, Material material)
	{
		this.MyMesh = mesh;
		this.MyMaterial = material;
		me = new GameObject(this.ToString());
		MyMeshFilter = me.AddComponent<MeshFilter> ();
		MyMeshFilter.mesh = this.MyMesh;
		MyMeshRenderer = me.AddComponent<MeshRenderer> ();
		MyMeshRenderer.material = this.MyMaterial;
	}
	public override void MoveForward(float speed, float turn)
	{
		Speed = speed;
		Turn += turn;
		ChildRotation = new Vector3 (0, Turn, 0);
	}
	public override void ChildUpdate()
	{
		ChildTransform = me.transform.forward * Speed;
		me.transform.localPosition += ChildTransform;
		me.transform.localEulerAngles = ChildRotation;
	}
	public override void Speak()
	{
		Debug.Log (me.name + " word");
	}
}
//// Original Code
//public partial class ChildA : BaseClass
//{
//	#region ChildA_properties
//	protected GameObject me;
//	#endregion
//	public override void Initialize(Mesh mesh, Material material)
//	{
//		this.MyMesh = mesh;
//		this.MyMaterial = material;
//		me = new GameObject(this.ToString());
//		MyMeshFilter = me.AddComponent<MeshFilter>();
//		MyMeshFilter.mesh = this.MyMesh;
//		MyMeshRenderer = me.AddComponent<MeshRenderer>();
//		MyMeshRenderer.material = this.MyMaterial;
//	}
//	
//	public override void MoveForward(float speed, float turn)
//	{
//		Speed = speed;
//		Turn += turn;
//		ChildRotation = new Vector3(0, Turn, 0);
//	}
//
//	public override void ChildUpdate()
//	{
//		ChildTransform = me.transform.forward * Speed;
//		me.transform.localPosition += ChildTransform;
//		me.transform.localEulerAngles = ChildRotation;
//	}
//	
//	public override void Speak()
//	{
//		Debug.Log(me.name + " word");
//	}
//}