using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Stats))]
public class BaseEnemy : MonoBehaviour
{
    //Waypoints
    public List<Vector3> waypoints;
    public int selectedWaypointIndex;
    private Stats stats;

    //State Machine

	// Use this for initialization
	void Start ()
    {
		
	}

    public void Reset(Vector3 resetPosition)
    {
        //reset position
        transform.position = resetPosition;
        //reset stats;
        
    }

    // Update is called once per frame
    void Update ()
    {
		
	}

    private void OnDrawGizmosSelected()
    {
        //Draw Waypoints
        for(int i = 0; i < waypoints.Count; i++)
        {
            if(i != selectedWaypointIndex)
            {
                Gizmos.color = Color.red;
            }
            else
            {
                Gizmos.color = Color.green;
            }

            Gizmos.DrawWireSphere(waypoints[i], 0.5f);
            if(i >= 0 && i < waypoints.Count-1)
            {
                Gizmos.DrawLine(waypoints[i], waypoints[i + 1]);
            }
            else if(i == waypoints.Count-1)
            {
                Gizmos.DrawLine(waypoints[i], waypoints[0]);
            }
        }
    }
}
