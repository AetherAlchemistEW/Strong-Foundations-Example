using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour, IFlamable
{
    private Stats stats;
	// Use this for initialization
	void Start ()
    {
        stats = GetComponent<Stats>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    void Attack(float distanceToTarget, GameObject target)
    {
        //Ranged attack
    }

    void Attack(GameObject target)
    {
        //Melee attack
    }

    public void TakeFireDamage()
    {

    }
}
