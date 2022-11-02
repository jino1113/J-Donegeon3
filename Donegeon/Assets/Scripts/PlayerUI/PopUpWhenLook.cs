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

    [SerializeField] private LayerMask Mask;

    [SerializeField] private float Range;

    private float timeRemaining = 0.5f;
    private string CurrentObject;

    void Start()
    {
        timeRemaining = 0.15f;
    }

    void Update()
    {
        Ray CameraRay = PlayerCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));

        if (Physics.Raycast(CameraRay, out RaycastHit hitInfo, Range, Mask))
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
    }

}
