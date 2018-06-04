using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

//[CustomEditor(typeof(VertColourable))]
public class VertexColourPainter : Editor
{ 
    Color paintColour;

    List<Vector3> verts;
    List<Color> vertCol;

    //VertColourable t;

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        //Editor UI 
        EditorGUILayout.BeginHorizontal();
        if (GUILayout.Button("R"))
        {
            paintColour = Color.red;
        }
        if (GUILayout.Button("G"))
        {
            paintColour = Color.green;
        }
        if (GUILayout.Button("B"))
        {
            paintColour = Color.blue;
        }
        EditorGUILayout.EndHorizontal();

        paintColour = EditorGUILayout.ColorField(paintColour);
    }

    void OnSceneGUI()
    {
        //t = (VertColourable)target;

        //verts = new List<Vector3>();
        //vertCol = new List<Color>();

        /*for (int i = 0; i < t.m.vertices.Length; i++)
        {
            verts.Add(t.m.vertices[i] + t.transform.position);
            vertCol.Add(t.m.colors[i]);
        }*/

        Event e = Event.current;

        //new Vector2(0, layout.marker.height)
        //EditorGUI.DrawRect(new Rect(Event.current.mousePosition, new Vector2(100, 100)), paintColour);
        Vector3 handlePos = SceneView.currentDrawingSceneView.camera.ViewportToWorldPoint(e.mousePosition);
        Handles.SphereHandleCap(0, handlePos, Quaternion.identity, 10, EventType.Ignore);

        //Cursor.SetCursor(layout.marker, Vector2.zero, CursorMode.Auto);

        if (e.type == EventType.KeyDown)
        {
            if (e.keyCode == KeyCode.G)
            {
                paintColour = Color.red;
            }
            if (e.keyCode == KeyCode.H)
            {
                paintColour = Color.green;
            }
            if (e.keyCode == KeyCode.J)
            {
                paintColour = Color.blue;
            }
        }

        /*for (int i = 0; i < t.verts.Count; i++)
        {
            if (e.type == EventType.MouseDown && e.button == 0)
            {
                Vector2 guiPoint = HandleUtility.WorldToGUIPoint(t.verts[i]);

                if (Vector2.Distance(guiPoint, e.mousePosition) < 10)
                {
                    t.vertCol[i] = paintColour;
                    t.m.SetColors(t.vertCol);
                }
            }
        }*/
    }
}
