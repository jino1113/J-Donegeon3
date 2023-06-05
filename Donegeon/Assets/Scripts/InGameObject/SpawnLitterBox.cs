using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLitterBox : MonoBehaviour
{
    [SerializeField] private GameObject LitterBoxPrefabs;
    [SerializeField] private GameObject BoxSpawnPoint;
    [SerializeField] private Animator BellAnimator;

    public bool SpawnBox;

    void Update()
    {
        SpawnBox = ToolSwitch.Instance.InteractBool;
        BellAnimator.SetBool("Ringing", false);
        CheckClick();
    }

    void CheckClick()
    {
        if (SpawnBox == true)
        {
            BellAnimator.SetBool("Ringing",true);
            Instantiate(LitterBoxPrefabs, BoxSpawnPoint.transform.position, Quaternion.identity);
        }
    }
}
