using TMPro;
using UnityEngine;

public class FoodCollector : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI itemText;
    [SerializeField] TextMeshProUGUI milkText;

    public int maxStorage = 10;
    public int eggStorage = 0;
    public int milkStorage = 0;

    public void CollectItem(int amount)
    {
        if (eggStorage >= maxStorage)
        {
            return;
        }
        eggStorage = Mathf.Min(eggStorage + amount, maxStorage);
        itemText.text = ": " + eggStorage;
    }

    public void CollectMilk(int amount)
    {
        if (milkStorage >= maxStorage)
        {
            return;
        }
        milkStorage = Mathf.Min(milkStorage + amount, maxStorage);
        milkText.text = ": " + milkStorage;
    }
}
