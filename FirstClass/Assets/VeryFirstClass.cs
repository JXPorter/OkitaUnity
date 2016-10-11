using UnityEngine;
using System.Collections;
using System.IO;

public class VeryFirstClass : MonoBehaviour {

		public int num = 0;
		public void PrintNum()
		{
				Debug.Log (num);
		}

		// some other class data field
		public int OtherNum;
		public void PrintOtherNum()
		{
				Debug.Log (OtherNum);
		}

		// Function set A to 3
		public int a = 0;
		public void SetAtoThree()
		{
				a = 3;
		}

		// Function that Prints numbers 1-10
		public void Print10()
		{
				int i = 1;
				while (i <= 10) 
				{
						print (i);
						i++;
				}
		}

	// Use this for initialization
	void Start () {

				Debug.Log (a);
				SetAtoThree ();
				Debug.Log (a);

				Debug.Log ("Print Numbers 1 -10");
				Print10 ();



				Debug.Log ("Ready Player One");
				// This function will write out the string into and create a file called MyFile.txt
				StreamWriter writer = new StreamWriter ("MyFile.txt");
				writer.WriteLine ("Ready Player One.");
				writer.Flush (); // Flush() tells the writer object to finish its work

				VeryFirstClass FirstClass = new VeryFirstClass ();
				FirstClass.num = 1;
				VeryFirstClass SecondClass = new VeryFirstClass ();
				SecondClass.num = 2;
				VeryFirstClass ThirdClass = new VeryFirstClass ();
				ThirdClass.num = 3;

				FirstClass.PrintNum ();
				SecondClass.PrintNum ();
				ThirdClass.PrintNum ();


	}
	
	// Update is called once per frame

		int i = 1;
	void Update () {

				// The Modulo operator in action
				// Modulo computes the remainder after dividing its first operand by its second.
				int mod12 = i % 12;
				Debug.Log (i + "mod12 = " + mod12);
				i++;
	}
}
