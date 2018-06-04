using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This is our singleton. The idea will be that any object in our scene can reference it easily without having to try and find it
//They're thus named though because there can only be one!
//Singleton patterns can be super powerful, but there's a lot of risks you have to watch for and ways they can backfire
public class GameManager : MonoBehaviour
{
    //This is the core of the pattern, we have a reference to a Game Manager which is static,
    //This means it's the same on EVERY game manager (defying our Object Oriented principles). 
    //This is how we bypass needing a reference to a specific instance
    public static GameManager instance;

    //TODO: Save Load

    //TODO: Events and Delegates

	// Use this for initialization
	void Awake ()
    {
        //We're awake, so if there's no instance already we'll assign ourselves to it.
        //We are now THE Game Manager
		if(instance == null)
        {
            instance = this;
        }
        else 
        {
            //This means there's already a Game Manager in the scene, 
            //this is a bad thing that probably means you reloaded the scene you put the original in
            //to avoid anything too catastrophic we'll destroy ourselves (we should be the 'new' one so that should be fine).
            Debug.LogError("Already a Game Manager in the scene"); 
            Destroy(this.gameObject);
        }

        //This keeps us from being destroyed if we go to another scene,
        //This is one of the main reasons you make a singleton, to carry over gameplay stuff between levels
        //Make sure you deliberately destroy it if you do something like go back to the main menu though
        DontDestroyOnLoad(this.gameObject);
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
