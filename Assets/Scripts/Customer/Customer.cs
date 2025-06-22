using TMPro;
using UnityEngine;

public class Customer : MonoBehaviour
{
    public FoodGenerator poultry;
    public FoodGenerator dairy;

    private CustomerManager manager;
    private CurrencyManager currencyManager;
    private Experiencemanager experiencemanager;

    public int eggCount;

    public int milkCount;

    [SerializeField] TextMeshProUGUI milkCountText;
    [SerializeField] TextMeshProUGUI eggCountText;

    AudioManager audioManager;

    private void Awake()
    {
        audioManager = FindFirstObjectByType<AudioManager>();
    }
    public void Init(Experiencemanager experiencemanagerm, CurrencyManager currencyManager, CustomerManager manager)
    {
        this.experiencemanager = experiencemanagerm;
        this.currencyManager = currencyManager;
        this.manager = manager;
        OrderCount();
    }
    public void OrderCount()
    {
        switch (experiencemanager.CurrentLevel)
        {
            case 2:
                milkCount = Random.Range(1, 5);
                eggCount = Random.Range(1, 5);

                eggCountText.text = ": " + eggCount;
                milkCountText.text = milkCount + ": ";
                break;
            default:
                eggCount = Random.Range(1, 5);

                eggCountText.text = ": " + eggCount;
                break;
        }
        audioManager.PlayAudio(audioManager.orderTingClip);
    }

    public void CheckItemCount(int eggamount, int milkamount)
    {
        eggCount -= eggamount;
        milkCount -= milkamount;

        eggCountText.text = ": " + eggCount;
        milkCountText.text = milkCount + ": ";

        if (eggCount <= 0 && milkCount <= 0)
        {
            experiencemanager.AddPoints(20);
            currencyManager.AddCurrency(200);
            audioManager.PlayAudio(audioManager.cashCollectedClip);
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        manager.DecreaseCounter();
    }

}
