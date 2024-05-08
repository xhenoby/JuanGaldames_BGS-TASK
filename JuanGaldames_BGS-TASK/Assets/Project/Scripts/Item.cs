using using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    [SerializeField] Image icon;
    [SerializeField] Button Button;
    ItemType itemType;
    bool equiped;
    PlayerAnimation playerAnimation;
    ScriptableItem scriptableItem;

    private void Start()
    {
        Button.onClick.AddListener(Equip);
    }

    public void SetItem(ItemType itemType, ScriptableItem scriptableItem, PlayerAnimation playerAnimation)
    {
        this.itemType = itemType;
        this.scriptableItem = scriptableItem;
        this.playerAnimation = playerAnimation;
        icon.sprite = scriptableItem ? scriptableItem.Icon : icon.sprite;
    }
    void Equip()
    {
        Button.interactable = false;
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
}
