using UnityEngine;

public class FetchPoint : MonoBehaviour
{
    [SerializeField] GameObject player;
    PlayerInventory playerInventory;
    private void Start()
    {
        playerInventory = player.GetComponent<PlayerInventory>();
    }
    void OnTriggerStay2D(Collider2D col)
    {
        if(col.gameObject == player)
        {
            if (!playerInventory.HasObject())
            {
                playerInventory.ShowButtonSprite(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    playerInventory.SetObjectStatus(true);
                    playerInventory.ShowButtonSprite(false);
                    DeliveryController.Instance.SelectMailbox();
                }
            }
        }
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        if(col.gameObject == player)
        {
            playerInventory.ShowButtonSprite(false);
        }
    }
}
