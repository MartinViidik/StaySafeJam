using UnityEngine;

public class FetchPoint : MonoBehaviour
{
    [SerializeField] GameObject player;
    PlayerInventory playerInventory;
    private void Start()
    {
        playerInventory = player.GetComponent<PlayerInventory>();
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject == player)
        {
            if (!playerInventory.HasObject())
            {
                playerInventory.SetObjectStatus(true);
                DeliveryController.Instance.SelectMailbox();
            }
        }
    }
}
