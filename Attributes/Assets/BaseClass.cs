using UnityEngine;
using System.Collections;
using System.Reflection;
using System;

public class BaseClass
{
	public string name;
	
	public BaseClass(string n)
	{
		this.name = n;
	}
	
	[MyAttribute("Update")]              // we added an Attribute called "Update". We look for this name when using the reflection system
	public void OnUpdate()
	{
		Debug.Log(name + " is updating...");
	}
		// With a few different instances of this class in the scene, we can see that they can all share the same attribute over different functions.

	void Start()
	{
		// this creates 10 BaseClass objects and adds them to an array.
		BaseClass[] baseClasses = new BaseClass[10];
		for (int i = 0; i < 10; i++)
		{
			BaseClass bc = new BaseClass (i.ToString());
			baseClasses [i] = bc;
		}

		// we need to look at the class, find all the functions in the classes, get the attributes of those functions, and then add the function the UpdateEvent.
		// First we begin by getting each object
		// We look into our array of found objects and then get the type of the object. This allows us to get the methods from t with the GetMethods() reflection function.
		// This turns into a MethodInfo[] array, where we can sort through each one and look for attributes.
		foreach(object o in baseClasses)
		{
			  Type t = o.GetType();
			  MethodInfo[] methods = t.GetMethods();
			foreach(MethodInfo method in methods)
			{
				object[] attributes = method.GetCustomAttributes (true);  // we look at the object's custom attributes assigned to the object[] attributes variable.
				// Now that we have an array of attributes for each method, we need to look at each attribute
				foreach(object attribute in attributes)
				{
					if(attribute is MyAttribute)      // check to see if this is the attribute that we expect, e.g. MyAttribute
					{
						MyAttribute ma = attribute as MyAttribute;
						//MyAttribute ma = (MyAttribute) attribute;
						if(ma.Name == "Update")       // if ma is named "Update" then we'll add the method we started looking at to the event.
						{
							EventInfo ei = typeof(SpecialAttributes).GetEvent("UpdateEvent");  // first, we need to get the EventInfo of the event we're assigning it to
							Type et = ei.EventHandlerType;                                    // second, we get the type from ei, where the EventHandlerType is the UpdateHandler which the UpdateEvent is assigned to.
							Delegate d = Delegate.CreateDelegate(et, o, method);           // each function found in the object of the correct type gets a new delegate assigned to it
																						// CreateDelegate() takes 3 args - 1. the type it's creating a delegate for, 2. what owns the function we're assigning to that event
																						// 3. what function is being assigned to the event, e.g. function we scanned for MethodInfo method attributes.
							ei.AddEventHandler(this, d);							// assign Delegate d to EventInfo we got from SpecialAttributes class ei by using AddEventHandler()
																					// first arg is the object that the event is assigned to, this assigns the class to itself as the object
																					// the callback assigned to this object is Delegate d.
							// Now when the game is run, objects are created.
							// After they are created, they are scanned for functions that
							// have attributes. IF the attribute's name is "Updated", then the function is assigned to the UpdateEvent
							// which is called from MonoBehaviour's Update().
							// This sort of utility allows for a great number of simple ways to connect classes together. Better interobject
							// communication allows for your code to more intelligently.
							// This might not be the best way to operate a scene. It is brute force. A more simple method would be to use 
							// eventHandler += object.OnUpdate(); 
							// However, in a situation where you can't create the scene manager before the objects, something like this might be more useful.
						}
					}
				}
			}
		}
	}
}