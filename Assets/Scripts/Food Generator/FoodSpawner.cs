using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FoodSpawner : MonoBehaviour
{
    UpgradeStats upgradeStats;
    CurrencyManager currencyManager;
    public FoodGenerator foodGenerator;

    [SerializeField] Image fillImage;
    [SerializeField] TextMeshProUGUI countText;
    [SerializeField] int currentStorage = 0;
    float elapsedTime = 0;
    private void Start()
    {
        currencyManager = FindFirstObjectByType<CurrencyManager>();
        upgradeStats = FindFirstObjectByType<UpgradeStats>();
        StartCoroutine(ProduceFood());
    }

    IEnumerator ProduceFood()
    {
        while (true)
        {
            while (elapsedTime < foodGenerator.SpawnRate)
            {
                elapsedTime += Time.deltaTime;
                fillImage.fillAmount = Mathf.Clamp01(elapsedTime / foodGenerator.SpawnRate);
                yield return null;
            }
            currentStorage++;
            currentStorage = Mathf.Min(currentStorage, foodGenerator.MaxStorage);
            countText.text = currentStorage.ToString();
            elapsedTime = 0;

            yield return new WaitForSeconds(foodGenerator.delay);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;

        upgradeStats.GetCurrentFood(foodGenerator);

        FoodCollector collector = collision.GetComponent<FoodCollector>();

        int amountToCollect = Mathf.Min(currentStorage, collector.maxStorage - collector.eggStorage);

        collector.CollectItem(currentStorage);

        currentStorage = Mathf.Max(0, currentStorage - amountToCollect);

        countText.text = currentStorage.ToString();
    }
}
