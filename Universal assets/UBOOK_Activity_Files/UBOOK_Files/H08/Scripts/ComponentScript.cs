using UnityEngine;

public class ComponentScript : MonoBehaviour
{
	//we use this variable to keep track of our items scale
	private float itemScale = 1;
	
	void Update ()
	{
		//We can easily access the transform of the game object to manipulate 
		//its position. Here we base the translation on the WASD keys, 
		//the rotation on the mouse, and the scale on the 'N' and 'M' keys
		
		float xMovement = Input.GetAxis ("Horizontal") * .5f;
		float yMovement = Input.GetAxis ("Vertical") * .5f;
		transform.Translate(xMovement, 0f, yMovement);

		float xRotation = Input.GetAxis ("Mouse Y") * 3f;
		float yRotation = -Input.GetAxis ("Mouse X") * 3f;
		transform.Rotate(xRotation, yRotation, 0f);

		if (Input.GetKey(KeyCode.N))
		{
			itemScale -= .1f;
			transform.localScale = new Vector3(itemScale, itemScale, itemScale);
		}
		else if (Input.GetKey(KeyCode.M))
		{
			itemScale += .1f;
			transform.localScale = new Vector3(itemScale, itemScale, itemScale);
		}
	}
}
