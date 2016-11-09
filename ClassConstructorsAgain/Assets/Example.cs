using UnityEngine;
using System.Collections;
// Class Constructors
public class Example : MonoBehaviour
{
	// sub class declaration
	public class MyClass
	{
		// sub class string called name
		private string name;
		public MyClass(string n) // when a class declaration has a function with a matching identifier inside of the class, that function becomes the class's constructor.
		{
			// assigns the internal name to a string called n
			name = n;
		}
		public MyClass(int n)
		{
			name = n.ToString();
		}
	}

	void Start()
	{
		// uses the class constructor
		MyClass mc = new MyClass(3);
	}

}