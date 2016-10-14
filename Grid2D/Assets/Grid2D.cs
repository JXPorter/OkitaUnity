using UnityEngine;
using System.Collections;

public class Grid2D : MonoBehaviour
{
	public int Width;
	public int Height;
	public GameObject PuzzlePiece;
	private GameObject[,] Grid;

	void Start()
	{
		Grid = new GameObject[Width, Height];
		for(int x = 0; x < Width; x++)
		{
			for(int y = 0; y < Height; y++)
			{
				GameObject go = GameObject.Instantiate (PuzzlePiece) as GameObject;
				Vector3 position = new Vector3 (x,y,0);
				go.transform.position = position;
				Grid[x,y] = go;
			}
		}
	}

	void Update()
	{
		Vector3 mPosition = Camera.main.ScreenToWorldPoint (Input.mousePosition); //converts mousePosition into a point in space near the puzzle pieces
		UpdatePickedPiece(mPosition);

	}

	// This function is called from Update() and accepts a Vector3 argument.
	void UpdatePickedPiece(Vector3 position)
	{
		// since Grid[x,y] index is an integer value, we should convert Vector3.x and Vector3.y into ints
		// since when we cast to an int from a float we lose data, we add .5 to the float before it gets cast so that we better
		// approximate the expected value as an integer.
		int x = (int)(position.x + 0.5f);
		int y = (int)(position.y + 0.5f);
		Debug.DrawLine (Vector3.zero, position);

		// The puzzle piece should return to white if we are not touching it. The solution is to set all of the objects to white,
		// and the colore the current object red.

		for (int _x = 0; _x < Width; _x++)
		{
			for (int _y = 0; _y < Height; _y++)
			{
				GameObject go = Grid [_x, _y];
				go.GetComponent<Renderer> ().material.SetColor ("_Color", Color.white);
			}
		}

		// These int values can now be used to pick the PuzzlePiece with Grid[x,y]
		// Checking to see IndexOutOfRangeException caused by player moving the cursor out of the Grid space area
		if (x >= 0 && y >= 0 && x < Width && y < Height) 
		{
			GameObject go = Grid [x, y];
			go.GetComponent<Renderer> ().material.SetColor ("_Color", Color.red); // change the selected puzzle piece to red
		}

	}

}

//// Original Code
///*
// * public class Grid2D : MonoBehaviour
//{
//	public int Width;
//	public int Height;
//	public GameObject PuzzlePiece;
//	private GameObject[,] Grid;
//
//	// Use this for initialization
//	void Start()
//	{
//		Grid = new GameObject[Width, Height];
//		for (int x = 0; x < Width; x++)
//		{
//			for (int y = 0; y < Height; y++)
//			{
//				GameObject go =
//					GameObject.Instantiate(PuzzlePiece) as GameObject;
//				Vector3 position = new Vector3(x, y, 0);
//				go.transform.position = position;
//				Grid [x, y] = go;
//			}
//		}
//	}
//
//	// Update is called once per frame
//	void Update()
//	{
//		Vector3 mPosition =
//			Camera.main.ScreenToWorldPoint(Input.mousePosition);
//		UpdatePickedPiece(mPosition);
//	}
//	
//	void UpdatePickedPiece(Vector3 position)
//	{
//		
//		int x = (int)(position.x + 0.5f);
//		int y = (int)(position.y + 0.5f);
//		
//		for (int _x = 0; _x < Width; _x++)
//		{
//			for (int _y = 0; _y < Height; _y++)
//			{
//				GameObject go = Grid [_x, _y];
//				go.GetComponent<Renderer>().material.SetColor("_Color", Color.white);
//			}
//		}
//		
//		if (x >= 0 && y >= 0 && x < Width && y < Height)
//		{
//			GameObject go = Grid [x, y];
//			go.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
//		}
//	}
//}
//*/
