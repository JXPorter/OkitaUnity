using UnityEngine;
using System.Collections;

// sneaking in some code to ChildA
// If we're in ChildB and decide that ChildA is missing a scale function or other code, we can add it without going back to the ChildA class and adding code there.
// NOTE: This is unorthodox and deviates from strict programming practice, but it is possible, if necessary.
public partial class ChildA : BaseClass
{
	// In this instance, we need a system for ChildB to set its scale to some arbitrary new size. We can do this by adding code locally to ChildB or we can make sure
	// that anything else deriving from ChildA will also have this ability. This means that ChildA has this new ability too. The result of using partial classes like this leads
	// to scattered code, but it can be useful to utilize partial keyword sometimes.
	private float mScale;
	protected float MyScale
	{
		get { return mScale;}
		set { mScale = value;}
	}
	protected void SetScale(float scale)
	{
		MyScale = scale;
		me.transform.localScale = Vector3.one * MyScale;
	}
}

public class ChildB :ChildA
{
	#region ChildB_properties
	private Color mColor;
	public Color MyColor
	{
		get { return mColor;}
		set { mColor = value;}
	}
	#endregion
	#region ChildB_functions
	public override void Initialize (Mesh mesh, Material material)
	{
		base.Initialize (mesh, material); // when keyword base is invoked within a function, we're informing C# that we want to do what's
		// already been done in the previous layer of that code. base tells C# to execute the parent class' version of the function after the dot operator.
		this.MyColor = new Color (1,0,0,1);
		MyMeshRenderer.material.color = this.MyColor;
		// using the SetScale function just added to ChildA
		SetScale(2.0f);
	}
	#endregion
}
//// Original Code
////sneaking code into a base class
//public partial class ChildA : BaseClass
//{
//	private float mScale;
//	protected float MyScale
//	{
//		get { return mScale;}
//		set { mScale = value;}
//	}
//	protected void SetScale(float scale)
//	{
//		MyScale = scale;
//		me.transform.localScale = Vector3.one * MyScale;
//	}
//}
//
//public class ChildB : ChildA
//{
//#region ChildB_properties
//	private Color mColor;
//	public Color MyColor
//	{
//		get { return mColor;}
//		set { mColor = value;}
//	}
//#endregion
//#region ChildB_functions
//	public override void Initialize(Mesh mesh, Material material)
//	{
//		base.Initialize(mesh, material);
//		this.MyColor = new Color(1, 0, 0, 1);
//		MyMeshRenderer.material.color = this.MyColor;
//		//using the SetScale function just added to ChildA
//		SetScale(2.0f);
//	}
//#endregion
//}