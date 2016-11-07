//using UnityEngine;
//using System.Collections;
//public abstract partial class BaseClass
//// Setting up the partial base class and the immediate child class at the same time reduces the number of places you might have to go to find problems with your
//// code, but this still isn't the best use case. However, when implementing various interfaces, you can have a different class as a helper for each interface being implemented.
//{
//	public enum Shapes
//	{
//		Box,
//		Sphere
//	}
//	private Shapes mShape;
//	protected Shapes MyShape
//	{
//		get{ return mShape;}
//		set{ mShape = value;}
//	}
//	public abstract void SetShape (Shapes shape);
//}
//public partial class ChildA : BaseClass
//{
//	public override void SetShape(Shapes shape)
//	{
//		switch (shape) 
//		{
//		case Shapes.Box:
//			this.me = GameObject.CreatePrimitive (PrimitiveType.Cube);
//			break;
//		case Shapes.Sphere:
//			this.me = GameObject.CreatePrimitive (PrimitiveType.Sphere);
//			break;
//		}
//	}
//}

//// Original Code
//public abstract partial class BaseClass
//{
//	public enum Shapes
//	{
//		Box,
//		Sphere
//	}
//	private Shapes mShape;
//	protected Shapes MyShape
//	{
//		get{ return mShape;}
//		set{ mShape = value;}
//	}
//	public abstract void SetShape(Shapes shape);
//}
//
//public partial class ChildA : BaseClass
//{
//	public override void SetShape(Shapes shape)
//	{
//		switch (shape)
//		{
//			case Shapes.Box:
//				this.me = GameObject.CreatePrimitive(PrimitiveType.Cube);
//				break;
//			case Shapes.Sphere:
//				this.me = GameObject.CreatePrimitive(PrimitiveType.Sphere);
//				break;
//		}
//	}
//}