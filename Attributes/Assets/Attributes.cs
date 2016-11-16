using System;
using UnityEngine;
using System.Collections;

public class Attributes : MonoBehaviour
{
	
	[Serializable]                         // adding the Serializable Attribute makes the data stored inside of the class savable. 
										// So once we make changes to the values in the serialized class, the editor can save them in the scene.
										// This Attribute tells Unity that this class is a chunk of info that it needs to expose to the Inspector and save with the scene.
	public class nestedClass
	{
		public int myInt;
	}
	
	public nestedClass MyNestedClass;

	[NonSerialized]
	// NonSerialized Attribute allows us to keep this field out of the editor(Inspector Panel). 
	// So any value assigned to the PlainOldInt will not be saved with the scene and the value cannot be set from the editor.
	// Also this variable maintains its public accessor for other classes. 
	public int PlainOldInt;
}

