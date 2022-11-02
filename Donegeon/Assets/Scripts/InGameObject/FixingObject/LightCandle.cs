using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightCandle : MonoBehaviour
{
    [SerializeField] private List<GameObject> LightGameObjects;
    public bool kindle;

    void Start()
    {
        foreach (var Item in LightGameObjects)
        {
            Item.SetActive(false);
        }
    }

    void Update()
    {
        CheckKindle();
    }

    private void CheckKindle()
    {
        if (kindle != true) return;
        foreach (var Item in LightGameObjects)
        {
            Item.SetActive(true);
        }
    }
}
