
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mailbox : MonoBehaviour
{
    public bool active;
    [SerializeField] SpriteRenderer mailboxSprite;
    [SerializeField] private RuinedHouse dissolvingSprite;
    public GameObject connectedBuilding;
    private GameObject player;

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
                player = col.gameObject;
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
        if (PlayerInventory.Instance.lastMail)
        {
            FadeImage.Instance.FadeEnding();
        }
    }

    public IEnumerator DissolveCutscene()
    {
        player.GetComponent<LightLevel>().active = false;
        GuideArrow.Instance.SetArrowState(false);
        CameraController.Instance.SwitchTarget(connectedBuilding);
        player.GetComponent<PlayerMovement>().SetMovementEnabled(false);
        yield return new WaitForSeconds(1.25f);
        Dissolve();
        if (PlayerInventory.Instance.lastMail)
        {
            yield return new WaitForSeconds(3.5f);
            FadeImage.Instance.FadeEnding();
        }
        RainController.Instance.ReduceRainLevel();
        yield return new WaitForSeconds(2.25f);
        player.GetComponent<LightLevel>().active = true;
        player.GetComponent<LightLevel>().inLight = true;
        PlayerMovement.Instance.SetMovementEnabled(enabled);
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
