using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Keeping things like this in a component means we can put it on anything that might need to have any of these stats
//Players, enemies, even a destructible environmental object might need health/armour
public class Stats : MonoBehaviour
{
    //We need to serialise this if we want it all to show up in the editor properly
    [System.Serializable]
    //Structs make for a convenient packaging and compartmentalising system, they're basically a folder
    //Vector3's are an example of a struct you're used to using (yes, they can have inbuilt methods, and constructors)
    //The biggest difference between a class and a struct is that structs are data types, not reference types.
    public struct CoreStats
    {
        public float health;
    }

    [System.Serializable]
    public struct Resistences
    {
        public float armour;
    }

    //Similarly to a class, we can make multiple instances of these.
    [System.Serializable]
    public struct OffensiveStats
    {
        public float range;
        public float damage;
    }

    //Headers are a nice quick and easy way of adding extra detail to your inspectors without making a custome inspector
    //Because these are properly serialised structs as well, these will also be drop downs in the inspector
    [Header("Primary Attributes")][SerializeField]
    public CoreStats coreStats;

    //Because these are 'nested' inside of our stats class, we can use them freely here.
    //If we wanted to put one of these in another script though, it would be 'public Stats.Resistences' (for example)
    //Usually better to just not nest the structs if you're gonna use them anywhere else though
    [Header("Defensive Attributes, armour, etc")][SerializeField]
    public Resistences resistences;

    //We can reuse our structs for different things! Just like classes, enums, etc
    [Header("Offensive Attriburtes, damage, range, etc")][SerializeField]
    public OffensiveStats meleeStats;
    public OffensiveStats rangedStats;
}
