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
                CurrentObject.useGravity = true;
                CurrentObject = null;
                return;
            }

            Ray CameraRay = PlayerCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
            if (Physics.Raycast(CameraRay, out RaycastHit HitInfo, PickupRange, PickupMask))
            {
                CurrentObject = HitInfo.rigidbody;
                CurrentObject.useGravity = false;
            }
        }

        if (animator.GetInteger("UsingTool") != 0)
        {
            if (CurrentObject)
            {
                CurrentObject.useGravity = true;
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
<<<<<<< HEAD

        if (Input.GetKeyDown(KeyCode.Mouse0) && animator.GetInteger("UsingTool") == 2)
        {
            Ray CameraRay = PlayerCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));

            if (BloodStage >= 0f && BloodStage <= 2f)
            {
                if (Physics.Raycast(CameraRay,out RaycastHit hitInfoBloodHit, PickupRange, BloodMask))
                {
                    //Destroy blood stain on map
                    ++BloodStage;
                    go = hitInfoBloodHit.transform.gameObject;
                    Destroy(go);
                }
            }
            else if (Physics.Raycast(CameraRay, out RaycastHit hit, PickupRange, WaterMask))
            {
                //Reset blood stain
                BloodStage = 0f;
            }
        }
    }

    void blood_stain_stage()
    {
        if (BloodStage == 0f)
        {
<<<<<<< HEAD
            0f => MopMaterial_0,
            //If mop is already stain it will get more blood on it
            1f => MopMaterial_1,
            //If mop is already blooded it will get even more blood on it
            2f => MopMaterial_2,
            //If mop is fully blooded it will still be bloody
            3f => MopMaterial_3,
            _ => MopGameObjectObject.GetComponent<Renderer>().material
        };
=======
>>>>>>> Art
=======
            MopGameObjectObject.GetComponent<Renderer>().material = MopMaterial_0;
        }
        //If mop is already stain it will get more blood on it
        else if (BloodStage == 1f)
        {
            MopGameObjectObject.GetComponent<Renderer>().material = MopMaterial_1;
        }
        //If mop is already blooded it will get even more blood on it
        else if (BloodStage == 2f)
        {
            MopGameObjectObject.GetComponent<Renderer>().material = MopMaterial_2;
        }
        //If mop is fully blooded it will still be bloody
        else if (BloodStage == 3f)
        {
            MopGameObjectObject.GetComponent<Renderer>().material = MopMaterial_3;
        }
>>>>>>> parent of 7287250 (Bug fixed)
    }

}
