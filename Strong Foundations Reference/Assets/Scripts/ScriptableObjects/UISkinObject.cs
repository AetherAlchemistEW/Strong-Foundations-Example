using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//The Create Asset Menu property conveniently adds creating this object to Unity's Create menu

//The System.Serializable property tells the computer this file can be serialized
//Serialization basically means the values can be saved properly
//It's vital for things that go in the asset menu, like scriptable objects, and custom inspectors.
//If you don't serialize your fields, their values might not save properly (or might get lost when put into source control)

[CreateAssetMenu(menuName = "UI Skin")]
[System.Serializable]
public class UISkinObject : ScriptableObject //We inherit from the scriptable object class
{
    [SerializeField]
    public Color backingColour;
    [SerializeField]
    public Color highHealthColour;
    [SerializeField]
    public Color lowHealthColour;

    //This is too complicated to draw normally, we need a custom inspector
    [SerializeField]
    public FontStyle healthFont;
}

//This can be made and accessed from any script without reference, doesn't matter that it's in this script file
//This is because it's both public and outside of the class definition above - it's after the last '}'
//We could have written this code inside any of our .cs files and it'd work just fine, but it makes sense to keep it here
[System.Serializable]
public struct FontStyle
{
    [SerializeField]
    public Font font;
    [SerializeField]
    public bool isBold;
    [SerializeField]
    public bool isItalic;
    [SerializeField]
    public int point;
}
