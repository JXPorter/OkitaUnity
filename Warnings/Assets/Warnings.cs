using UnityEngine;
using System.Collections;
using System;      // the addition of the using System directive will open up our Exception type to our catch{} call.
using System.IO;

public class Warnings : MonoBehaviour
{
	public string input;

	int CheckInput (string s)
	{
		int parsed = 0;
		if(string.IsNullOrEmpty(s))
		{
			MyException e = new MyException ("null");
			e.Number = 0;
			throw e;
//			// throw keyword used to create a new Exception() with a message inside;
//			throw new Exception ("null");  //one of the overrides of the Exception class is message. We can use the message to tell us what created the Exception and what to do about it.
//			// this null string will be passed to the Exception message when it is caught in the catch{}.
		}
		parsed = int.Parse (s);
		if (parsed > 100) 
		{
			MyException e = new MyException ("too high");
			e.Number = parsed;
			throw e;
		}
		return parsed;
	}

	public class MyException : Exception
	{
		public int Number; // since we've been dealing with an int, we add this relevant info

		public MyException()
		{
			
		}
		public MyException(string message) : base(message)
		{
			
		}
		public MyException(string message, Exception innerException) :base(message,innerException)
		{
			
		}
	}

	void Start()
	{
		FileStream file = null;
		FileInfo fileInfo = null;
		try
		{
			fileInfo = new FileInfo("C:\\file.txt");
			file = fileInfo.OpenWrite();
			for(int i = 0; i < 255; i++)
			{
				file.WriteByte((byte)i);
			}
		}
		catch(UnauthorizedAccessException e)
		{
			Debug.Log (e.Message);
		}
		finally 
		{
			if (file != null)
			{
				file.Close ();
				Debug.Log ("File written");
			}
		}
	}

	void Update()
	{
		int i =0;
		// give parsing a shot
		try
		{
			i = CheckInput(input);
		}
		//nope, did not work
		// the catch{} that follows the CheckInput() will catch the Exception() created before it.
		catch (MyException e)                 // if the try statement fails, then the catch statement tries to make a correction. If try{} succeeds, then catch is ignored.
		{
			i = e.Number;
			if(e.Message == "too high")
			{
				Debug.Log ("use a lower number");
			}
			else if (e.Message == "null")
			{
				Debug.Log ("Input a number");
			}
//			Debug.LogWarning (e); // The Exception type will output an error message to the Console window so that we know what happenned. 
//			i = 1;
		}
		finally  // finally comes in handy when functions require some cleanup afterward
		{
			Debug.Log("done!");
		}
		Debug.Log ("i= " +i);

	}
}

//// Original Code
//public class Warnings : MonoBehaviour
//{
//	
//	void Start()
//	{
//		FileStream file = null;
//		FileInfo fileInfo = null;
//
//		try
//		{
//			fileInfo = new FileInfo("C:\\file.txt");
//			
//			file = fileInfo.OpenWrite();
//			
//			for (int i = 0; i < 255; i++)
//			{
//				file.WriteByte((byte)i);
//			}
//		} catch (UnauthorizedAccessException e)
//		{
//			Debug.LogWarning(e.Message);
//		} finally
//		{
//			if (file != null)
//			{
//				file.Close();
//			}
//		}
//	}
//	
//	public string input;
//	public int i;
//	public class MyException : Exception
//	{
//		public int Number;
//		
//		public MyException()
//		{
//		}
//		
//		public MyException(string message) : base(message)
//		{
//		}
//		
//		public MyException(string message, Exception innerException)
//			: base(message,innerException)
//		{
//		}
//	}
//	
//	int CheckInput(string s)
//	{
//		int parsed = 0;
//		
//		if (string.IsNullOrEmpty(s))
//		{
//			MyException e = new MyException("null");
//			
//			e.Number = 0;
//			throw e;
//		}
//
//		parsed = int.Parse(s);
//		
//		if (parsed > 100)
//		{
//			MyException e = new MyException("too high");
//			e.Number = parsed;
//			throw e;
//		}
//		if (parsed < 0)
//		{
//			throw new UnassignedReferenceException();
//		}
//		return parsed;
//	}
//
//	void Update()
//	{
//		i = 0;
//		
//		//give parsing a string a shot
//		try
//		{
//			i = CheckInput(input);
//		} catch (MyException e)
//		{
//			i = e.Number;
//			if (e.Message == "too high")
//			{
//				Debug.Log("use a lower number");
//			} else if (e.Message == "null")
//			{
//				Debug.Log("input a number");
//			}
//		} finally
//		{
//			Debug.Log("done!");
//		}
//		
//		Debug.Log("i = " + i);
//	}
//}