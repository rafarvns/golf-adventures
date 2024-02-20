using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMainCamera : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    
    void Start()
    {

    }

    
    void Update()
    {
        if (target)
        {
            transform.position = target.position + offset;
        }
    }
}
