//NOTE: GLOBAL ACCESS - It's a good idea to have a central location for your globally accessible structs and enums.
// We can continually add more info to our globally accessible data. Not every C# script needs to contain a class, although they usually do.
// Utility files like Global.cs are handy and provide a clean system where team members can find structures that can be shared between objects in the scene.
using UnityEngine;
using System.Collections;

public struct BoxParameters
{
	public float width;
	public float height;
	public float depth;
	public Color color;
}