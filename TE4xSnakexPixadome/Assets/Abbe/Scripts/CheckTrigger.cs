using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckTrigger : MonoBehaviour
{
    public bool Triggered 
    {   
        get
        {
            return triggered;
        } 

        set
        {
            triggered = value;
        }
    }

    private bool triggered;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bomb") || other.CompareTag("Fruit"))
        {
            triggered = true;
            Debug.Log("Triggerss");
            //Destroy(gameObject);
        }
        else
        {
            triggered = false;
            //Destroy(gameObject);
        }
    }

}
