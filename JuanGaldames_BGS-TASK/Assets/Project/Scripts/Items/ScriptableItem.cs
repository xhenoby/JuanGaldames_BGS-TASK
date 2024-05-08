using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Item")]
public class ScriptableItem : ScriptableObject
{
    public ItemType ItemType;
    public int Price;
    public bool OnInventory;
    public bool Equiped;
    public Sprite Icon;
    public Sprite[] sprites;
}
public enum ItemType { Hat, Hair, Cloth }
