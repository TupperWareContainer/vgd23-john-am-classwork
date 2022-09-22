using UnityEngine;
using System.Collections;

public class VariableScript : MonoBehaviour {
	//These are global variables. They will exist anywhere inside
	//this file. Any changes that we make to them will be reflected
	//everywhere.
	public string myString = "";//This variable is public. Other files can access it
	private int number;			//this variable is private. It is only accessible in this file
	
	// Use this for initialization
	void Start () {
	
		//we give number a value in the Start function, and it will retain its value
		//in the Update function
		number = 70;
		
		//These are local variables. They will not exist outside of the
		//Start function (this function)
		int x = 5;
		float y = 3.4F;
		double z = 8.8;
		
		bool isDone = false;
		
		char myChar = 'C';
		string name = "Mike Geig";		
		
		//Here we output the value entered by the user for the public
		//string 'myString'
		print ("The value of the public string 'myString' is " + myString);
	}
	
	// Update is called once per frame
	void Update () {
	
		//we print number here and it should still have the value of
		//70 from the Start function
		print ("The value of 'number' is " + number);
	}
}
