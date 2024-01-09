using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
 
public class ResetAllbinding : MonoBehaviour
{
    [SerializeField]
    private InputActionAsset inputActions;

    public void ResetAllBindings()
    {
        // Reset KeyBind
        foreach (InputActionMap map in inputActions.actionMaps) 
        {
            map.RemoveAllBindingOverrides();

        }
    }
}
