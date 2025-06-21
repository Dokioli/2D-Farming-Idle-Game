using TMPro;
using UnityEngine;

public class CurrencyManager : MonoBehaviour
{
    public int currentCurrency = 0;

    [SerializeField] TextMeshProUGUI currencyText;

    private void Start()
    {
        currencyText.text = " : " + currentCurrency;
    }

    public void AddCurrency(int amount)
    {
        currentCurrency += amount;
        currencyText.text = currentCurrency.ToString();
    }
    public void RemoveCurrency(int amount)
    {
        if (currentCurrency >= amount)
        {
            currentCurrency = Mathf.Max(0, currentCurrency -= amount);
        }
        currencyText.text = currentCurrency.ToString();
    }
}
