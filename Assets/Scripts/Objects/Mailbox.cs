
using UnityEngine;

public class Mailbox : MonoBehaviour
{
    public bool active;
    [SerializeField] SpriteRenderer mailboxSprite;
    [SerializeField] private Dissolve dissolvingSprite;

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
            dissolvingSprite.DissolveSprite();
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
