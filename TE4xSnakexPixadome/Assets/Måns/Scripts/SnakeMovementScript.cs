using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class SnakeMovementScript : MonoBehaviour
{
    [SerializeField] GameObject snakeHead;
    [SerializeField] GameObject snakeTailPrefab;
    List<GameObject> bodyparts;
    int direction;
    float moveDistance;
    float moveTimer;
    float time;
    
    public SnakeMovementScript()
    {
        moveTimer = 0.5f;
        moveDistance = 10f;
        
    }


    void Start()
    {
        direction = 0;
        bodyparts = new List<GameObject>();
        bodyparts.Add(snakeHead);
        AddBodyPart();
        AddBodyPart();
        AddBodyPart();

    }

    // Update is called once per frame
    void Update()
    {

        #region inputs
        if (Input.GetKey(KeyCode.W))
        {
            direction = 1;
            //RotateYPlus180();
        }

        if (Input.GetKey(KeyCode.A))
        {
            direction = 2;
            //RotateYPlus90();
        }

        if (Input.GetKey(KeyCode.S))
        {
            direction = 3;
            //Rotate0();
        }

        if (Input.GetKey(KeyCode.D))
        {
            direction = 4;
            //RotateYMinus90();
        }
        #endregion

        time = time + Time.deltaTime;
        if (time >= moveTimer)
        {
            for (int i = bodyparts.Count - 1; i > 0; i--)
            {
                bodyparts[i].transform.position = bodyparts[i - 1].transform.position;

            }
            switch (direction)
            {
                case 1:
                    MoveXMinus();
                    break;

                case 2:
                    MoveZMinus();
                    break;

                case 3:
                    MoveXPlus();
                    break;

                case 4:
                    MoveZPlus();
                    break;
                
                
                default:
                    break;
            }
            time = 0;

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
    void MoveZPlus()
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

    void Rotate0()
    {
        transform.Rotate(snakeHead.transform.rotation.x, 0, snakeHead.transform.rotation.z);

    }
    void RotateYPlus90()
    {
        transform.Rotate(snakeHead.transform.rotation.x, 90, snakeHead.transform.rotation.z);

    }

    void RotateYPlus180()
    {
        transform.Rotate(snakeHead.transform.rotation.x, 180, snakeHead.transform.rotation.z);

    }

    void RotateYMinus90()
    {
        transform.Rotate(snakeHead.transform.rotation.x, -90, snakeHead.transform.rotation.z);

    }

    #endregion

    void AddBodyPart()
    {

        
        GameObject snakeTail = Instantiate(snakeTailPrefab);
        snakeTail.transform.position = bodyparts[bodyparts.Count - 1].transform.position;

        bodyparts.Add(snakeTail);
    }

}
