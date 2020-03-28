
using UnityEngine;

public class Mailbox : MonoBehaviour
{
    public bool active;
    [SerializeField] SpriteRenderer mailboxSprite;

    private void Awake()
    {
        active = false;
    }
    void OnTriggerStay2D(Collider2D col)
    {
        if (active)
        {
            if (col.gameObject.tag == "Player")
            {
                PlayerInventory.Instance.ShowButtonSprite(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    SetStatus(false);
                    PlayerInventory.Instance.SetObjectStatus(false);
                    PlayerInventory.Instance.ShowButtonSprite(false);

                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            col.gameObject.GetComponent<PlayerInventory>().ShowButtonSprite(false);
        }
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
