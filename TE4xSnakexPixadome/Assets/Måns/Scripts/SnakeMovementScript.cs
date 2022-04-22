using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class SnakeMovementScript : MonoBehaviour
{
    public static SnakeMovementScript snakeInstance;



    [SerializeField] GameObject snakeHead;
    [SerializeField] GameObject snakeTailPrefab;
    [SerializeField] GameObject foodToSpawn;
    public List<GameObject> bodyparts;
    bool isOnCooldownBodyToFood;
    bool isOnCooldownTimeStop;
    int direction;
    int bodyPartsToFood;
    int bodyPartsToSacrifice;
    float coolDownReplaceBodyToFood;
    float coolDownTimeStop;
    float moveDistance;
    float moveTimer;
    float time;
    float timeSlowDuration;
    float timeSlowProgress;
    float coolDownTimeAbilityFood;
    float coolDownTimeTimeAbility;

    public SnakeMovementScript()
    {
        moveTimer = 0.2f;
        moveDistance = 10f;
        coolDownReplaceBodyToFood = 5f;
        coolDownTimeStop = 10f;
        bodyPartsToFood = 5;
        bodyPartsToSacrifice = 2;
        timeSlowDuration = 1.75f;

    }
    private void Awake()
    {
        CreateInstance();
    }

    void Start()
    {
        direction = 0;
        bodyparts = new List<GameObject>();
        bodyparts.Add(snakeHead);
        isOnCooldownBodyToFood = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (isOnCooldownBodyToFood == true)
        {
            coolDownTimeAbilityFood = coolDownTimeAbilityFood + Time.deltaTime;
            if (coolDownTimeAbilityFood >= coolDownReplaceBodyToFood)
            {
                isOnCooldownBodyToFood = false;
                coolDownTimeAbilityFood = 0;

            }

        }

        if (isOnCooldownTimeStop == true)
        {
            coolDownTimeTimeAbility = coolDownTimeTimeAbility + Time.deltaTime;
            if (coolDownTimeTimeAbility >= coolDownTimeStop)
            {
                isOnCooldownTimeStop = false;
                coolDownTimeTimeAbility = 0;

            }

        }

        if (Time.timeScale < 1f)
        {
            timeSlowProgress += Time.deltaTime;
            if (timeSlowProgress > timeSlowDuration)
            {

                Time.timeScale = 1f;
                timeSlowProgress = 0;
            }


        }

        #region inputs
        if (Input.GetKeyDown(KeyCode.W))
        {
            direction = 1;
            //RotateYPlus180();
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            direction = 2;
            //RotateYPlus90();
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            direction = 3;
            //Rotate0();
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            direction = 4;
            //RotateYMinus90();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isOnCooldownBodyToFood != true)
            {

                SnakeShorterner();
                isOnCooldownBodyToFood = true;
            }

        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (isOnCooldownTimeStop != true)
            {

                SnakeTimePowers();
                isOnCooldownTimeStop = true;
            }

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

    public void AddBodyPart()
    {


        GameObject snakeTail = Instantiate(this.snakeTailPrefab);
        snakeTail.transform.position = bodyparts[bodyparts.Count - 1].transform.position;

        bodyparts.Add(snakeTail);
    }

    public void RemoveBodyPart()
    {
        GameObject snakePartToRemove;
        snakePartToRemove = bodyparts[bodyparts.Count - 1];


        bodyparts.Remove(snakePartToRemove);
        Destroy(snakePartToRemove);
    }

    void CreateInstance()
    {
        if (snakeInstance == null)
            snakeInstance = this;
    }

    private void OnTriggerEnter(Collider other)
    //Collide with own body function
    {
        if (other.gameObject.tag == "BodyPart")
        {
            if (other.gameObject != bodyparts[1])
            {

                for (int i = 0; i < bodyparts.Count; i++)
                {
                    Destroy(bodyparts[i]);

                }

                bodyparts.Clear();
            }


        }

    }

    void SnakeShorterner()
    {



        if ((bodyparts.Count - 1) >= 15)
        {


            for (int i = 0; i < bodyPartsToFood; i++)
            {
                GameObject food = Instantiate(foodToSpawn);
                GameObject bodyPartToReplace = bodyparts[bodyparts.Count - 1];
                food.transform.position = bodyPartToReplace.transform.position;
                bodyparts.Remove(bodyPartToReplace);
                Destroy(bodyPartToReplace);


            }


        }


    }

    void SnakeTimePowers()
    {

        if ((bodyparts.Count - 1) >= 10)
        {
            for (int i = 0; i < bodyPartsToSacrifice; i++)
            {
                GameObject bodyPartToDestroy = bodyparts[bodyparts.Count - 1 ];
                bodyparts.Remove(bodyPartToDestroy);
                Destroy(bodyPartToDestroy);
            }
                Time.timeScale = Time.timeScale / 3;


        }



    }
}
