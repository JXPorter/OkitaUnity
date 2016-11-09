using UnityEngine;
using System.Collections;
public class TreadmillManager : MonoBehaviour
{
	// This TreadmillManager can be used for a scrolling endless runner game.
	class Obstacle
	{

		GameObject obstacle;
		public enum MovementType   // using an enum limits us to a few, well-defined possibilites. And is a good way to tell designers what to expect when a MovementType is selected.
		{
			Static,
			Wave,
			Left,
			Right
		}
		MovementType movementType;
		// we need to give each obstacle its own zposition
		static float zposition;
		private float myZposition;

		// constructor   -- When we specify what to do when a class is instanced, we get to do clever things like create a Primitive Type, etc. If we don't do this in 
		// the constructor then we will need to add in extra function calls to accomplish this same thing. 
		public Obstacle(PrimitiveType primitive, MovementType movement) // can also add parameters to the constructor
		{
			obstacle = GameObject.CreatePrimitive(primitive);
			movementType = movement;
			myZposition = Random.Range(-10f, 10f);
			obstacle.transform.position = new Vector3(Random.Range(-10f,10f),Random.Range(-10f, 10f),Random.Range(-10f,10f));
		}
		// let's move the obstacle
		// The static keyword can give each instance of a class access to the same variable.
		// this code reduces the places where a variable is updated. Each time the static function is called, every instance of the obstacle class gets the change.
		public static void UpdatePosition(float z)
		{
			zposition += z;
		}
		// function that sets the object's position in the game
		public void DrawObstacle()
		{
			Vector3 pos = obstacle.transform.position;
			pos.z = (zposition + myZposition) % 10f;  // pos.z uses the static zposition and the private myZposition, which means that each object can have a unique zposition from all others.
			obstacle.transform.position = pos;
		}
	}
		private Obstacle[] obstacles;
		public int ObstacleCount = 10;
	    // Rather than using a loop to iterate through each object's function, we'll instead use a delegate function to do that for us.
	    delegate void UpdateObstacles();
		UpdateObstacles treadMillUpdates; // the delegate to assign functions is instantiated - UpdateObstacles is the type and treadMillUpdates is the identifier

	void Start()
	{
		obstacles = new Obstacle[ObstacleCount];
		// creates a new array of the size requested
		for(int i = 0; i < ObstacleCount; i++)
		{
			obstacles [i] = new Obstacle (PrimitiveType.Sphere, Obstacle.MovementType.Static);
			// fills in the array with new obstacles, choose a different primitive
			treadMillUpdates += new UpdateObstacles(obstacles[i].DrawObstacle); // by using += we stack the obstacles[i].DrawObstacle function into the treadMillUpdates delegate function.
			// At the end of the for loop, the treadMillUpdates() becomes a single function that calls a stack of other functions.
			// To use the delegate it's added to the Update() loop as a single statement.
			// assign each object's update to the delegate here
			// This code above allows us to use a single delegate function to call many other functions rather than using a for loop to iterate through an array.
		}
	}

	void Update()
	{
		// Once all of the object functions have been assigned to the delegate, you need to only use one line to update all of the objects. Obstacle.UpdatePosition() changes the
		// zposition  for all of the objects, and now treadMillUpdates() sets the position to the updated data.
		Obstacle.UpdatePosition(-0.1f);
		treadMillUpdates ();
//		// this foreach loop is replaced by the delegate function called treadMillUpdates().
//		foreach(Obstacle o in obstacles)
//		{
//			o.UpdatePosition (-0.01f);
//		}
	}
}
//// Original Code
//public class TreadmillManager : MonoBehaviour
//{
//	
//	class Obstacle
//	{
//		GameObject obstacle;
//		public enum MovementType
//		{
//			Static,
//			Wave,
//			Left,
//			Right
//		}
//		MovementType movementType;
//		static float zposition;
//		private float myZposition;
//		//constructor
//		public Obstacle(PrimitiveType primitive, MovementType movement)
//		{
//			obstacle = GameObject.CreatePrimitive(primitive);
//			movementType = movement;
//			myZposition = Random.Range(-10f, 10f);
//			obstacle.transform.position = 
//				new Vector3(Random.Range(-10f, 10f),
//				            Random.Range(-10f, 10f),
//				            Random.Range(-10f, 10f)); 
//		}
//		//move the obstacle
//		public static void UpdatePosition(float z)
//		{
//			zposition += z;	
//		}
//		public void DrawObstacle()
//		{
//			Vector3 pos = obstacle.transform.position;
//			pos.z = (zposition + myZposition) % 10f;
//			obstacle.transform.position = pos;
//		}
//	}
//	
//	private Obstacle[] obstacles;
//	public int ObstacleCount = 1000;
//	delegate void UpdateObstacles();
//	UpdateObstacles treadMillUpdates;
//	// Use this for initialization
//	void Start()
//	{
//		obstacles = new Obstacle[ObstacleCount];
//		//creates a new array of the size requested
//		for (int i = 0; i < ObstacleCount; i++)
//		{
//			obstacles [i] =
//				new Obstacle(PrimitiveType.Sphere,
//				             Obstacle.MovementType.Static);
//			treadMillUpdates +=
//				new UpdateObstacles(obstacles [i].DrawObstacle);
//		}
//	}
//	
//	// Update is called once per frame
//	void Update()
//	{
//		Obstacle.UpdatePosition(-0.1f);
//		treadMillUpdates();
//	}
//}
