using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

//Handle selecting and moving the enemy waypoints
[CustomEditor(typeof(BaseEnemy),true)][CanEditMultipleObjects]
public class EnemyWaypointHandles : Editor
{
    //Our usual inspector override
    public override void OnInspectorGUI()
    {
        //DrawDefaultInspector();
        BaseEnemy t = (BaseEnemy)target;

        for (int i = 0; i < t.waypoints.Count; i++)
        {
            EditorGUILayout.BeginHorizontal();
            t.waypoints[i] = EditorGUILayout.Vector3Field(i.ToString(), t.waypoints[i]);
            if(GUILayout.Button("X"))
            {
                EditorApplication.Beep();
                if(EditorUtility.DisplayDialog("Delete Waypoint", "Are you sure you want to delete waypoint " + i.ToString() + "?", "Yes", "No"))
                {
                    Undo.RecordObject(t, "Remove Waypoint");
                    t.waypoints.RemoveAt(i);
                    EditorUtility.SetDirty(t);
                }
            }
            EditorGUILayout.EndHorizontal();
        }

        //Adding a button
        if (GUILayout.Button("Add Waypoint"))
        {
            //Adds a new waypoint using the values of the last waypoint as a start
            Undo.RecordObject(t, "Add Waypoint");
            t.waypoints.Add(t.waypoints[t.waypoints.Count-1]);
            EditorUtility.SetDirty(t);
        }
    }

    //This runs when the scene window updates and you can draw GUI elements into it.
    void OnSceneGUI()
    {
        BaseEnemy t = (BaseEnemy)target; // need to get the object whose inspector we're modifying and cast it

        //Uncommented: Simply draw a handle for all waypoints, that's it.
        //Commented: Draw a handle only for the selected waypoint and change selection by clicking.
        //If we add the control, we're locked onto the object, if we don't, it'll deselect when we click a new waypoint
        //Haven't found a solution for that yet.

        //Get the list of waypoints
        //store a 'selected' waypoint

        //Event e = Event.current;

        //int controlID = GUIUtility.GetControlID(FocusType.Passive);
        /*if(e.type == EventType.MouseDown &&
            e.button == 0 &&
            e.alt == false &&
            e.shift == false &&
            e.control == false)
        {*/

            //if I click within range of a waypoint, it's selected.
            //handle is positioned at the selected waypoint's position and the selected waypoint is updated to the handle's position.

            for (int i = 0; i < t.waypoints.Count; i++)
            {
                t.waypoints[i] = Handles.PositionHandle(t.waypoints[i], Quaternion.identity);

                /*Vector2 guiPoint = HandleUtility.WorldToGUIPoint(t.waypoints[i]);

                if (Vector2.Distance(guiPoint, e.mousePosition) < 10)
                {
                    t.selectedWaypointIndex = i;
                }*/
                
            }
        //}

        //t.waypoints[t.selectedWaypointIndex] = Handles.PositionHandle(t.waypoints[t.selectedWaypointIndex], Quaternion.identity);

        //HandleUtility.AddDefaultControl(controlID);
        //Repaint();
        //SceneView.RepaintAll();
    }
}
