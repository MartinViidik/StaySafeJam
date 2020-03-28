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
                PlayerInventory.Instance.interactableObject = gameObject;
                PlayerInventory.Instance.ShowButtonSprite(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if(col.gameObject == player)
        {
            PlayerInventory.Instance.interactableObject = null;
            PlayerInventory.Instance.ShowButtonSprite(false);
        }
    }
}
