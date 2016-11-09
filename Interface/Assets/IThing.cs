// An interface is a promise that your new class will implement a function from its base class. 
// Anything that has a signature with an identifier and argument list can be turned into an interface for a base class.
// It provides a framework that all of the child classes based on it will derive from. And ensures that you always get the same implementation for each class that uses the same interfaces
// This is a good idea so that all of the pickups, weaopons, or enemies in the game have the same interface so that all programmers have a guide on how to code thier properties and functions
// Unlike many other classes an interface isn't directly used in Unity3D. 
// The naming convention always starts with an I to indicate that the class is an interface.
// All Interface members must be public

// When you add a small bit of code to an interface you'll need to find everything (all classes and code) that uses the interface and add the new changes to them.
public interface IThing
{
	// this syntax is called an interface property, and the format we are seeing is how a property is created in an interface.
	// Interface properties are consistent identifiers which all classes that implment the interface will have.
	// The interface property is used as a system to allow each implementation of that interface to change how the property is used.
	// Interface implementations must be public
	string ThingName // For every class that implements the IThing interface, we must have a system to set a ThingName
	{
		get;
		set;
	}
	void SayHello ();
}
//// Original Code
//
//public interface IThing
//{
//	string ThingName
//	{
//		get;
//		set;
//	}
//	void SayHello();
//}