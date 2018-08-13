using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

//Custom Editor (typeof(Class)) is required here to tell the script what it's representing
[CustomEditor(typeof(UISkinObject))]
public class UISkinInspector : Editor //Derive from Editor base class
{
    UISkinObject t; //A reference of the type we're making an inspector for

    //Override the OnInspectorGUI method
    public override void OnInspectorGUI()
    {
        //We need to cast the 'target' which we get naturally to our actual class
        t = (UISkinObject)target;

        //You can add all sorts of interesting extra information to your inspectors and editors
        EditorGUILayout.HelpBox("This object serves as a design tool for plug and play UI skins", MessageType.Info);

        DrawDefaultInspector(); //The colour values are all good as they are, so we won't re-draw them

        //Draw custom image to preview colour selection
        //This is a whole other thing so don't worry about it too much here, but it's a common use case
        Texture2D displayTex = new Texture2D(100, 100);
        Color[] pix = new Color[100*100];
        Color[,] desPix = new Color[100,100];
        for(int i = 0; i < 100; i++)
        {
            for(int j = 0; j < 100; j++)
            {
                if((i < 25 || i > 75) || (j < 25 || j > 75))
                {
                    desPix[i, j] = t.backingColour;
                }
                else if(j < 50)
                {
                    desPix[i, j] = t.highHealthColour;
                }
                else if(j > 50)
                {
                    desPix[i, j] = t.lowHealthColour;
                }
                pix[i * 100 + j] = desPix[i, j];
            }
        }
        displayTex.SetPixels(pix);
        displayTex.Apply();


        //Back to editor things. This tells our inspector to listen for changes so it knows to save/undo stuff
        EditorGUI.BeginChangeCheck();

        //EditorGUILayout is the main bread and butter, it has a heap of layout methods and controls that it places
        //for us so we don't have to do any per pixel placement or anything
        EditorGUILayout.BeginVertical();

        //We can now access the values in our object and make controls to control their values
        
        //Make sure you're assigning the target to the outcome of the control, but also have the target's value as the value
        //inside the control.
        //If we don't do the former, our control won't do anything.
        //If we don't do the later, we won't know that it's done anything and we'll probably keep overriding our changes.
        t.healthFont.font = (Font)EditorGUILayout.ObjectField("Font Style", t.healthFont.font, typeof(Font), false);

        //All of these controls have a heap of possible overloads, the script reference and intellisence will be your friends
        t.healthFont.point = EditorGUILayout.IntSlider("Point Size", t.healthFont.point, 1, 20);

        EditorGUILayout.BeginHorizontal();
        //An advantage of redrawing even simple controls is that we can reposition them and change what we label them
        t.healthFont.isBold = EditorGUILayout.Toggle("Bold?", t.healthFont.isBold);
        t.healthFont.isItalic = EditorGUILayout.Toggle("Italic?", t.healthFont.isItalic);

        EditorGUILayout.EndHorizontal();
        EditorGUILayout.EndVertical();

        //End our change check and if anything changed, set it to 'dirty' which tells the editor to save it.
        //If we don't do this, the values won't be saved
        //If we used serialized properties instead we wouldn't need to do this, but that makes getting into our struct
        //super complicated
        if (EditorGUI.EndChangeCheck())
        {
            EditorUtility.SetDirty(t);
        }

        //Add some spaces before we draw our test content
        EditorGUILayout.Space();
        EditorGUILayout.Space();
        //You can add all sorts of interesting extra information to your inspectors and editors
        EditorGUILayout.HelpBox("Helper Examples", MessageType.None);

        EditorGUILayout.BeginHorizontal();
        
        //Draw in that custom texture
        //GetControlRect is a really handy way of getting where EditorGUILayout WOULD have drawn a field now.
        Rect DisplayPos = EditorGUILayout.GetControlRect();
        Rect drawPos = new Rect(DisplayPos.x, DisplayPos.y, 100, 100);
        EditorGUI.DrawPreviewTexture(drawPos, displayTex);

        //Set up a GUIStyle based on our font so we can display an example
        GUIStyle guiStyle = new GUIStyle();
        guiStyle.fontSize = t.healthFont.point;
        //This following code is a bit of a mess, it's just matching up the FontStyle enum unity has with our two bools
        UnityEngine.FontStyle style = new UnityEngine.FontStyle();
        if(t.healthFont.isBold)
        {
            if(t.healthFont.isItalic)
            {
                style = UnityEngine.FontStyle.BoldAndItalic;
            }
            else
            {
                style = UnityEngine.FontStyle.Bold;
            }
        }
        else if(t.healthFont.isItalic)
        {
            style = UnityEngine.FontStyle.Italic;
        }
        else
        {
            style = UnityEngine.FontStyle.Normal;
        }
        guiStyle.fontStyle = style;
        guiStyle.font = t.healthFont.font;

        //Draw the example text
        EditorGUILayout.LabelField("Test", guiStyle);

        EditorGUILayout.EndHorizontal();
    }
}
