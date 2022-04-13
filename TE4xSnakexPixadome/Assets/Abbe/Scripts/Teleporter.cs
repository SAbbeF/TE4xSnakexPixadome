using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    [SerializeField]
    private GameObject player;

    [SerializeField]
    private Transform destination;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SnakeHeadTag"))
        {
            Debug.Log("Triggered");
            player.transform.position = destination.transform.position;
            //StartCoroutine(TeleportPlayer());
        }
            
    }

    IEnumerator TeleportPlayer()
    {
        yield return new WaitForSeconds(1);
        player.transform.position = destination.position;
    }
}
