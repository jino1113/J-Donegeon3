using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLitterBox : MonoBehaviour
{
    [SerializeField] private GameObject LitterBoxPrefabs;
    [SerializeField] private GameObject BoxSpawnPoint;

    public bool SpawnBox;

    public static SpawnLitterBox Instance;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    void Update()
    {
        SpawnBox = ToolSwitch.Instance.InteractBool;
        CheckClick();
    }

    void CheckClick()
    {
        if (SpawnBox == true)
        {
            Instantiate(LitterBoxPrefabs, BoxSpawnPoint.transform.position, Quaternion.identity);
        }
    }
}
