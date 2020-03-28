using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryController : MonoBehaviour
{
    private static DeliveryController _instance;
    public static DeliveryController Instance { get { return _instance; } }

    public Mailbox[] mailboxes;

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
        int i = Random.Range(0, mailboxes.Length);
        return mailboxes[i];
    }
    public void SelectMailbox()
    {
        GetRandomMailbox().GetComponent<Mailbox>().SetStatus(true);
    }
}
