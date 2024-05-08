using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Item")]
public class ScriptableItem : ScriptableObject
{
    public Sprite Icon;
    public int Price;
    public ItemType ItemType;
    public bool OnInventory;
    public Sprite[] sprites;
}
public enum ItemType { Hat, Hair, Cloth }
