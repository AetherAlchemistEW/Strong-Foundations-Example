using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Static classes defy object orientation. They live in the asset directory and can be called from anywhere
//They can only have static variables and static methods and they can't have multiple instances
//I'm gonna fill this one up with a bunch of contrived examples of different forms of methods we might be able to call
//I'll probably only call one or two as examples
//For an example of an existing static class you use a lot (or should), the Mathf class is a static class.
//Mathf is just a script sitting somewhere in Unity with a whole bunch of static math functions on it
public static class CharacterGenerator
{
    private static string[] names = { "Bill", "Bob", "Betty" };

    public static Character GenerateCharacter()
    {
        return new Character(names);
    }
}

public struct Character
{
    public string name;
    public int age;

    public Character(string[] names)
    {
        name = names[Random.Range(0, names.Length)];
        age = Random.Range(18, 50);
    }
}