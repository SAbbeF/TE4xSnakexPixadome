using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public bool visited;
    public bool[] status;

    public Platform()
    {
        visited = false;
        status = new bool[4];
    }
}
