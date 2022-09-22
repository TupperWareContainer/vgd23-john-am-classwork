using UnityEngine;

public class PlayerInput : MonoBehaviour
{	
	void Update ()
	{
		//we can test for various inputs from the user and then
		//perform some action. Below, we output the axis and value
		//of the "movement" inputs
		float hVal = Input.GetAxis ("Horizontal");
		float vVal = Input.GetAxis ("Vertical");

		if( hVal != 0) 
			print ("Horizontal movement selected: " + hVal);
		
		if (vVal != 0) 
			print ("Vertical movement selected: " + vVal);
		

		//we can also test for specific key presses if we need to
		if (Input.GetKey(KeyCode.M)) 
			print("The 'M' key is pressed down");

		if (Input.GetKeyDown(KeyCode.O))
			print("The 'O' key was pressed");


		//finally, we can test to see if the mouse is moving and by what degree
		float mxVal = Input.GetAxis ("Mouse X");
		float myVal = Input.GetAxis ("Mouse Y");

		if (mxVal != 0) 
			print ("Mouse X movement selected: " + mxVal);
		
		if (myVal != 0) 
			print ("Mouse Y movement selected: " + myVal);
	}
}
