using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Static classes defy object orientation. They live in the asset directory and can be called from anywhere
//They can only have static variables and static methods and they can't have multiple instances
//I'm gonna fill this one up with a bunch of contrived examples of different forms of methods we might be able to call
//I'll probably only call one or two as examples
//For an example of an existing static class you use a lot (or should), the Mathf class is a static class.
//Mathf is just a script sitting somewhere in Unity with a whole bunch of static math functions on it
public static class StaticLibrary
{ 
    //Methods with returns
    //Methods with arguments
    //Method overloading
    //Generics

    //Generic return with generic argument but only accepting types castable to IFlamable
    public static T GenericMethodFlamable<T>(T x) where T : IFlamable
    {
        //Basically, if we pass in the player or enemy b, they'll be passed in and right back,
        //It won't call if we put anything else in.
        //We'd never really write a method to do something as basic as this, we'd just cast it, but it's a clear example
        return x;
    }
}