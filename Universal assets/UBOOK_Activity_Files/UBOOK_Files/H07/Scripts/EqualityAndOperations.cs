using UnityEngine;
using System.Collections;

public class EqualityAndOperations : MonoBehaviour
{
	// Use this for initialization
	void Start ()
	{
		//Values are assigned from right to left. In the following, x is 
		//given the value of 5. The variable y is then given the value
		//of x, which is 5
		int x = 5;
		int y = x;
		
		//Operators can be performed on numbers as well as constants and strings.
		//In the following: 8 + 6 (14) is being assigned to the variable 'add', the value 
		//of 'add' is being divided by 2 (7) and is being assigned to the variable 'div',
		//3 - 4 (1) is being assigned to the variable 'sub', 'sub' is being multiplied by
		//6 (6) and the result is being stored in the variable 'mult', the complex equation
		//(4 + 5) * 3 / 9 + 1 (4) is being assigned to the variable 'comp', and the word 
		//"hello" is being added to the word "world" and is being stored in a string 
		//variable named 'greeting'
		int add = 8 + 6;
		int div = add / 2;
		int sub = 4 - 3;
		int mult = sub * 6;
		int comp = (4 + 5) * 3 / 9 + 1;
		string greeting = "Hello" + "World";
		
		//Operators and assignments can be written shorthand. For instance,
		x += 5;		//is the same as x = x + 5; New value is 10
		y /= 5;		//is the same as y = y / 5; New value is 1
		x++;		//is the same as x = x + 1; New value is 11
		y--;		//is the same as y = y - 1; New value is 0
		
		//Comparison operators return a true or false and can be used to determine
		//values or relationships between numbers
		bool result;
		result = x > y;		//result value: true
		result = add < sub; //result value: false
		result = div == 7;  //result value: true
		result = comp >= 4; //result value: true
		result = mult <= 3; //result value: false
		result = sub != 1;	//result value: false;
	}
}
