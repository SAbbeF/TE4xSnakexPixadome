using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMovement : MonoBehaviour
{
    private bool isMoving;

    private Vector3 originalPosition;
    private Vector3 targetPosition;

    private float timeToMove;

    GridMovement()
    {
        timeToMove = 0.1f;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.W) && !isMoving)
        {
            StartCoroutine(MoveSnake(new Vector3(0, 0, 1)));
        }

        if (Input.GetKey(KeyCode.S) && !isMoving)
        {
            StartCoroutine(MoveSnake(new Vector3(0, 0, -1)));
        }

        if (Input.GetKey(KeyCode.A) && !isMoving)
        {
            StartCoroutine(MoveSnake(new Vector3(-1, 0, 0)));
        }

        if (Input.GetKey(KeyCode.D) && !isMoving)
        {
            StartCoroutine(MoveSnake(new Vector3(1, 0, 0)));
        }
    }

    private IEnumerator MoveSnake(Vector3 direction)
    {
        isMoving = true;

        float elapsedTime = 0;

        originalPosition = transform.position;
        targetPosition = originalPosition + direction;

        while (elapsedTime < timeToMove)
        {
            transform.position = Vector3.Lerp(originalPosition, targetPosition, (elapsedTime / timeToMove));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPosition;

        isMoving = false;
    }
}
