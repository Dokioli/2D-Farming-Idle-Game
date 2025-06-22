using TMPro;
using UnityEngine;

public class FoodCollector : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI itemText;
    [SerializeField] TextMeshProUGUI milkText;

    public int maxStorage = 10;
    public int eggStorage = 0;
    public int milkStorage = 0;

    private Customer customer;
    AudioManager audioManager;

    private void Start()
    {
        audioManager = FindFirstObjectByType<AudioManager>();
    }

    public void CollectItem(int amount)
    {
        if (eggStorage >= maxStorage)
        {
            return;
        }
        audioManager.PlayAudio(audioManager.eggSpawnnedClip);
        eggStorage = Mathf.Min(eggStorage + amount, maxStorage);
        itemText.text = ": " + eggStorage;
    }

    public void CollectMilk(int amount)
    {
        if (milkStorage >= maxStorage)
        {
            return;
        }
        audioManager.PlayAudio(audioManager.milkSpawnnedClip);
        milkStorage = Mathf.Min(milkStorage + amount, maxStorage);
        milkText.text = ": " + milkStorage;
    }


    public void DelieverItem()
    {
        if (eggStorage > 0 || milkStorage > 0)
        {
            int eggsToGive = Mathf.Min(eggStorage, customer.eggCount);
            int milkToGive = Mathf.Min(milkStorage, customer.milkCount);
            customer.CheckItemCount(eggsToGive, milkToGive);
            eggStorage = Mathf.Max(0, eggStorage - eggsToGive);
            milkStorage = Mathf.Max(0, milkStorage - milkToGive);
            itemText.text = ": " + eggStorage;
            milkText.text = ": " + milkStorage;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Customer"))
        {
            customer = collision.GetComponent<Customer>();
            DelieverItem();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        customer = null;
    }
}
