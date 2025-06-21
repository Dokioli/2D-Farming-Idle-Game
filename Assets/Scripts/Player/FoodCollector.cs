using UnityEngine;

public class FoodCollector : MonoBehaviour
{
    [SerializeField] public int eggStorage = 0;
    public int maxStorage = 10;

    public void CollectItem(int amount)
    {
        if (eggStorage >= maxStorage)
        {
            return;
        }
        eggStorage = Mathf.Min(eggStorage + amount, maxStorage);
    }
}
