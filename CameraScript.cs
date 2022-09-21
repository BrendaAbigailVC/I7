using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform Cat;

    void Update()
    {
        if (Cat != null)
        {
            Vector3 position = transform.position;
            position.x = Cat.position.x;
            transform.position = position;
        }
    }
}
