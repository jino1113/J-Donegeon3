using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallFixingCheck : MonoBehaviour
{
    [SerializeField] private List<ParticleSystem> ps;
    [SerializeField] private GameObject ParticlePos;
    public List<GameObject> WallList;
    public float FixingProgress;


    void Update()
    {
        m_Fixing();
    }


    private void m_Fixing()
    {
        if (!WallList[0].activeSelf && FixingProgress == 0)
        {
            Instantiate(ps[0], ParticlePos.transform.position, Quaternion.identity);
            Instantiate(ps[1], ParticlePos.transform.position, Quaternion.identity);

            FixingProgress += 25;
            WallList[1].SetActive(true);
            WallList[0].SetActive(false);
        }
        if (!WallList[1].activeSelf && !WallList[0].activeSelf && FixingProgress == 25)
        {
            Instantiate(ps[0], ParticlePos.transform.position, Quaternion.identity);
            Instantiate(ps[1], ParticlePos.transform.position, Quaternion.identity);

            FixingProgress += 25;
            WallList[2].SetActive(true);
            WallList[1].SetActive(false);
        }
        if (!WallList[2].activeSelf && !WallList[1].activeSelf && !WallList[0].activeSelf && FixingProgress == 50)
        {
            Instantiate(ps[0], ParticlePos.transform.position, Quaternion.identity);
            Instantiate(ps[1], ParticlePos.transform.position, Quaternion.identity);

            FixingProgress += 25;
            WallList[3].SetActive(true);
            WallList[2].SetActive(false);
        }
        if (!WallList[3].activeSelf && !WallList[2].activeSelf && !WallList[1].activeSelf && !WallList[0].activeSelf && FixingProgress == 75)
        {
            Instantiate(ps[0], ParticlePos.transform.position, Quaternion.identity);
            Instantiate(ps[1], ParticlePos.transform.position, Quaternion.identity);

            FixingProgress += 25;
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
