using UnityEngine;
using System.Collections;

public class Loops : MonoBehaviour {

	// Use this for initialization
	void Start () {
		//Loops are used to repeat code and can be controlled by
		//either a counter or a sentinel value. A loop is a lot
		//like a condition that repeats to code inside of it until
		//the condition reads 'false'. The following loop counts from 
		//zero to ten
		int count = 0;
		while (count <= 10)
		{
			print(count);
			count++;
		}
		
		//The same can be accomplished with a 'For' loop. A for loop is a
		//countered controlled loop that takes things like the creation
		//of the counter and the incrementation of the counter and puts
		//them in the control line itself. The following For loop will
		//count the even numbers from 2 to 100
		for (int i = 2; i < 100; i += 2)
			print(i);
		
		//The following While loop is sentinel controlled. We don't know
		//how many times it will iterate. It will stop only once it has
		//found its sentinel value. In this case, we are going to iterate
		//until we find a multiple of 11
		int number = 0;
		while (number % 11 != 0)
			number++;
	}
	
}
