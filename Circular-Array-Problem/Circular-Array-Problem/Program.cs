using System;
using System.Collections.Generic;

namespace Circular_Array_Problem
{
    public class Program
    {
        public int[] circularArrayRotation(int[] a, int k, int[] queries)
        {
            int[] returning = new int[queries.Length];
            Dictionary<int, int> Indexes = new Dictionary<int, int>();
            int length = a.Length;
            for(int i = 0; i<a.Length; i++)
            {
                int value = a[i];
                int newIndex = ((i + k) % length);

                if(newIndex < 0)
                {
                    newIndex = length + newIndex;
                }

                Indexes.Add(newIndex, value);
            }

            for(int i = 0; i<queries.Length; i++)
            {
                int index = queries[i];
                returning[i] = Indexes[index];
            }

            return returning;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            //https://github.com/codejoncode/Circular-Array-Problem.git 
            int[] array1 = new int[3]
            {
                1,2,3
            };
            int[] query1 = new int[3]
            {
                0,1,2
            };
            var newProgram = new Program(); 

            int[] set1 = newProgram.circularArrayRotation(array1, 2, query1);

            for(int i = 0; i< set1.Length; i++)
            {
                Console.WriteLine(set1[i]);
            }
        }
    }
}

/*

   One rotation operation moves the last array element to the first position and shifts all remaining elements right one. 
Example [3,4,5]  rotation    [5,3,4]

Receive an array of integers.   Perform the rotation a number of times. Then determine the value of the element at a given position.  

Example A = [3,4,5]  number of rotations k = 2 and indices to check, m = 1,2]

First we perform the two rotation: 

[3,4,5]  [5, 3,4]  [4,5,3]
Now return the values from the zero based indices 1 and 2 as indicated in the m array. 
A[1] = 5
A[2] = 3

What am I returning?  An array of integers representing the values at the specified indices.  

Circular Array Rotation has the following parameter(s):
	A: an array of integers to rotate
	K: an integer, the rotation count
	Queries: an array of integers, the indices to report
	
Q can be   10000 length   q could be 500 length; 

I want to use  the key object pair to my disposal.  I get operation 0{1) look up can modification.   In order to keep the speed efficient I don't want to use the array. Pushing and shift elements can become quite expensive. 

Here's what I want: / My plan: 
	1. Create a key pair object that will grab every index and every value. 
	2. Create a  empty object.   
One Object will be as the list currently is. The other object will represent my moves.  

Example: 

I would iterate over the list  a = [3,4,5]; 
I would create the following {0:3, 1: 4, 2:5};

My other object will be  {}; 

Now it seems complex but it really isn't.  Two rotations just means I am going to pop off from the end  [a.length -1]  twice  any item not at the end should get its  index increased by 1.  

For(let I = 0; i<length; i++)
   if I != a.length-1:
	blankObejct[i+1] =  current[i];
At the end. 
Flip   spread  {…blank} into current after emptying the current then empty the blank.  

That still may be too many operations. 

I would also have to nest the for loop for that.   For  rotations   for   I in  length. 

If  I rotate twice  I need to take the   length into consideration     length = 3  rotation = 2.  

 
Testing out a theory.  

[1,2,3]  [3,1,,2] [2,3,1]   

3 rotations I am going to add 3 to the beginning index.  To the % of length-1. 

0 index of the array = 1     0 + 3 = 3  which is out of bounds  - 1.   = -1 2  

1 index of the array = 2   1 + 3 = 4  which is out of bounds   and % 2 ==  0  

2 index of the array = 3  2+ 3 = 5 5 which should equal  1

% formula is off

Circular array Problem

console.log((0 + 3) % 3 - 1) : -1 
console.log((1+3) % 3 - 1) : 0
console.log((2+3) % 3 - 1) : 1

This above represents the idea I have.  It appears that there is a pattern and it may not be true but it appears there is.  Due to the fact that a rotation is taking the last item off and putting it up front everything else slides over one. I just have to make sure it doesn't go out of bounds.   The first line: 

console.log((0 + 3) % 3 - 1) : -1   represents the 1  it should return to the last position of the array in which it does. 

console.log((1+3) % 3 - 1) : 0 represents the 2 it should sit at the head of the array which it does.  

console.log((2+3) % 3 - 1) : 1 represents the 3 which should be in index 1. 

I have a meeting with VE then I will get back to this.   

Current formula to try: ( ( (Index +  k)  % length) - 1)
Plan is to go through the list one time and grab the order on an object.  I will then use another method to put together the return data.   Big O  2N  drop the constant O(n).    
     

Utimately I was wrong with my oritianl accessment. I don't need to do -1  and I got the answer correct. 
     
*/
