using UnityEngine;
using System.Collections;

public class Logic : MonoBehaviour
{
    public GameObject A_Cube;
    public GameObject B_Cube;

    // Use this for initialization
    void Start()
    {
	
    }
	
    // Update is called once per frame
    void Update()
    {
		Color col = Color.red;
        float Ax = A_Cube.transform.position.x;
        float Ay = A_Cube.transform.position.y;
        float Bx = B_Cube.transform.position.x;
        float By = B_Cube.transform.position.y;

 

        GetComponent<Renderer>().material.color = col;
    }
}
