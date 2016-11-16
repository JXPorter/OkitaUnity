using System;
using UnityEngine;
using System.Collections;

// CUSTOM ATTRIBUTES
// C# allows us to add a lable to a function to apply additional information to each function. Once a function is labeled another class is able to inspect a
// different class and find labled functions. Once found, a function's attributes can be inspected and proper adjustments made to use it. 
// An attribute is a tag that classes can add to functions, e.g. [Serializable].

// The concept of a class being able to collect info on another object is called Reflection. Using the System.Reflection class, an object is allowed to
// inspect another class or struct in depth. E.g. a function like int AddInts(int a, int b); you can tell it has two arguments and an int return type. Reflection
// gives us the ability to read the function's arguments, return type, and its name. But this might not be enough info for you to work with.
// Reflection allows your code to make decisions based on attributes assigned to functions. 
// A Custom Attribute is a class that inherits from System.Attributes class and is a special class used to define custom attributes. 

// Custom Attributes provides an easy readable system to attach important info to a function or variable.
// e.g. an Update attribute with a time delay [UpdateAttribute(3.0f)] can indicate if a function should be added to an update event and how often it should be updated.

[AttributeUsage(AttributeTargets.All, AllowMultiple = true, Inherited = true)]    // inside [] is the AttributeUsage() with an AttributeTargets.All enum in the argument list. 
																				  //This indicates that the attribute can be applied to any type of data.
																				  // AllowMultiple = true - you can stack different attributes over a class member.
																				  // Inherited = true - tells anything inspecting this attribute that any child class inheriting the member will have the accompnying attribute.
public class MyAttribute : Attribute
{
	public string name;
	public string Name
	{
		get { return this.name;}
	}

	public int number;
	public int Number
	{
		get { return this.number;}
		set{ this.number = value;}
	}
	public MyAttribute(string name)     // For the MyAttribute to be assigned to a class member and have some info, it needs a constructor, which adds any data inside
										// the attribute that will be needed later on. Assign more arguments allows for more properties of the attribute to be assigned.
	{
		this.name = name;
	}
}
//// Original Code
//[AttributeUsage(AttributeTargets.All, AllowMultiple = true, Inherited = true)]
//public class MyAttribute : Attribute
//{
//	public string name;
//	public string Name
//	{
//		get{ return this.name;}
//	}
//	
//	public int number;
//	public int Number
//	{
//		get{ return this.number;}
//		set{ this.number = value;}
//	}
//
//	public MyAttribute(string name)
//	{
//		this.name = name;
//	}
//}
//
//public enum MyTypes
//{
//	Monster,
//	Hero,
//	NPC
//}
//
//[AttributeUsage(AttributeTargets.All, AllowMultiple = true, Inherited = true)]
//public class PlayerType : Attribute
//{
//	public MyTypes myType;
//	public PlayerType(MyTypes mType)
//	{
//		this.myType = mType;
//	}
//}