using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

//Property Drawer overwrites how 'data packet' is displayed
[CustomPropertyDrawer (typeof(DataPacket))]
public class DataPackerDrawer : PropertyDrawer
{
    //This override provides us with these values to begin with
    //The position this is being drawn at in the inspector, and the property it's representing are most important.
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        //We can pull the variables on that property to redraw
        SerializedProperty name = property.FindPropertyRelative("name");
        SerializedProperty health = property.FindPropertyRelative("health");
        SerializedProperty mana = property.FindPropertyRelative("mana");
        SerializedProperty armour = property.FindPropertyRelative("armour");

        //We can't use layout calls anymore! 
        //We have to manually place elements by pixel position (we used to need to do all GUI stuff this way)
        EditorGUI.PropertyField(new Rect(position.x, position.y, position.width, position.height), name);
        //EditorGUILayout.PropertyField(health);
        //EditorGUILayout.PropertyField(mana);
        //EditorGUILayout.PropertyField(armour);
    }
}
