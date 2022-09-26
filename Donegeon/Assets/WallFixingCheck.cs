using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallFixingCheck : MonoBehaviour
{
    public List<GameObject> WallList;
    public float Progress;

    // Update is called once per frame
    void Update()
    {
        m_Fixing();
    }


    private void m_Fixing()
    {
        if (!WallList[0].activeSelf && Progress == 0)
        {
            Progress += 25;
            WallList[1].SetActive(true);
            WallList[0].SetActive(false);
        }
        if (!WallList[1].activeSelf && !WallList[0].activeSelf && Progress == 25)
        {
            Progress += 25;
            WallList[2].SetActive(true);
            WallList[1].SetActive(false);
        }
        if (!WallList[2].activeSelf && !WallList[1].activeSelf && !WallList[0].activeSelf && Progress == 50)
        {
            Progress += 25;
            WallList[3].SetActive(true);
            WallList[2].SetActive(false);
        }
        if (!WallList[3].activeSelf && !WallList[2].activeSelf && !WallList[1].activeSelf && !WallList[0].activeSelf && Progress == 75)
        {
            Progress += 25;
            WallList[4].SetActive(true);
            WallList[3].SetActive(false);
        }
        if (WallList[4].activeSelf)
        {
            Destroy(WallList[0]);
            Destroy(WallList[1]);
            Destroy(WallList[2]);
            Destroy(WallList[3]);
        }
    }
}
