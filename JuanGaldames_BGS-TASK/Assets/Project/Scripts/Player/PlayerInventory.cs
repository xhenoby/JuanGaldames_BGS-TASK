using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInventory : MonoBehaviour
{
    [Header("References")]
    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] PlayerAnimation playerAnimation;
    [SerializeField] ShopManager shop;
    [SerializeField] GameObject inventoryUI;
    [SerializeField] Transform CategoryContainer;
    [SerializeField] TextMeshProUGUI MoneyText;

    [Header("Assets")]
    [SerializeField] Item ItemPrefab;
    [SerializeField] ItemCategory CategoryPrefab;


    public int MoneyAmount;
    public List<ScriptableItem> items;
    List<ItemCategory> categories = new List<ItemCategory>();
    public GameObject InventoryUI { get => inventoryUI; }

    public void OnInventory(InputValue inputValue)
    {
        if (shop.ShopCanvas.activeInHierarchy || shop.IsTalking) //TODO Canva Controller, also see Shop
        {
            return;
        }

        if (inventoryUI.activeInHierarchy)
        {
            HideInventory();
            return;
        }

        ShowInventory();
    }
    public void ShowInventory()
    {
        inventoryUI.SetActive(true);
        playerMovement.BlockMovement(true);

        InstanciateItems();
    }
    public void HideInventory()
    {
        inventoryUI.SetActive(false);
        playerMovement.BlockMovement(false);
    }
    public void AddMoney(int moneyToAdd)
    {
        MoneyAmount += moneyToAdd;
        MoneyText.text = MoneyAmount.ToString();
    }
    void InstanciateItems()
    {
        for (int i = 0; i < categories.Count; i++)
        {
            Destroy(CategoryContainer.GetChild(i).gameObject);
        }
        categories.Clear();

        for (int i = 0; i < items.Count; i++)
        {
            Transform category = GetCategoriesContainer(items[i].ItemType);
            Item newItem = Instantiate(ItemPrefab, category);
            newItem.SetItem(items[i].ItemType, items[i], playerAnimation);
        }
    }

    Transform GetCategoriesContainer(ItemType itemType)
    {
        for (int i = 0; i < categories.Count; i++)
        {
            if (categories[i].categoryName.text == itemType.ToString())
            {
                return categories[i].ItemContainer;
            }
        }
        ItemCategory newCategory = Instantiate(CategoryPrefab, CategoryContainer);
        newCategory.categoryName.text = itemType.ToString();
        categories.Add(newCategory);

        Item emptyItem = Instantiate(ItemPrefab, newCategory.ItemContainer);
        emptyItem.SetItem(itemType, null, playerAnimation); ;

        return newCategory.ItemContainer;
    }
}
