using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderDisplayGizmo : MonoBehaviour
{
    public Color wireColour;
    public Color fillColour;

    public bool isEnabled;
    BoxCollider col;

    void OnDrawGizmos()
    {
        if (isEnabled)
        {
            col = GetComponent<BoxCollider>();

            //opaque red
            Gizmos.color = wireColour;
            Gizmos.DrawWireCube(transform.position + col.center, col.size);
            
            //semi-transparent
            Gizmos.color = fillColour;
            Gizmos.DrawCube(transform.position + col.center, col.size);
        }
    }
}
