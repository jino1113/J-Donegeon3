using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;


public class PopUpWhenLook : MonoBehaviour
{
    [SerializeField] private Camera PlayerCam;
    [SerializeField] private Text TextObjectName;
    [SerializeField] private Slider ProgresSlider;

    [SerializeField] private float ProgressPoint;

    [SerializeField] private List<LayerMask> Mask;

    [SerializeField] private float Range;

    private float timeRemaining = 0.5f;
    private string CurrentObject;
    [SerializeField] private List<float> timer;

    void Start()
    {
        timer[0] = 0;
        timeRemaining = 0.15f;
    }

    void Update()
    {
        FixingProgressBar();
    }


    void QuestOnLook()
    {

    }

    void HightlightOnLook()
    {

    }


    void FixingProgressBar()
    {
        Ray CameraRay = PlayerCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));

        if (Physics.Raycast(CameraRay, out RaycastHit hitInfo, Range, Mask[0]))
        {
            CurrentObject = hitInfo.transform.gameObject.name;
            ProgressPoint = hitInfo.transform.parent.GetComponentInParent<WallFixingCheck>().FixingProgress;

            timeRemaining -= Time.deltaTime;
            if (timeRemaining <= 0)
            {
                ProgresSlider.gameObject.SetActive(true);
                timeRemaining = 0;
                TextObjectName.text = CurrentObject;
                ProgresSlider.value = ProgressPoint;
            }
        }
        else
        {
            ProgresSlider.gameObject.SetActive(false);
            timeRemaining = 0.15f;
            TextObjectName.text = " ";
        }


        //Look at fog gate more than 10 sec
        if (Physics.Raycast(CameraRay, out RaycastHit hit, Range, Mask[1]))
        {
            timer[0] += Time.deltaTime;
            if (timer[0] >= 10)
            {
                PointArrow.Instance.Triggers["Quest6"] = true;
            }
        }
        else
        {
            timer[0] = 0;
        }

        //Look at fountain more than 10 sec
        if (Physics.Raycast(CameraRay, out RaycastHit hitWater, Range, Mask[2]))
        {
            timer[1] += Time.deltaTime;
            if (timer[1] >= 10)
            {
                PointArrow.Instance.Triggers["Quest7"] = true;
            }
        }
        else
        {
            timer[1] = 0;
        }
        //Look at painting more than 10 sec
        if (Physics.Raycast(CameraRay, out RaycastHit hitP, Range, Mask[3]))
        {
            timer[2] += Time.deltaTime;
            if (timer[2] >= 10)
            {
                PointArrow.Instance.Triggers["Quest8"] = true;
            }
        }
        //Look TV
        if (Physics.Raycast(CameraRay, out RaycastHit hitTV, Range, Mask[4]))
        {
            timer[3] += Time.deltaTime;
            if (timer[3] >= 10)
            {
                PointArrow.Instance.Triggers["Quest34"] = true;
            }
        }
        else
        {
            timer[2] = 0;
        }

    }
}
