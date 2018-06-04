using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    //on trigger, cast the colliding gameobject to IFlamable
    //Fire their 'take damage'
    private void OnTriggerEnter(Collider other)
    {
        //We need to see if the thing we collided with has IFlamable
        IFlamable flamable = other.GetComponent<IFlamable>();
        if (flamable != null) //If the above cast fails, it'll be null
        {
            //We know that anything that implements IFlamable can run TakeFireDamage();
            flamable.TakeFireDamage();
        }
    }
}
