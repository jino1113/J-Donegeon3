using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;


public class ToolSwitch : MonoBehaviour
{
    [Header("Animator")]
    public int toolselect = 0;
    public Animator MovementAnimator;
    public Animator HammerAnimator;
    public Animator MopAnimator;
    [SerializeField] private List<GameObject> ToolsList;
    [SerializeField] private List<GameObject> ToolsPosList;
    [SerializeField] private GameObject ToolsDepot;

    [Header("Picking Object")]
    [SerializeField] private LayerMask PickupMask;

    [SerializeField] private Camera PlayerCam;
    [SerializeField] private Transform PickupTarget;

    [Space]
    [SerializeField] private float PickupRange;
    [SerializeField] private float m_CleaningRange;
    private Rigidbody CurrentObject;
    private GameObject go;

    [Header("Fixing Object")]
    public LayerMask EnvironmentFixingMask;
    public LayerMask BloodMask;
    public LayerMask WaterMask;

    [SerializeField] private ParticleSystem BloodParticleSystem;
    [SerializeField] private ParticleSystem WaterParticleSystem;
    [SerializeField] private GameObject ParticlePosGameObject;

    public float BloodStage;

    public Material MopMaterial_0;
    public Material MopMaterial_1;
    public Material MopMaterial_2;
    public Material MopMaterial_3;

    public GameObject MopGameObjectObject;

    void Start()
    {
        BloodParticleSystem.GetComponent<ParticleSystem>();
        WaterParticleSystem.GetComponent<ParticleSystem>();
        Selecttool();
        MovementAnimator = MovementAnimator.GetComponent<Animator>();
        HammerAnimator = HammerAnimator.GetComponent<Animator>();
        MopAnimator = MopAnimator.GetComponent<Animator>();
        MopGameObjectObject.GetComponent<MeshRenderer>().material = MopMaterial_0;

    }

    // Update is called once per frame
    void Update()
    {

        Debug.DrawRay(transform.position, (Vector3.forward) * PickupRange, Color.gray);

        //Tool wheel

        int lasttool = toolselect;

        Pick();

        if (Input.GetKey(KeyCode.Alpha1))
        {
            toolselect = 0;
            MovementAnimator.SetInteger("Tool", 0);
            HammerAnimator.SetInteger("Tool", 0);
            MopAnimator.SetInteger("Tool", 0);
            Selecttool();
        }
        else if (Input.GetKey(KeyCode.Alpha2))
        {
            toolselect = 1;
            MovementAnimator.SetInteger("Tool", 1);
            HammerAnimator.SetInteger("Tool", 1);
            MopAnimator.SetInteger("Tool", 1);
            Selecttool();
        }
        else if (Input.GetKey(KeyCode.Alpha3))
        {
            toolselect = 2;
            MovementAnimator.SetInteger("Tool", 2);
            HammerAnimator.SetInteger("Tool", 2);
            MopAnimator.SetInteger("Tool", 2);
            Selecttool();
        }

        //use tool

        if (Input.GetKeyDown(KeyCode.Mouse0) && HammerAnimator.GetInteger("Tool") == 1 || Input.GetKeyDown(KeyCode.Mouse0) && MopAnimator.GetInteger("Tool") == 2)
        {
            HammerAnimator.SetBool("UseTool", true);
            MopAnimator.SetBool("UseTool", true);
            Fix();
        }
        else
        {
            HammerAnimator.SetBool("UseTool", false);
            MopAnimator.SetBool("UseTool", false);
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

        blood_stain_stage();
    }

    public void Selecttool()
    {
        if (toolselect == 0)
        {
            ToolsList[0].transform.position = ToolsPosList[0].transform.position;

            ToolsList[1].transform.position = ToolsDepot.transform.position;
            ToolsList[2].transform.position = ToolsDepot.transform.position;
        }
        else if (toolselect == 1)
        {
            ToolsList[1].transform.position = ToolsPosList[1].transform.position;

            ToolsList[0].transform.position = ToolsDepot.transform.position;
            ToolsList[2].transform.position = ToolsDepot.transform.position;
        }
        else if (toolselect == 2)
        {
            ToolsList[2].transform.position = ToolsPosList[2].transform.position;

            ToolsList[0].transform.position = ToolsDepot.transform.position;
            ToolsList[1].transform.position = ToolsDepot.transform.position;
        }
    }

    public void Pick()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && MovementAnimator.GetInteger("Tool") == 0)
        {
            if (CurrentObject)
            {
                MovementAnimator.SetBool("UseTool", false);
                CurrentObject.freezeRotation = false;
                CurrentObject = null;
                return;
            }

            Ray CameraRay = PlayerCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
            if (Physics.Raycast(CameraRay, out RaycastHit HitInfo, PickupRange, PickupMask))
            {
                MovementAnimator.SetBool("UseTool", true);
                CurrentObject = HitInfo.rigidbody;
                CurrentObject.freezeRotation = true;
            }
            else
            {
                MovementAnimator.SetBool("UseTool", false);
                CurrentObject.freezeRotation = false;
                CurrentObject = null;
                return;
            }
        }

        if (MovementAnimator.GetInteger("Tool") != 0)
        {
            if (CurrentObject)
            {
                MovementAnimator.SetBool("UseTool", false);
                CurrentObject.freezeRotation = false;
                CurrentObject = null;
            }
        }
    }

    public void Fix()
    {

        if (Input.GetKeyDown(KeyCode.Mouse0) && MovementAnimator.GetInteger("Tool") == 1)
        {

            Ray CameraRay = PlayerCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
            if (Physics.Raycast(CameraRay, out RaycastHit HitInfo, m_CleaningRange, EnvironmentFixingMask))
            {
                go = HitInfo.transform.gameObject;
                go.gameObject.SetActive(false);

            }
        }

        if (Input.GetKeyDown(KeyCode.Mouse0) && MovementAnimator.GetInteger("Tool") == 2)
        {
            Ray cameraRay = PlayerCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));

            if (BloodStage is >= 0f and <= 2f)
            {
                if (Physics.Raycast(cameraRay,out RaycastHit hitInfoBloodHit, m_CleaningRange, BloodMask))
                {
                    
                    //Destroy blood stain on map
                    ++BloodStage;
                    go = hitInfoBloodHit.transform.gameObject;
                    Destroy(go);
                }
            }

            if (Physics.Raycast(cameraRay, out _, m_CleaningRange, WaterMask))
            {
                Instantiate(WaterParticleSystem, ParticlePosGameObject.transform.position,Quaternion.identity);
                //Reset blood stain
                BloodStage = 0f;
            }
            if (BloodStage != 0)
            {
                Instantiate(BloodParticleSystem, ParticlePosGameObject.transform.position,Quaternion.identity);
            }
            else
            {
                Instantiate(WaterParticleSystem, ParticlePosGameObject.transform.position, Quaternion.identity);
            }
        }
    }

    private void blood_stain_stage()
    {
        MopGameObjectObject.GetComponent<Renderer>().material = BloodStage switch
        {
            0f => MopMaterial_0,
            //If mop is already stain it will get more blood on it
            1f => MopMaterial_1,
            //If mop is already blooded it will get even more blood on it
            2f => MopMaterial_2,
            //If mop is fully blooded it will still be bloody
            3f => MopMaterial_3,
            _ => MopGameObjectObject.GetComponent<Renderer>().material
        };
    }

    IEnumerator Wait(float time)
    {
        yield return new WaitForSeconds(time);
    }


}
