using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeStats : MonoBehaviour
{
    public FoodGenerator foodGenerator;
    CurrencyManager currencyManager;

    [SerializeField] int currentSpawnLevel;
    [SerializeField] int currentStorageLevel;
    [SerializeField] int maxLevel;

    [SerializeField] TextMeshProUGUI spawnRateText;
    [SerializeField] TextMeshProUGUI maxStorageText;
    [SerializeField] TextMeshProUGUI TitleText;

    [SerializeField] Button upgradeSpawnButton;
    [SerializeField] Button upgradeStorageButton;

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
        upgradeSpawnButton.interactable = currentSpawnLevel < maxLevel;
        maxStorageText.text = "MaxStorage : " + foodGenerator.MaxStorage + " / " + foodGenerator.CostToUpgradeStorage + "$";
        upgradeStorageButton.interactable = currentStorageLevel < maxLevel;
        TitleText.text = "Upgrade " + foodGenerator.FoodItem;
        UpdateButtonStats();
    }

    private void UpdateButtonStats()
    {
        if (currentStorageLevel > maxLevel)
        {
            maxStorageText.text = "Maxed!";
        }
        else if (currentSpawnLevel > maxLevel)
        {
            spawnRateText.text = "Maxed!";
        }
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
        UpdateButtonStats();
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
        UpdateButtonStats();
    }
}
