using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class SnakeMovementScript : MonoBehaviour
{
    [SerializeField] GameObject snakeHead;
    int direction;
    Vector3 oldPosition;
    float moveDistance;
    float moveTimer;
    float RotationDegree;
    float time;
    
    public SnakeMovementScript()
    {
        moveTimer = 1f;
        moveDistance = 10f;
        RotationDegree = 90f;
        
    }


    void Start()
    {
        direction = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        time = time + Time.deltaTime;
        if (time >= moveTimer)
        {

            RotateYMinus();
            time = 0f;
        }

    }

    #region movement
    void MoveXPlus()
    {
        snakeHead.transform.position = new Vector3
            (snakeHead.transform.position.x + moveDistance, snakeHead.transform.position.y, snakeHead.transform.position.z);


    }
    void MoveXMinus()
    {
        snakeHead.transform.position = new Vector3
           (snakeHead.transform.position.x - moveDistance, snakeHead.transform.position.y, snakeHead.transform.position.z);


    }
    void MoveZplus()
    {
        snakeHead.transform.position = new Vector3
           (snakeHead.transform.position.x, snakeHead.transform.position.y, snakeHead.transform.position.z + moveDistance);


    }
    void MoveZMinus()
    {
        snakeHead.transform.position = new Vector3
           (snakeHead.transform.position.x, snakeHead.transform.position.y, snakeHead.transform.position.z - moveDistance);

    }
    #endregion

    #region Rotation

    void RotateYPlus()
    {
        transform.Rotate(snakeHead.transform.rotation.x, snakeHead.transform.rotation.y + RotationDegree, snakeHead.transform.rotation.z);

    }
    void RotateYMinus()
    {
        transform.Rotate(snakeHead.transform.rotation.x, snakeHead.transform.rotation.y - RotationDegree, snakeHead.transform.rotation.z);

    }

    #endregion

}
