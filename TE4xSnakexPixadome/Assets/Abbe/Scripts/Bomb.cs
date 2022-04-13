using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SnakeHeadTag"))
        {
            SnakeMovementScript.snakeInstance.RemoveBodyPart();
            Destroy(this.gameObject);
        }
    }
}
