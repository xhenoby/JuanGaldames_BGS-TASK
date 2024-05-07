using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour, IInteractable
{
    [SerializeField] Talk talkCanvas;
    [SerializeField] GameObject shopUI;
    [SerializeField] GameObject shopItemPrefab;
    [SerializeField] float textSpeed = 0.05f;
    [SerializeField] string[] dialogue;
    bool isTalking;
    ShopCategory[] shopItems;
    public void Interact()
    {
        if (!isTalking)
        {
            talkCanvas.gameObject.SetActive(true);
            isTalking = true;
            talkCanvas.ShowDialogue(ShowShopUI, textSpeed, dialogue);
        }
        else
        {
            talkCanvas.UpdateLine();
        }
    }
    void ShowShopUI()
    {
        talkCanvas.gameObject.SetActive(false);
        isTalking = false;
        shopUI.gameObject.SetActive(true);
    }
}
struct ShopCategory
{
    public string name;
    public string icon;
    public string inventory;
    public string price;
}
