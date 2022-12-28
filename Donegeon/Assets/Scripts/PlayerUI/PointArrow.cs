using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class PointArrow : MonoBehaviour, ISerializationCallbackReceiver
{
    public List<string> _keys = new List<string> {};
    public Dictionary<string, bool> Triggers = new Dictionary<string,bool>();

    [SerializeField] private GameObject CompassGameObject;

    [SerializeField] private List<Transform> CurrentLitterGameObject;
    [SerializeField] private List<Transform> CurrentBrokenWallGameObject;
    [SerializeField] private List<Transform> CurrentBloodGameObject;
    [SerializeField] private List<Transform> CurrentCandleGameObject;
    [SerializeField] private List<Transform> CurrentCandleHolderGameObject;

    [SerializeField] private Transform CurrentBellGameObject;


    [SerializeField] private GameObject[] PreHoldLitterGameObjects;
    [SerializeField] private GameObject[] PreHoldBrokenWallGameObjects;
    [SerializeField] private GameObject[] PreHoldBloodGameObjects;
    [SerializeField] private GameObject[] PreHoldCandleGameObject;
    [SerializeField] private GameObject[] PreHoldCandleHolderGameObject;

    [SerializeField] private GameObject PreHoldBellGameObject;


    public float NowScore;
    public int LitterCount,BrokenWallCount,BloodCount,CandleCount,CandleHolderCount;
    public static PointArrow Instance;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    public void OnBeforeSerialize()
    {
        _keys.Clear();

        foreach (var questTrigger in Triggers)
        {
            _keys.Add(questTrigger.ToString());
        }
    }

    public void OnAfterDeserialize()
    {
        Triggers = new Dictionary<string, bool>();
        for (int i = 0; i != _keys.Count; i++)
            _keys.Add(_keys[i]);
    }

    Transform GetClosestLitter(List<Transform> Litter)
    {
        Transform bestTarget = null;
        float closestDistanceSqr = Mathf.Infinity;
        Vector3 currentPosition = transform.position;

        foreach (Transform potentialTarget in Litter)
        {
            Vector3 directionToTarget = potentialTarget.position - currentPosition;
            float dSqrToTarget = directionToTarget.sqrMagnitude;
            if (dSqrToTarget < closestDistanceSqr)
            {
                closestDistanceSqr = dSqrToTarget;
                bestTarget = potentialTarget;
            }
        }

        return bestTarget;
    }

    void Start()
    {
        CompassGameObject.SetActive(true);
        Triggers.Add("Quest1",false);
        Triggers.Add("Quest2", false);
        Triggers.Add("Quest3", false);
        Triggers.Add("Quest4", false);
        Triggers.Add("Quest5", false);



        NowScore = 6f;
    }

    void Update()
    {
        PreHoldLitterGameObjects = GameObject.FindGameObjectsWithTag("Litter");
        PreHoldBrokenWallGameObjects = GameObject.FindGameObjectsWithTag("BrokenWall");
        PreHoldBloodGameObjects = GameObject.FindGameObjectsWithTag("Blood");
        PreHoldCandleGameObject = GameObject.FindGameObjectsWithTag("Candle");
        PreHoldCandleHolderGameObject = GameObject.FindGameObjectsWithTag("CandleHolder");
        PreHoldBellGameObject = GameObject.FindGameObjectWithTag("EnvironmentTool");


        AddToLitterPreHold();
        AddToBrokenWallPreHold();
        AddToBloodPreHold();
        AddToCandleHolderPreHold();
        AddToCurrentCandle();
        setBellPosition();


        CompassControll();
    }

    void CompassControll()
    {
        if (Triggers["Quest1"] == false)
        {
            transform.LookAt(GetClosestLitter(CurrentLitterGameObject));
        }
        else if (Triggers["Quest2"] == false && Triggers["Quest1"] == true)
        {
            transform.LookAt(GetClosestLitter(CurrentBrokenWallGameObject));
        }
        else if (Triggers["Quest3"] == false && Triggers["Quest2"] == true && Triggers["Quest1"] == true)
        {
            transform.LookAt(GetClosestLitter(CurrentBloodGameObject));
        }
        else if (Triggers["Quest4"] == false && Triggers["Quest3"] == true && Triggers["Quest2"] == true && Triggers["Quest1"] == true)
        {
            transform.LookAt(CurrentBellGameObject);
        }
        else if (Triggers["Quest5"] == false && Triggers["Quest4"] == true && Triggers["Quest3"] == true && Triggers["Quest2"] == true && Triggers["Quest1"] == true)
        {
            transform.LookAt(GetClosestLitter(CurrentCandleHolderGameObject));
        }
        else if (Triggers["Quest5"] == true && Triggers["Quest4"] == true && Triggers["Quest3"] == true && Triggers["Quest2"] == true && Triggers["Quest1"] == true)
        {
            CompassGameObject.SetActive(false);
        }
    }

    void AddToLitterPreHold()
    {
        if (CurrentLitterGameObject.Count < PreHoldLitterGameObjects.Length)
        {
            NowScore -= 1;
        }
        if (CurrentLitterGameObject.Count > PreHoldLitterGameObjects.Length)
        {
            NowScore += 1f;
            CurrentLitterGameObject.Clear();
            Triggers["Quest1"] = true;
        }

        LitterCount = 0;
        foreach (GameObject Item in PreHoldLitterGameObjects)
        {
            CurrentLitterGameObject.Add(Item.transform);
            if (LitterCount == CurrentLitterGameObject.Count)
            {
                break;
            }
            LitterCount++;
        }
        CurrentLitterGameObject = CurrentLitterGameObject.Distinct().ToList();
    }

    void AddToBrokenWallPreHold()
    {
        if (CurrentBrokenWallGameObject.Count > PreHoldBrokenWallGameObjects.Length)
        {
            NowScore += 1f;
            CurrentBrokenWallGameObject.Clear();
            Triggers["Quest2"] = true;
        }
        BrokenWallCount = 0;
        foreach (GameObject Item in PreHoldBrokenWallGameObjects)
        {
            CurrentBrokenWallGameObject.Add(Item.transform);
            if (BrokenWallCount == CurrentBrokenWallGameObject.Count)
            {
                break;
            }
            BrokenWallCount++;
        }
        CurrentBrokenWallGameObject = CurrentBrokenWallGameObject.Distinct().ToList();

    }
    void AddToBloodPreHold()
    {
        if (CurrentBloodGameObject.Count < PreHoldBloodGameObjects.Length)
        {
            NowScore -= 1f;
        }
        if (CurrentBloodGameObject.Count > PreHoldBloodGameObjects.Length)
        {
            NowScore += 1f;
            CurrentBloodGameObject.Clear();
            Triggers["Quest3"] = true;
        }

        BloodCount = 0;
        foreach (GameObject Item in PreHoldBloodGameObjects)
        {
            CurrentBloodGameObject.Add(Item.transform);
            if (BloodCount == CurrentBloodGameObject.Count)
            {
                break;
            }
            BloodCount++;
        }
        CurrentBloodGameObject = CurrentBloodGameObject.Distinct().ToList();
    }

    void AddToCandleHolderPreHold()
    {
        CandleHolderCount = 0;
        foreach (GameObject Item in PreHoldCandleHolderGameObject)
        {
            CurrentCandleHolderGameObject.Add(Item.transform);
            if (CandleHolderCount == CurrentCandleHolderGameObject.Count)
            {
                break;
            }
            CandleHolderCount++;
        }
        CurrentCandleHolderGameObject = CurrentCandleHolderGameObject.Distinct().ToList();
    }

    void AddToCurrentCandle()
    {
        if (CurrentCandleGameObject.Count < PreHoldCandleGameObject.Length)
        {
            NowScore += 1f;
            Triggers["Quest5"] = true;
        }

        CandleCount = 0;
        foreach (GameObject Item in PreHoldCandleGameObject)
        {
            CurrentCandleGameObject.Add(Item.transform);
            if (CandleCount == CurrentCandleGameObject.Count)
            {
                break;
            }
            CandleCount++;
        }
        CurrentCandleGameObject = CurrentCandleGameObject.Distinct().ToList();
    }

    void setBellPosition()
    {
        CurrentBellGameObject = PreHoldBellGameObject.transform;
    }
}
