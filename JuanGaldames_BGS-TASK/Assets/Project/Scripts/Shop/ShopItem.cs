using System.Diagnostics;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

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
    public void SetShopItem(ScriptableItem scriptableItem, PlayerInventory playerInventory, bool toBuy)
    {
        this.scriptableItem = scriptableItem;
        this.playerInventory = playerInventory;

        icon.sprite = scriptableItem.Icon;
        onInventory = scriptableItem.OnInventory;
        price.text = (onInventory ? scriptableItem.Price / 2 : scriptableItem.Price).ToString();

        soldSign.SetActive(onInventory && toBuy);
        button.interactable = (!onInventory == toBuy);
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
        scriptableItem.OnInventory = false;
        playerInventory.items.Remove(scriptableItem);
        playerInventory.AddMoney(scriptableItem.Price / 2);
        Destroy(gameObject);
    }
}
