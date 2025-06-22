using UnityEngine;

public class MilkTemp : FoodSpawner
{
    protected override void CollectItem(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;

        if (!foodGenerator.IsLocked)
        {
            upgradeStats.GetCurrentFood(foodGenerator);

            FoodCollector collector = collision.GetComponent<FoodCollector>();

            int amountToCollect = Mathf.Min(currentStorage, collector.maxStorage - collector.milkStorage);

            collector.CollectMilk(currentStorage);

            currentStorage = Mathf.Max(0, currentStorage - amountToCollect);

            countText.text = currentStorage.ToString();
        }
        else if (currencyManager.currentCurrency >= foodGenerator.CostToUnlockArea && foodGenerator.IsLocked && experienceManager.CurrentLevel >= foodGenerator.RequiredLevel)
        {
            foodGenerator.IsLocked = false;
            currencyManager.RemoveCurrency(foodGenerator.CostToUnlockArea);
            onOverlap.Invoke();
            StartCoroutine(ProduceFood());
        }
    }
}
