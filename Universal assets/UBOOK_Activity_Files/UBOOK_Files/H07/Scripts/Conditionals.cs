using UnityEngine;
using System.Collections;

public class Conditionals : MonoBehaviour {

	// Use this for initialization
	void Start () {
		int x = 3;
		int y = 9;
		
		//Conditionals are used to make decisions. In the following, we 
		//output if x is less than 5 and we do nothing if it is greater
		//than or equal to 5
		if (x < 5) {
			print ("x is less that 5");
		}

		//We can also have complex conditionals were we test more than 
		//one item. In the following we see if x is greater than 2 but less that 6
		if (x > 2 && x < 6) {
			print ("x is between 2 and 6");
		}
		
		//Here we see if x is equal to 5 or if y == 9
		if (x == 6 || y == 9) {
			print ("either x is 5 or y is 9");
		}

		//We can specify what to do if a conditional is found to be false
		int grade = 80;
		if (grade >= 90) {
			print ("You have an 'A'");
		} else {
			print ("You do not have an 'A'");
		}

		//Finally, we can have multiple if tests that 'cascade' in to each other.
		//For instance, below we test to see if a grade is an 'A', if it isn't we
		//test to see if it is a 'B', then a 'C', and so on
		if (grade >= 90) {
			print ("You have an 'A'");
		} else if (grade >= 80) {
			print ("You have a 'B'");
		} else if (grade >= 70) {
			print ("You have a 'C'");
		} else if (grade >= 60) {
			print ("You have a 'D'");
		} else {
			print ("You have an 'F'");
		}
	}
	
}
