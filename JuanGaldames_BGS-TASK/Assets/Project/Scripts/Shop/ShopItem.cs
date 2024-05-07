using System.Diagnostics;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class ShopItem : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI price;
    [SerializeField] Image icon;
    [SerializeField] GameObject soldSign;
    [SerializeField] Button button;

    ScriptableItem scriptableItem;
    PlayerInventory playerInventory;
    bool onInventory;

    private void Start()
    {
        button.onClick.AddListener(CheckInventory);
    }
    void CheckInventory()
    {
        if (onInventory)
        {
            Sell();
        }
        else
        {
            Buy();
        }
    }
    public void SetShopItem(ScriptableItem scriptableItem, PlayerInventory playerInventory)
    {
        this.scriptableItem = scriptableItem;
        this.playerInventory = playerInventory;
        
        price.text = scriptableItem.Price.ToString();
        icon.sprite = scriptableItem.Icon;
        onInventory = scriptableItem.OnInventory;

        soldSign.SetActive(onInventory);
        button.interactable = !onInventory;
    }

    public void Buy()
    {
        if (playerInventory.MoneyAmount < scriptableItem.Price)
        {
            return;
        }
        button.interactable = false;
        soldSign.SetActive(true);

        scriptableItem.OnInventory = true;
        playerInventory.items.Add(scriptableItem);
        playerInventory.AddMoney(-scriptableItem.Price);
    }

    public void Sell()
    {
        playerInventory.items.Remove(scriptableItem);
        playerInventory.AddMoney(scriptableItem.Price / 2);
        Destroy(gameObject);
    }
}
