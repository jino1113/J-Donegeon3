using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolSwitch : MonoBehaviour
{

    public int toolselect = 0;
    public Animator animator;

    [Header("Picking Object")]

    [SerializeField] private LayerMask PickupMask;
    [SerializeField] private LayerMask EnvironmentFixingMask;

    [SerializeField] private Camera PlayerCam;
    [SerializeField] private Transform PickupTarget;
    [Space]
    [SerializeField] private float PickupRange;
    private Rigidbody CurrentObject;
    private GameObject go;

    // Start is called before the first frame update
    void Start()
    {
        selecttool();
        animator = animator.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Tool wheel

        int lasttool = toolselect;

        Pick();

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            toolselect = 0;
            animator.SetInteger("UsingTool", 0);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            toolselect = 1;
            animator.SetInteger("UsingTool", 1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            toolselect = 2;
            animator.SetInteger("UsingTool", 2);
        }

        if (lasttool != toolselect)
        {
            animator.SetTrigger("Tool");
            selecttool();
        }

        //use hammer tool

        if (Input.GetKey(KeyCode.Mouse0) && animator.GetInteger("UsingTool") == 1)
        {
            animator.SetBool("UseTool", true);
            Fix();
        }
        else
        {
            animator.SetBool("UseTool", false);
        }
    }

    void FixedUpdate()
    {
        if (CurrentObject)
        {
            Vector3 DirectionToPoint = PickupTarget.position - CurrentObject.position;
            float DistanceToPoint = DirectionToPoint.magnitude;

            CurrentObject.velocity = DirectionToPoint * 12f * DistanceToPoint;
        }
    }

    public void selecttool()
    {
        int i = 0;
        foreach (Transform tools in transform)
        {
            if(i == toolselect)
            {
                tools.gameObject.SetActive(true);
            }
            else
            {
                tools.gameObject.SetActive(false);
            }
            i++;
        }


    }

    public void Pick()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && animator.GetInteger("UsingTool") == 0)
        {
            if (CurrentObject)
            {
                CurrentObject.freezeRotation = false;
                CurrentObject = null;
                return;
            }

            Ray CameraRay = PlayerCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
            if (Physics.Raycast(CameraRay, out RaycastHit HitInfo, PickupRange, PickupMask))
            {
                CurrentObject = HitInfo.rigidbody;
                CurrentObject.freezeRotation = true;
            }
        }

        if (animator.GetInteger("UsingTool") != 0)
        {
            if (CurrentObject)
            {
                CurrentObject.freezeRotation = false;
                CurrentObject = null;
                return;

            }
        }
    }

    public void Fix()
    {

        if (Input.GetKeyDown(KeyCode.Mouse0) && animator.GetInteger("UsingTool") == 1)
        {

            Ray CameraRay = PlayerCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
            if (Physics.Raycast(CameraRay, out RaycastHit HitInfo, PickupRange, EnvironmentFixingMask))
            {
                go = HitInfo.transform.gameObject;
                go.gameObject.SetActive(false);

            }
        }
    }

}
