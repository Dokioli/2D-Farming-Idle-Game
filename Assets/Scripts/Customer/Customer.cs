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
                eggCountText.text = milkCount + ": ";
                break;
            default:
                eggCount = Random.Range(1, 5);

                eggCountText.text = ": " + eggCount;
                break;
        }
    }

    public void CheckItemCount(int eggamount, int milkamount)
    {
        eggCount -= eggamount;
        milkCount -= milkamount;
        if (eggCount <= 0 && milkCount <= 0)
        {
            experiencemanager.AddPoints(20);
            currencyManager.AddCurrency(200);
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        manager.DecreaseCounter();
    }

}
