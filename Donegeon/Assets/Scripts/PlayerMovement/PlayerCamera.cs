using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    // Start is called before the first frame update
    public float sensX;
    public float sensY;

    public Transform Orientation;

    float RotateX;
    float RotateY;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }

    // Update is called once per frame
    void Update()
    {
        //mouse input
        float mouseX = Input.GetAxisRaw("Mouse X") * sensX * Time.deltaTime;
        float mouseY = Input.GetAxisRaw("Mouse Y") * sensY * Time.deltaTime;

        RotateX -= mouseY;
        RotateX = Mathf.Clamp(RotateX, -90f, 90f);

        RotateY += mouseX;

        //Rotate
        transform.rotation = Quaternion.Euler(RotateX, RotateY, 0);
        Orientation.rotation = Quaternion.Euler(0, RotateY, 0);
    }
}
