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
        DrawDefaultInspector();
        BaseEnemy t = (BaseEnemy)target;

        //Adding a button
        if (GUILayout.Button("Add Waypoint"))
        {
            //Adds a new waypoint using the values of the last waypoint as a start
            t.waypoints.Add(t.waypoints[t.waypoints.Count-1]);
        }
    }

    //This runs when the scene window updates and you can draw GUI elements into it.
    void OnSceneGUI()
    {
        BaseEnemy t = (BaseEnemy)target; // need to get the object whose inspector we're modifying and cast it

        //Get the list of waypoints
        //store a 'selected' waypoint

        Event e = Event.current;

        //if I click within range of a waypoint, it's not selected.
        //handle is positioned at the selected waypoint's position and the selected waypoint is updated to the handle's position.
        Vector3 handlePos = SceneView.currentDrawingSceneView.camera.ViewportToWorldPoint(t.waypoints[t.selectedWaypointIndex]);
        Handles.SphereHandleCap(0, handlePos, Quaternion.identity, 10, EventType.Ignore);

        for (int i = 0; i < t.waypoints.Count; i++)
        {
            if (e.type == EventType.MouseDown && e.button == 0)
            {
                Vector2 guiPoint = HandleUtility.WorldToGUIPoint(t.waypoints[i]);

                if (Vector2.Distance(guiPoint, e.mousePosition) < 10)
                {
                    t.selectedWaypointIndex = i;
                }
            }
        }
    }
}
