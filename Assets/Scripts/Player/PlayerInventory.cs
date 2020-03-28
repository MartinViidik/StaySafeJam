using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    private bool hasObject;
    public GameObject interactableObject;
    public GameObject buttonSprite;
    public bool lastMail;

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

    public void SetCanInteract(bool state)
    {
        ShowButtonSprite(state);
    }

    private void Update()
    {
        if(interactableObject != null && Input.GetKeyDown(KeyCode.E))
        {
            if (interactableObject.CompareTag("FetchPoint"))
            {
                SetObjectStatus(true);
                ShowButtonSprite(false);
                DeliveryController.Instance.SelectMailbox();
                interactableObject = null;
            }
            if (interactableObject.tag == "Mailbox")
            {
                interactableObject.GetComponent<Mailbox>().StartCoroutine("DissolveCutscene");
                SetObjectStatus(false);
                ShowButtonSprite(false);
                interactableObject.GetComponent<Mailbox>().SetStatus(false);
                PlayerInventory.Instance.ShowButtonSprite(false);
                interactableObject = null;
            }
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
