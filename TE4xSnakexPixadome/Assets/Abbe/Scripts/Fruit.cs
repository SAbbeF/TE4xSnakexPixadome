using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SnakeHeadTag"))
        {
            Destroy(this.gameObject);
            Game.gameInstance.IncreaseScore();
            SnakeMovementScript.snakeInstance.AddBodyPart();
        }
    }

} 
