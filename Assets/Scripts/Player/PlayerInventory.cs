using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    private bool hasObject;
    public GameObject buttonSprite;

    private static PlayerInventory _instance;
    public static PlayerInventory Instance { get { return _instance; } }
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

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
    public void ShowButtonSprite(bool state)
    {
        buttonSprite.SetActive(state);
    }
}
