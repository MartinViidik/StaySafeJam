using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    private bool hasObject;

    private void Start()
    {
        hasObject = false;
    }

    public void SetObjectStatus(bool status)
    {
        hasObject = status;
        Debug.Log(hasObject);
    }

    public bool HasObject()
    {
        if (hasObject)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
