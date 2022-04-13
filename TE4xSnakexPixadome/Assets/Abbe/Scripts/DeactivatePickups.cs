using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivatePickups : MonoBehaviour
{
    void Start()
    {
        //Invoke("Deactivate", Random.Range(3f, 6f));
        Invoke("DestroyPickups", Random.Range(5f, 6f));
    }

    private void Deactivate()
    {
        gameObject.SetActive(false);
    }

    private void DestroyPickups()
    {
        Destroy(this.gameObject);
    }
}
