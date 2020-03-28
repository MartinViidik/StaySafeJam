using System.Collections.Generic;
using UnityEngine;

public class DeliveryController : MonoBehaviour
{
    private static DeliveryController _instance;
    public static DeliveryController Instance { get { return _instance; } }

    public List<Delivery> deliveries = new List<Delivery>();
    public List<Mailbox> mailboxes = new List<Mailbox>();

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

    public Mailbox GetRandomMailbox()
    {
        int i = Random.Range(0, mailboxes.Count);
        return mailboxes[i];
    }

    public Delivery GetRandomDelivery()
    {
        int i = Random.Range(0, deliveries.Count);
        return deliveries[i];
    }
    public void SelectMailbox()
    {
        SetUI();
        Mailbox mailbox = GetRandomMailbox().GetComponent<Mailbox>();
        mailboxes.Remove(mailbox);
        mailbox.SetStatus(true);
    }
    public void SetUI()
    {
        Delivery delivery = GetRandomDelivery();
        deliveries.Remove(delivery);
        ItemPickupUI.Instance.UpdatePickupUI(delivery.title, delivery.content, delivery.image);
    }
}
