using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This was for the slides
public class SuperFakeDemoScript : MonoBehaviour
{
    //VARIABLES
    //VALUES
    public int numberA;     //Simple whole number
    public float numberB;   //Simple decimal number
    private float outcome;

    //They're like nested variables which we can instantiate. But they're value type
    //Vector 3 is one you're using already
    public struct DataPackage
    {
        public string ourString;
        public int ourInt;
        //They can have methods too
        //They can also have a 'constructor' which sets them up as you instantiate them
    }

    //Because it's an object we can make instances which are distinct
    DataPackage packA;
    DataPackage packB;

    //Arrays/Lists
    int[] arrayOfInts = {1,2,3,4};   //Because it's a value type, I can set its initial value
    int[,] twoDArray = new int[5,5]; //I have to set the sizes here like this
    //There are also 'jagged arrays' [][] which are an 'array of arrays'
    //You can go on infinitely with dimensions but anything past two gets insane to track mentally really fast

    //REFERENCES
    public GameObject ourIntendedTarget;    //Points at an intended object
    public Transform anotherTarget;
    public SuperFakeDemoScript anInstanceOfUs;

    public List<int> listOfInts; //I can't set an initial value here
    //You can do jagged lists too but lets not.

    private void Start()
    {
        //Methods being called
        CalculateNumberA(); //Ordinary Void
        CalculateNumberB(5); //Has a value as a modifier
        outcome = Result(); //Gives us back something, we can put the method anywhere we could put that value
    }

    void CalculateNumberA()
    {
        //Pass our number through our overloaded method
        numberA = OverloadThisNumber(numberA);
        //Then increase it by two
        numberA += 2;
    }

    void CalculateNumberB(float modifier)
    {
        //Pass our number through our overloaded method a different way
        numberB = OverloadThisNumber(numberA, numberB);
        //Multiply it by our argument
        numberB *= modifier;
    }

    //Our method has a type
    float Result()
    {
        //So it must 'return' something
        return numberA + numberB;
    }

    //OVERLOADING
    //These methods are 'the same' but they change based on context
    //You'll be using a heap of these. Physics.Raycast comes to mind
    int OverloadThisNumber(int a)
    {
        return a + 1;
    }

    int OverloadThisNumber(float a, float b)
    {
        return Mathf.RoundToInt(a + b);
    }

    void LoopDemo()
    {
        for(int i = 0; i < 5; i++)
        {
            //this will run 5 times, repeating the action
            //I can use the i as a variable, GREAT for working with arrays/lists
        }

        foreach(int x in arrayOfInts)
        {
            //This will go through each value in our array as well, can use it for any type
        }

        int j = 0;
        while(j < 5)
        {
            j++;
            //This would functionally be like our for loop above right now, it's also super sketchy.
            //This is how we super easily crash everything...
            //Vital for coroutines though.

            listOfInts.Clear();
            listOfInts.Add(j);
        }

        //NESTED LOOPS
        for(int k = 0; k < twoDArray.GetLength(0); k++)
        {
            for (int l = 0; l < twoDArray.GetLength(1); l++)
            {
                //This will go through coloumn by coloumn
                //This is SUPER vital for proc gen
            }
        }
    }

    void ConditionsDemo()
    {
        if(numberA > numberB)
        {
            //Run the thing if B is bigger than A
        }
        else
        {
            //Otherwise do this
        }

        //Ternaries are great for really quick shorthard cause and effect things
        //You can nest them but that gets illegible really fast
        string ternaryOutcome = numberA > numberB ? "A is bigger" : "B is bigger";

        if(OutcomeIsGood())
        {
            //Our bool type method tells us if this should run
        }

        //Switches are a cleaner way of handling situations with a LOT of possible outcomes
        //You need to try and make sure you account for every possible outcome and remember to break
        //Also their format is stupid
        switch(numberA)
        {
            case 0:
                break;
            case 1:
                break;
            default:
                break;
        }
    }

    bool OutcomeIsGood()
    {
        return true;
    }

    //T is basically shorthand for 'it's something?'
    //This is kind of edge case but it lets you make really reusable code if you want to do the same thing to different types
    //GetComponent is one you're no doubt familiar with
    //You don't need the 'where' statement but it's useful for narrowing down the acceptable arguments
    T ThisIsAGeneric<T>() where T : BaseEnemy
    {
        //we could do any kinds of calculations here which result in a reference to one of our enemies and return it
        return FindObjectOfType<BaseEnemy>() as T;  //I'm litterally just spitting back the first one I find though
    }

    void OperatorsGoHere()
    {
        //      = EQUALS!
        //      += INCREASE BY
        //      -= DECREASE BY
        //      *= MULTIPLY BY
        //      /= DIVIDE BY
        //      % MODULUS           -- (this is actually stupidly handy. It returns the remainder of a division)
        //      == IS EQUAL TO?
        //      != DOES NOT EQUAL?
    }
}
