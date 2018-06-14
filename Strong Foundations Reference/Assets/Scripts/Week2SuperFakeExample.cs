using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

//We even have a protection level on our class, default for new monobehaviours is public
//We can put some attributes on our classes, we'll get to those
public class Week2SuperFakeExample : MonoBehaviour
{
    //VARIABLES
    private int numberA;    //Only this class can access this variable
    public int numberB;     //Everything everywhere can access this

    //Some things we make (like enums and interfaces) MUST be public or they don't work
    //Anything that shouldn't get modified from anywhere else should be private as a rule

    [Header("These can be a nice simple alternative to custom inspectors")] //Adds a label
    [Range(0,10)]   //Makes it a slider!
    ///It's not all about the inspector
    [SerializeField]
    private int numberX;    //This will show in the inspector
    [HideInInspector]
    public int numberY;     //This won't

    protected int protectedInt;     //This will be accessable in this class OR DERIVED CLASSES (children)

    int defaultInt;         //This is actually 'private' in this case. The default will vary for different things

    readonly int readOnlyInt;       //We can't change this value directly anywhere, it can still have protections as well

    public int ReadOnlyInt     //This special method lets us access the value using the 'get' keyword
    {
        get
        {
            return readOnlyInt;
        }
    }

    public int GetReadOnlyInt()     //We could also write it this way if we know we're only 'getting'
    {
        return readOnlyInt;
    }

    //This is why we really have get/set
    private int tenToZeroGetSet
    {
        get
        {
            return tenToZeroGetSet;
        }
        set
        {
            //We can build in controls on how the values are handled or under what circumstances we can set the value
            //This can be really good for making sure we never get weird values passed around or for storing information
            //differently to how it's being displayed/used elsewhere
            if (value > 0 && value < 10)
            {
                tenToZeroGetSet = value;
            }
        }
    }

    private Animator graphicalStateMachine;

    //Just a struct
    public struct MyDataPack
    {
        private int myInt;
        public string myString;

        //Here's the constructor, we need parameters for each variable inside it
        //The usual convention is just to use the same variable names with an _ ahead of it
        public MyDataPack(int _myInt, string _myString)
        {
            myInt = _myInt;
            myString = _myString;
        }
    }

    public enum GameState
    {
        Paused, PreGame, GameLoop, PostGame,
    }
    public GameState myGameState;

    public enum NumbersAsWords
    {
        A = 2, B = 5, X = 23, Yes = 0,
    }
    public NumbersAsWords numbersAsWords;

    private void Start()
    {
        //We set enums with the set values
        myGameState = GameState.PreGame;
        //We can ask for (and assign from) the number our enum corresponds to
        Debug.Log((int)myGameState); 
        //Be wary of doing this, it won't know what to do if we go myGameState = (GameState)4 for example

        //We're using the constructor so we're instantiating the struct with initial values
        MyDataPack data = new MyDataPack(5, "test");

        if (myGameState == GameState.PostGame)
        {
            numbersAsWords = NumbersAsWords.X;
            Debug.Log(numbersAsWords);
        }

        //How we start our coroutine, we can also use a string, and we can stop them selectively or all at once
        StartCoroutine(MyCoroutine());

        //My animator is handling my states and transitions
        graphicalStateMachine.SetFloat("HealthPercent", 20);   //I keep the values in the animator updated, it handles behaviour

        //Adding to, and calling, our delegate and our event
        myDelegate += LookForHealth;

        MyEvent += LookForHealth;

        myDelegate.Invoke();

        MyEvent.Invoke();
    }

    public void LookForHealth()
    {
        //I could have a directive in here that my scripted behaviour calls to make me look for health packs
    }

    IEnumerator MyCoroutine()
    {
        while(true) //This would be a terrible, TERRIBLE idea anywhere else
        {
            Debug.Log(Time.timeSinceLevelLoad);
            yield return new WaitForSeconds(2);
        }

        //Usually I drop out for a frame for ongoing behaviours
        //I'll sometimes use time for complex equations that don't need constant updating (like some AI stuff)
        //And I'll intersperse it with yields to divide the equation over multiple frames for performace
        //You can also WaitUntil and WaitWhile and provide delegates that evaluate to bools
    }

void CodeFormating() { string Youcandothis = "But WHY THOUGH?!"; Debug.Log(Youcandothis + ", Just don't");
        //There are some circumstances where you want to multiline things though
        string forExample = Youcandothis == "This variable also has gross casing" ? 
            "It does, but also this ternary" :
            "Is way too long to be easily readable on one line";






        string ThisAlsoSucks = "You should camelCase everything, but save first word capitalisation for classes/methods";
        string also = "Look at all those pointless empty lines"; //Technically those lines add to your memory usage...
    }

    //We'll make a void delegate with no arguments, they can of course have arguments and returns
    public delegate void MyDelegate();
    //Now we'll make an instance of it
    public MyDelegate myDelegate;
    //Essentially, delegates are a variable that takes a specified structure of method
    //They can have a whole bunch of them added, like a list of methods to all fire at once

    //Events, are a specialised format for when you want a whole bunch of things all over the place to go off at once
    public event MyDelegate MyEvent;

    //Distinguising the difference between an event and a delegate is difficult, but in practice you'll use delegates internally
    //And events for when you need different instances and objects to all subscribe to something

    //I might have a delegate in my class for doing a whole bunch of similar behaviours I add and remove from based on my state
    //But I might have an event for when an enemy is killed and I need the player, manager, spawner, and UI all to react

    //We can put this content in anywhere
    void MultiThreadingStarter()
    {
        ThreadStart start = new ThreadStart(ThreadMethod); //ThreadStart is a delegate, it can't be empty though
        start += LookForHealth; //We can add more as well if we like
        Thread exampleThread = new Thread(start); //fires up a new thread and puts the delegate methods in there
    }

    void ThreadMethod()
    { //All of this would be happening in parallel to all other code
        
        //If we're locking data it has to be a reference type
        threadDataForExample threadDataClass = new threadDataForExample();
        lock(threadDataClass) //This prevents data from being modified outside of this scope
        {
            //stuff in our thread is done here
        }

    } //Our thread ends, everything is unlocked again
}

public class threadDataForExample
{
    //I can have data and methods in here as usual
}