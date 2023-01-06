using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{

    void Update()
    {
        transform.Rotate(new Vector3(0, 5, 0) * Time.deltaTime);

    }
}
