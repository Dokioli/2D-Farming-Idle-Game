using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public abstract class FoodSpawner : MonoBehaviour
{
    protected UpgradeStats upgradeStats;
    protected CurrencyManager currencyManager;
    protected Experiencemanager experienceManager;
    public FoodGenerator foodGenerator;
    protected AudioManager audioManager;

    [SerializeField] protected Image fillImage;
    [SerializeField] protected TextMeshProUGUI countText;
    [SerializeField] protected int currentStorage = 0;

    [SerializeField] protected UnityEvent onOverlap;

    float elapsedTime = 0;
    private void Start()
    {
        audioManager = FindFirstObjectByType<AudioManager>();
        currencyManager = FindFirstObjectByType<CurrencyManager>();
        experienceManager = FindFirstObjectByType<Experiencemanager>();
        upgradeStats = FindFirstObjectByType<UpgradeStats>();
        //StartCoroutine(ProduceFood());
    }

    protected IEnumerator ProduceFood()
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
        CollectItem(collision);
    }

    protected abstract void CollectItem(Collider2D collision);

}
