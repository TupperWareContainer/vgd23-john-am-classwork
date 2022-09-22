using UnityEngine;

public class Methods : MonoBehaviour
{
	// Use this for initialization
	void Start ()
	{
		//We call or 'invoke' the method CallThisMethod
		CallThisMethod ();
		
		//We call the OutputValue methods
		OutputValue (6);		//uses the first method
		OutputValue ("Hello");	//uses the second method
		
		//We call the AddNum method. Since that method returns
		//a value, we need to 'catch' that value in a variable
		int x = AddNum (4, 5);
		OutputValue (x);
	}
	
	//This is a very basic method. It does not read in any values and
	//it does not return any values. 
	void CallThisMethod ()
	{
		print ("Method 'CallThisMethod' has been called");		
	}
	
	//This method will read in a number and output it to the screen
	void OutputValue (float item)
	{
		print ("Item entered: " + item);
	}
	
	//This method is a copy of the previous 'OutputValue' method. The difference
	//with this method is that it reads in a different type. Since they both have
	//the same name, this is know as 'Overloading'
	void OutputValue (string item)
	{
		print ("Item entered: " + item);
	}
	
	//The following method is our most complex method yet. It reads in two interger
	//values. It will then add them together and return them back to the caller without
	//outputing it to the screen
	int AddNum (int num1, int num2)
	{
		int result = num1 + num2;
		return result;
	}
}
