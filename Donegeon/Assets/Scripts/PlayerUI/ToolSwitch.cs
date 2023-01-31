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
    public Animator TorchAnimator;
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
    [SerializeField] private LayerMask EnvironmentFixingMask;
    [SerializeField] private LayerMask BloodMask;
    [SerializeField] private LayerMask WaterMask;
    [SerializeField] private LayerMask CandleMask;

    [SerializeField] private ParticleSystem BloodParticleSystem;
    [SerializeField] private ParticleSystem WaterParticleSystem;
    [SerializeField] private GameObject ParticlePosGameObject;

    public float BloodStage;

    [SerializeField] private List<Material> MopMaterial_;

    public GameObject MopGameObjectObject;

    [Header("Interact Object")] 
    [SerializeField] private bool Cooldown;
    public bool InteractBool;
    [SerializeField] private LayerMask InteractableMask;
    [SerializeField] private LayerMask LeverLayerMask;


    public static ToolSwitch Instance;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }


    void Start()
    {
        Cooldown = true;
        BloodParticleSystem.GetComponent<ParticleSystem>();
        WaterParticleSystem.GetComponent<ParticleSystem>();
        Selecttool();
        MovementAnimator = MovementAnimator.GetComponent<Animator>();
        HammerAnimator = HammerAnimator.GetComponent<Animator>();
        MopAnimator = MopAnimator.GetComponent<Animator>();
        MopGameObjectObject.GetComponent<MeshRenderer>().material = MopMaterial_[0];

    }

    void Update()
    {
        //Tool wheel
        int lasttool = toolselect;
        InteractBool = false;


        if (Cooldown == true)
        {
            Tool0Action();
            ChangeNUse();
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

    public void ChangeNUse()
    {
        if (Input.GetKey(KeyCode.Alpha1))
        {
            toolselect = 0;
            MovementAnimator.SetInteger("Tool", 0);
            HammerAnimator.SetInteger("Tool", 0);
            MopAnimator.SetInteger("Tool", 0);
            TorchAnimator.SetInteger("Tool", 0);
            Selecttool();
        }
        else if (Input.GetKey(KeyCode.Alpha2))
        {
            toolselect = 1;
            MovementAnimator.SetInteger("Tool", 1);
            HammerAnimator.SetInteger("Tool", 1);
            MopAnimator.SetInteger("Tool", 1);
            TorchAnimator.SetInteger("Tool", 1);
            Selecttool();
        }
        else if (Input.GetKey(KeyCode.Alpha3))
        {
            toolselect = 2;
            MovementAnimator.SetInteger("Tool", 2);
            HammerAnimator.SetInteger("Tool", 2);
            MopAnimator.SetInteger("Tool", 2);
            TorchAnimator.SetInteger("Tool", 2);
            Selecttool();
        }
        else if (Input.GetKey(KeyCode.Alpha4))
        {
            toolselect = 3;
            MovementAnimator.SetInteger("Tool", 3);
            HammerAnimator.SetInteger("Tool", 3);
            MopAnimator.SetInteger("Tool", 3);
            TorchAnimator.SetInteger("Tool", 3);
            Selecttool();
        }

        //use tool

        if (Input.GetKeyDown(KeyCode.Mouse0) && HammerAnimator.GetInteger("Tool") == 1 
            || Input.GetKeyDown(KeyCode.Mouse0) && MopAnimator.GetInteger("Tool") == 2 
            || Input.GetKeyDown(KeyCode.Mouse0) && TorchAnimator.GetInteger("Tool") == 3)
        {
            HammerAnimator.SetBool("UseTool", true);
            MopAnimator.SetBool("UseTool", true);
            TorchAnimator.SetBool("UseTool", true);
            Fix();
        }
        else
        {
            HammerAnimator.SetBool("UseTool", false);
            MopAnimator.SetBool("UseTool", false);
            TorchAnimator.SetBool("UseTool", false);
        }
    }


    public void Selecttool()
    {
        if (toolselect == 0)
        {
            ToolsList[0].transform.position = ToolsPosList[0].transform.position;

            ToolsList[1].transform.position = ToolsDepot.transform.position;
            ToolsList[2].transform.position = ToolsDepot.transform.position;
            ToolsList[3].transform.position = ToolsDepot.transform.position;

        }
        else if (toolselect == 1)
        {
            ToolsList[1].transform.position = ToolsPosList[1].transform.position;

            ToolsList[0].transform.position = ToolsDepot.transform.position;
            ToolsList[2].transform.position = ToolsDepot.transform.position;
            ToolsList[3].transform.position = ToolsDepot.transform.position;

        }
        else if (toolselect == 2)
        {
            ToolsList[2].transform.position = ToolsPosList[2].transform.position;

            ToolsList[0].transform.position = ToolsDepot.transform.position;
            ToolsList[1].transform.position = ToolsDepot.transform.position;
            ToolsList[3].transform.position = ToolsDepot.transform.position;

        }
        else if (toolselect == 3)
        {
            ToolsList[3].transform.position = ToolsPosList[3].transform.position;

            ToolsList[0].transform.position = ToolsDepot.transform.position;
            ToolsList[1].transform.position = ToolsDepot.transform.position;
            ToolsList[2].transform.position = ToolsDepot.transform.position;
        }
    }

    void Tool0Action()
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
            else if (Physics.Raycast(CameraRay, out RaycastHit _, PickupRange, InteractableMask))
            {
                Cooldown = false;
                InteractBool = true;
                StartCoroutine(AnimationCooldown(3f));
            }
            else if (Physics.Raycast(CameraRay, out RaycastHit Hit, PickupRange, LeverLayerMask))
            {
                DisablerGameobject disablerGameobject;
                disablerGameobject = Hit.transform.gameObject.GetComponent<DisablerGameobject>();

                disablerGameobject.kindle = !disablerGameobject.kindle;
            }
            else
            {
                MovementAnimator.SetBool("UseTool", false);
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

    void Fix()
    {

        if (Input.GetKeyDown(KeyCode.Mouse0) && MovementAnimator.GetInteger("Tool") == 1)
        {

            Ray CameraRay = PlayerCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
            if (Physics.Raycast(CameraRay, out RaycastHit HitInfo, m_CleaningRange, EnvironmentFixingMask))
            {
                Cooldown = false;
                StartCoroutine(AnimationCooldown(0.75f));
                go = HitInfo.transform.gameObject;
                go.gameObject.SetActive(false);

            }
        }

        if (Input.GetKeyDown(KeyCode.Mouse0) && MovementAnimator.GetInteger("Tool") == 2)
        {
            Ray cameraRay = PlayerCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));

            if (BloodStage is >= 0f and <= 7f)
            {
                if (Physics.Raycast(cameraRay,out RaycastHit hitInfoBloodHit, m_CleaningRange, BloodMask))
                {
                    StartCoroutine(AnimationCooldown(0.75f));
                    //Destroy blood stain on map
                    ++BloodStage;
                    go = hitInfoBloodHit.transform.gameObject;
                    Destroy(go);
                }
            }

            if (Physics.Raycast(cameraRay, out _, m_CleaningRange, WaterMask))
            {
                Cooldown = false;
                StartCoroutine(AnimationCooldown(0.75f));
                Instantiate(WaterParticleSystem, ParticlePosGameObject.transform.position,Quaternion.identity);
                //Reset blood stain
                BloodStage = 0f;
            }
            if (BloodStage != 0)
            {
                Cooldown = false;
                StartCoroutine(AnimationCooldown(0.75f));
                Instantiate(BloodParticleSystem, ParticlePosGameObject.transform.position,Quaternion.identity);
            }
            else
            {
                Cooldown = false;
                StartCoroutine(AnimationCooldown(0.75f));
                Instantiate(WaterParticleSystem, ParticlePosGameObject.transform.position, Quaternion.identity);
            }
        }

        if (Input.GetKeyDown(KeyCode.Mouse0) && MovementAnimator.GetInteger("Tool") == 3)
        {
            Ray cameraRay = PlayerCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
            if (Physics.Raycast(cameraRay, out RaycastHit hit, m_CleaningRange, CandleMask))
            {
                hit.transform.gameObject.GetComponent<DisablerGameobject>().kindle = true;
            }
        }
    }

    private void blood_stain_stage()
    {
        MopGameObjectObject.GetComponent<Renderer>().material = BloodStage switch
        {
            0f => MopMaterial_[0],
            //If mop is already stain it will get more blood on it
            1f => MopMaterial_[1],
            //If mop is already blooded it will get even more blood on it
            2f => MopMaterial_[2],
            //If mop is fully blooded it will still be bloody
            3f => MopMaterial_[3],
            4f => MopMaterial_[4],
            5f => MopMaterial_[5],
            6f => MopMaterial_[6],
            7f => MopMaterial_[7],


            _ => MopGameObjectObject.GetComponent<Renderer>().material
        };
    }

    IEnumerator AnimationCooldown(float time)
    {
        yield return new WaitForSeconds(time);
        Cooldown = true;
    }


}
