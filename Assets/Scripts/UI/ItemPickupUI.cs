using UnityEngine;
using UnityEngine.UI;

public class ItemPickupUI : MonoBehaviour
{
    private static ItemPickupUI _instance;
    public static ItemPickupUI Instance { get { return _instance; } }

    public GameObject pickupUI;
    public Text pickupTitle;
    public Text pickupText;
    public Image pickupPicture;

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

    private void Update()
    {
        if(pickupUI.active && Input.GetKeyDown(KeyCode.Space)){
            SetPickupUI(false);
        }
    }

    public void SetPickupUI(bool state)
    {
        pickupUI.SetActive(state);
        if(state)
        {
            PlayerMovement.Instance.SetMovementEnabled(false);
        } else {
            PlayerMovement.Instance.SetMovementEnabled(true);
            PlayerInventory.Instance.ShowButtonSprite(false);
        }
    }

    public void UpdatePickupUI(string title, string content, Sprite picture)
    {
        pickupTitle.text = title;
        pickupText.text = content;
        pickupPicture.sprite = picture;
        SetPickupUI(true);
    }

}
