using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
 
public class ResetAllbinding : MonoBehaviour
{
    [SerializeField]
    private List<InputActionAsset> inputActions;

    public void ResetAllBindings()
    {
        // Reset KeyBind
        foreach (InputActionMap map in inputActions[0].actionMaps) 
        {
            map.RemoveAllBindingOverrides();

        }
    }
}
