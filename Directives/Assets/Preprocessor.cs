#define TESTING                //#define creates a new directive, all #define directive statements must appear before any other tokens in the class
// PREPROCESSOR DIRECTIVES - a system that allows us to enable or disable blocks of code from being executed or contained in code version compiles.
// It acts somewhat like a comment that can use logic to bypass blocks of code.
// It helps manage work with multiple platforms that may use somewhat different versions of your code base.
using UnityEngine;
using System.Collections;

public class Preprocessor : MonoBehaviour
{
	// Use this for initialization
	
	void Start()
	{
		//  #if and #endif allow us to pick chunks of code to switch on/off
		#if TESTING                // can also use !TESTING to check the opposite case of the directive.
		Debug.Log("just testing");
		#endif
		Debug.Log("normal behavior");
	}
	
	// Update is called once per frame
	void Update()
	{
		
	}
}
