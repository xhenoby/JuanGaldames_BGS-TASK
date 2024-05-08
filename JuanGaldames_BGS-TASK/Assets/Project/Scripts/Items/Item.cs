using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    [SerializeField] Image icon;
    [SerializeField] Button button;
    ItemType itemType;
    bool equiped;
    PlayerAnimation playerAnimation;
    ScriptableItem scriptableItem;

    public Button Button { get => button; }

    private void Start()
    {
        button.onClick.AddListener(Equip);
    }

    public void SetItem(ItemType itemType, ScriptableItem scriptableItem, PlayerAnimation playerAnimation)
    {
        this.itemType = itemType;
        this.scriptableItem = scriptableItem;
        this.playerAnimation = playerAnimation;
        icon.sprite = scriptableItem ? scriptableItem.Icon : icon.sprite;
        CheckIfEquiped();
    }
    void Equip()
    {
        SelectButton();
        switch (itemType)
        {
            case ItemType.Hat:
                playerAnimation.ChangeHat(scriptableItem);
                break;
            case ItemType.Hair:
                playerAnimation.ChangeHair(scriptableItem);
                break;
            case ItemType.Cloth:
                playerAnimation.ChangeCloth(scriptableItem);
                break;
            default:
                break;
        }
    }
    void CheckIfEquiped()
    {
        switch (itemType)
        {
            case ItemType.Hat:
                if (scriptableItem == playerAnimation.Hat)
                {
                    SelectButton();
                }
                break;
            case ItemType.Hair:
                if (scriptableItem == playerAnimation.Hair)
                {
                    SelectButton();
                }
                break;
            case ItemType.Cloth:
                if (scriptableItem == playerAnimation.Cloth)
                {
                    SelectButton();
                }
                break;
            default:
                break;
        }

    }
    void SelectButton()
    {
        Item[] items = transform.parent.GetComponentsInChildren<Item>();
        for (int i = 0; i < items.Length; i++)
        {
            items[i].Button.interactable = true;
        }
        button.interactable = false;
    }
}
