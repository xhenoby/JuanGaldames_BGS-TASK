using TMPro;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI MoneyText;
    public int MoneyAmount;
    public void AddMoney(int moneyToAdd)
    {
        MoneyAmount += moneyToAdd;
        MoneyText.text = MoneyAmount.ToString();
    }
}
