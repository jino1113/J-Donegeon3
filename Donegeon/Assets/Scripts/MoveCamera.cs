using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{

    public PlayerMove pm;
    public Animator animator;

    public ToolSwitch toolSwitch;

    public Transform cameraPosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        transform.position = cameraPosition.position;   
    }

}
