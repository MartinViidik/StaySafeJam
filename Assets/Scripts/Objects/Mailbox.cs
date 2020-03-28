﻿
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mailbox : MonoBehaviour
{
    public bool active;
    [SerializeField] SpriteRenderer mailboxSprite;
    [SerializeField] private RuinedHouse dissolvingSprite;
    public GameObject connectedBuilding;

    private void Awake()
    {
        active = false;
    }
    
    void OnTriggerEnter2D(Collider2D col)
    {
        if (active)
        {
            if (col.gameObject.CompareTag("Player"))
            {
                PlayerInventory.Instance.interactableObject = gameObject;
                PlayerInventory.Instance.ShowButtonSprite(true);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            PlayerInventory.Instance.interactableObject = null;
            PlayerInventory.Instance.ShowButtonSprite(false);
        }
    }
    public void Dissolve()
    {
        if (dissolvingSprite != null)
            dissolvingSprite.Dissolve();
    }

    public IEnumerator DissolveCutscene()
    {
        Debug.Log("test");
        CameraController.Instance.SwitchTarget(connectedBuilding);
        yield return new WaitForSeconds(1.25f);
        Dissolve();
    }

    public void SetMailboxColor(Color newColor)
    {
        mailboxSprite.color = newColor;
    }
    public void SetStatus(bool newStatus)
    {
        active = newStatus;
        if (active)
        {
            SetMailboxColor(Color.red);
        } else
        {
            SetMailboxColor(Color.white);
        }
    }
    
}
