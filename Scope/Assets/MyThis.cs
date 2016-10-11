using UnityEngine;
using System.Collections;

public class MyThis: MonoBehaviour 
		{
			float MyFloat;

			public void AssignMyFloat (float f)
			{
				MyFloat = f;
			}

			public void ShowMyFloat ()
			{
				Debug.Log (MyFloat);
			}
			public void AssignThisMyFloat (float MyFloat)
			{
				this.MyFloat = MyFloat; //using the this keyword, we can be sure that the variable is assigned to a class variable,
				// and not something only in the function.
				// The this keyword in only necessary when the name of a parameter in a function matches the variable in a class 
				// where the function's parameter appears. ß
				//Debug.Log(MyFloat);
				print ("I'm working");
			}
			//		class MyAwkwardClass
			//		{
			//				int MyBadlyNamedInt = 0;
			//				void PoorlyNamedFunction ()
			//				{
			//						Debug.Log (this.MyBadlyNamedInt);
			//						int MyBadlyNamedInt = 7;
			//						Debug.Log (this.MyBadlyNamedInt);
			//				}
			//
			//		}

			// Use this for initialization
			void Start ()
			{
				MyThis mt = new MyThis ();
				mt.AssignMyFloat (3.0f);
				mt.ShowMyFloat ();	
				mt.AssignThisMyFloat(5.0f);
				mt.ShowMyFloat ();
			}
	}
	

