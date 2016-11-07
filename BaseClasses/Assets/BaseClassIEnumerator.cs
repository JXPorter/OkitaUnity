using UnityEngine;
using System.Collections;
// Normally, C# would complain that the class name doesn't match the file name. This exception is made for classes not deriving from MonoBehaviour. By avoiding
// MonoBehaviour we can take some liberties with the C# language. The partial(), abstract(), and virtual() functions and classes offer a great deal of
// flexibility not allowed when deriving from MonoBehaviour.
public abstract partial class BaseClass : IEnumerator, ICollection
{

	public IEnumerator GetEnumerator()
	{
		throw new System.NotImplementedException();
	}

	public bool MoveNext()
	{
		throw new System.NotImplementedException();
	}

	public void Reset()
	{
		throw new System.NotImplementedException();
	}

	public object Current
	{
		get
		{
			throw new System.NotImplementedException();
		}
	}
}