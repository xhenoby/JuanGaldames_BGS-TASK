using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour, IInteractable
{
    [Header("Settings")]
    [SerializeField] float textSpeed = 0.05f;
    [SerializeField, TextArea] string[] dialogue;

    [Header("References")]
    [SerializeField] Talk talkCanvas;
    [SerializeField] GameObject shopCanvas;
    [SerializeField] GameObject sellScreen;
    [SerializeField] GameObject buyScreen;
    [SerializeField] Transform BuyCategoryContainer;
    [SerializeField] Transform SellCategoryContainer;
    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] PlayerInventory playerInventory;

    [Header("Assets")]
    [SerializeField] ShopItem ItemPrefab;
    [SerializeField] ItemCategory CategoryPrefab;
    [SerializeField] ScriptableItem[] ItemList;


    List<ItemCategory> buyCategories = new List<ItemCategory>();
    List<ItemCategory> sellCategories = new List<ItemCategory>();

    public bool IsTalking { get; private set; }
    public GameObject ShopCanvas { get => shopCanvas; }

    public void Interact()
    {
        if (playerInventory.InventoryUI.activeInHierarchy)//TODO Canva Controller, also see player Inventory
        {
            return;
        }

        if (shopCanvas.activeInHierarchy)
        {
            HideShopUI();
            return;
        }

        if (!IsTalking)
        {
            playerMovement.BlockMovement(true);
            IsTalking = true;
            talkCanvas.ShowDialogue(ShowShopUI, textSpeed, dialogue);
        }
        else
        {
            talkCanvas.UpdateLine();
        }
    }

    public void HideShopUI()
    {
        shopCanvas.gameObject.SetActive(false);
        IsTalking = false;
        playerMovement.BlockMovement(false);
    }

    void ShowShopUI()
    {
        IsTalking = false;
        shopCanvas.gameObject.SetActive(true);
        ShowBuy();
    }
    public void ShowBuy()
    {
        InstanciateBuyItems();
        HideSell();
        buyScreen.gameObject.SetActive(true);
    }
    void HideBuy()
    {
        buyScreen.gameObject.SetActive(false);
    }
    
    public void ShowSell()
    {
        InstanciateSellItems();
        HideBuy();
        sellScreen.gameObject.SetActive(true);
    }
    void HideSell()
    {
        sellScreen.gameObject.SetActive(false);
    }

    void InstanciateBuyItems()
    {
        for (int i = 0; i < buyCategories.Count; i++)
        {
            Destroy(BuyCategoryContainer.GetChild(i).gameObject);
        }

        buyCategories.Clear();

        for (int i = 0; i < ItemList.Length; i++)
        {
            Transform buyParent = GetCategoriesContainer(ItemList[i].ItemType.ToString(), buyCategories, BuyCategoryContainer);
            ShopItem newBuyItem = Instantiate(ItemPrefab, buyParent);
            newBuyItem.SetShopItem(ItemList[i], playerInventory, true);
        }
    }

    void InstanciateSellItems()
    {
        for (int i = 0; i < sellCategories.Count; i++)
        {
            Destroy(SellCategoryContainer.GetChild(i).gameObject);
        }

        sellCategories.Clear();

        for (int i = 0; i < ItemList.Length; i++)
        {
            if (ItemList[i].OnInventory)
            {
                Transform sellParent = GetCategoriesContainer(ItemList[i].ItemType.ToString(), sellCategories, SellCategoryContainer);
                ShopItem newSellItem = Instantiate(ItemPrefab, sellParent);
                newSellItem.SetShopItem(ItemList[i], playerInventory, false);
            }
        }
    }

    Transform GetCategoriesContainer(string name, List<ItemCategory> categories, Transform parent)
    {
        for (int i = 0; i < categories.Count; i++)
        {
            if (categories[i].categoryName.text == name)
            {
                return categories[i].ItemContainer;
            }
        }

        ItemCategory newCategory = Instantiate(CategoryPrefab, parent);
        newCategory.categoryName.text = name;
        categories.Add(newCategory);
        return newCategory.ItemContainer;
    }
}
