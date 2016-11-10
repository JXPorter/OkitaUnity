//using UnityEngine;
//using System.Collections;
//
//public class Enums : MonoBehaviour
//{
//	int[] ints = {3, 7, 11, 13, 17, 23 } ;
//	// Use this for initialization
//	void Start()
//	{
//		IEnumerator o = ints.GetEnumerator();
//		while (o.MoveNext())
//		{
//			Debug.Log(o.Current);
//		}
//	}
//}

using UnityEngine;
using System.Collections;
public class Enums : MonoBehaviour
{
	// The IEnumerator is an interface with one property and two methods.
	// The implementation of a new IEnumerator requires two classes. 
	// zombie master
	class ZombieMaster : IEnumerable  // implements the IEnumerable interface - an object that is IEnumberable means that it's got an IEnumerator in it.
									 // this tells us what functions we'll need to add to make the class implement an IEnumberable behaviour.
									// this interace doesn't change the type of class, we're just adding in a new IEnumerable interface to give it an additional C# ability.
	{
		public static string ZombieMasterName;
		private IZombieEnumerator Enumerator;  // we need to add a definition for GetEnumerator method, so we create a private IZombieEnumerator for ZombieMaster to hold onto
		public ZombieMaster(string name)
		{
			ZombieMasterName = name;
			Enumerator = new IZombieEnumerator(); // we add the Enumerator's assignment to the ZombieMaster's constructor
		}
		public IEnumerator GetEnumerator()  // finally we implement the public IEnumerator GetEnumerator(), in which we simply return the Enumerator. The same object created in the constructor.
		{
			return Enumerator;
		}
	}

	class IZombieEnumerator : IEnumerator // we implement the IEnumerator interface
	{
		private string[] minions;         // for a proper interface, we need to have an array to iterate through
		private int NextMinion;			// we need a counter to pick one of the items in the array
		public object Current            // we need a readonly variable called Current to match the interface properties, that is why we only have a get accessor.
		{
			get 
			{return minions[NextMinion]; }   // we combine the array and the counter for the get value
		}
		public IZombieEnumerator()
		{
			minions = new string[]{"stubbs","bernie","michael"};   // we create the array in the IZombieEnumerator's constructor, which could be made even more flexible
																   // by including an array parameter in the argument list of the constructor.
		}
//		public IZombieEnumerator(string[] strings)
//		{
//			minions = strings;
//		}
		public bool MoveNext()                      // implement the MoveNext() and Reset() with their correct return types
		{
			NextMinion++;							// return false - stops the foreach and while loops when we reach the end of the array.
			if (NextMinion >= minions.Length) {
				return false;
			} else 
			{
				return true;
			}
		}
		public void Reset()
		{
			NextMinion = -1;                        // resets the first iteration of NextMinion in the foreach and while loops to -1, so that it is set to 
													//  index 0 (beginning of array) when MoveNext() is called.
		}
	}

	void Start()
	{
		// ZombieMaster is IEnumerable and it has additional properties. You can log its name and iterate through its list of minions.
		// You can use as many interfaces as you wish.
		// Interfaces not only tell you what is expected of your class, but also how to get it done.
		ZombieMaster zombieMaster = new ZombieMaster ("bob");  
		Debug.Log (ZombieMaster.ZombieMasterName);
		foreach(object obj in zombieMaster)
		{
			Debug.Log (obj.ToString());
		}
	}
}

//// Original Code
//public class Enums : MonoBehaviour
//{
//	
//	//zombie master
//	class ZombieMaster : IEnumerable
//	{
//		public static string ZombieMasterName;
//		private IZombieEnumerator Enumerator;
//		public ZombieMaster(string name)
//		{
//			ZombieMasterName = name;
//			Enumerator = new IZombieEnumerator();
//		}
//		public IEnumerator GetEnumerator()
//		{
//			return Enumerator;
//		}
//	}
//	class IZombieEnumerator : IEnumerator
//	{
//		private string[] minions;
//		private int NextMinion;
//		public object Current
//		{
//			get { return minions [NextMinion];}
//		}
//		
//		public IZombieEnumerator()
//		{
//			minions = new string[]{ "stubbs", "bernie", "michael" };
//		}
//		
//		public bool MoveNext()
//		{
//			NextMinion++;
//			if (NextMinion >= minions.Length)
//			{
//				return false;
//			} else
//			{
//				return true;
//			}
//		}
//		
//		public void Reset()
//		{
//			NextMinion = -1;
//		}
//	}
//	// Use this for initialization
//	void Start()
//	{
//		ZombieMaster zombieMaster = new ZombieMaster("bob");
//		
//		Debug.Log(ZombieMaster.ZombieMasterName);
//		
//		foreach (object obj in zombieMaster)
//		{
//			Debug.Log(obj.ToString());
//		}
//	}
//}
