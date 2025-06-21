using TMPro;
using UnityEngine;

public class UpgradeStats : MonoBehaviour
{
    public FoodGenerator foodGenerator;
    CurrencyManager currencyManager;
    [SerializeField] int currentSpawnLevel;
    [SerializeField] int currentStorageLevel;
    [SerializeField] int maxLevel;

    [SerializeField] TextMeshProUGUI spawnRateText;
    [SerializeField] TextMeshProUGUI maxStorageText;

    private void Start()
    {
        currencyManager = FindFirstObjectByType<CurrencyManager>();
    }

    public void GetCurrentFood(FoodGenerator foodGenerator)
    {
        this.foodGenerator = foodGenerator;
        UpdateUI();
    }

    private void UpdateUI()
    {
        spawnRateText.text = "SpawnRate : " + foodGenerator.SpawnRate + " / " + foodGenerator.CostToUpgradeSpawnRate + "$";
        maxStorageText.text = "MaxStorage : " + foodGenerator.MaxStorage + " / " + foodGenerator.CostToUpgradeStorage + "$";
    }

    public void UpgradeSpawnRate(float amount)
    {
        if (currentSpawnLevel > maxLevel) return;
        if (currencyManager.currentCurrency >= foodGenerator.CostToUpgradeSpawnRate)
        {
            foodGenerator.SpawnRate -= amount;
            currencyManager.RemoveCurrency(foodGenerator.CostToUpgradeSpawnRate);
            foodGenerator.CostToUpgradeSpawnRate += 100;
            currentSpawnLevel++;
        }
        UpdateUI();
    }
    public void UpgradeMaxStorage(int amount)
    {
        if (currentStorageLevel > maxLevel) return;
        if (currencyManager.currentCurrency >= foodGenerator.CostToUpgradeStorage)
        {
            foodGenerator.MaxStorage += amount;
            currencyManager.RemoveCurrency(foodGenerator.CostToUpgradeStorage);
            foodGenerator.CostToUpgradeStorage += 100;
            currentStorageLevel++;
        }
        UpdateUI();
    }
}
