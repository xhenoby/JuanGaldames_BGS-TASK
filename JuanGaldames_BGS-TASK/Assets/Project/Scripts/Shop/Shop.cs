using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.Search;
using UnityEngine;

public class Shop : MonoBehaviour, IInteractable
{
    [Header("Settings")]
    [SerializeField] float textSpeed = 0.05f;
    [SerializeField, TextArea] string[] dialogue;

    [Header("References")]
    [SerializeField] Talk talkCanvas;
    [SerializeField] GameObject shopUI;
    [SerializeField] Transform BuyCategoryContainer;
    [SerializeField] Transform SellCategoryContainer;
    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] PlayerInventory playerInventory;

    [Header("Assets")]
    [SerializeField] ShopItem ItemPrefab;
    [SerializeField] ItemCategory CategoryPrefab;
    [SerializeField] ScriptableItem[] ItemList;

    List<ItemCategory> categories = new List<ItemCategory>();

    public bool IsTalking { get; private set; }
    public Talk TalkCanvas { get => talkCanvas; }
    public GameObject ShopUI { get => shopUI; }

    public void Interact()
    {
        if (playerInventory.InventoryUI.activeInHierarchy)//TODO Canva Controller, also see player Inventory
        {
            return;
        }
        if (shopUI.activeInHierarchy)
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
        shopUI.gameObject.SetActive(false);
        IsTalking = false;
        playerMovement.BlockMovement(false);
    }
    void ShowShopUI()
    {
        IsTalking = false;

        for (int i = 0; i < categories.Count; i++)
        {
            Destroy(BuyCategoryContainer.GetChild(i).gameObject);
        }

        categories.Clear();
        InstanciateItems();
        shopUI.gameObject.SetActive(true);
    }

    void InstanciateItems()
    {
        for (int i = 0; i < ItemList.Length; i++)
        {
            Transform category = GetCategoriesContainer(ItemList[i].ItemType.ToString());
            ShopItem newItem = Instantiate(ItemPrefab, category);
            newItem.SetShopItem(ItemList[i], playerInventory);
        }
    }

    Transform GetCategoriesContainer(string name)
    {
        for (int i = 0; i < categories.Count; i++)
        {
            if (categories[i].categoryName.text == name)
            {
                return categories[i].ItemContainer;
            }
        }
        ItemCategory newCategory = Instantiate(CategoryPrefab, BuyCategoryContainer);
        newCategory.categoryName.text = name;
        categories.Add(newCategory);
        return newCategory.ItemContainer;
    }
}
struct ShopCategory
{
    public string name;
    public string icon;
    public string inventory;
    public string price;
}
