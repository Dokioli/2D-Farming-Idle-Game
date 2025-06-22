using System.Collections;
using UnityEngine;

public class CustomerManager : MonoBehaviour
{
    private CustomerManager manager;
    private CurrencyManager currencyManager;
    private Experiencemanager experiencemanager;

    [SerializeField] GameObject[] customerPrefab;
    [SerializeField] Transform[] spawnTransform;

    float timer = 0;
    [SerializeField] int maxSpawn;
    public int counter;
    private void Start()
    {
        manager = FindFirstObjectByType<CustomerManager>();
        experiencemanager = FindFirstObjectByType<Experiencemanager>();
        currencyManager = FindFirstObjectByType<CurrencyManager>();
        StartCoroutine(SpawnCustomer());
    }

    IEnumerator SpawnCustomer()
    {
        while (true)
        {
            while (timer < 3)
            {
                timer += Time.deltaTime;
                yield return null;
            }
            timer = 0;
            if (counter < maxSpawn)
            {
                counter++;

                int randomIndex = Random.Range(0, customerPrefab.Length);
                int randomSpawnIndex = Random.Range(0, spawnTransform.Length);
                Customer customer = Instantiate(customerPrefab[randomIndex], spawnTransform[randomSpawnIndex].position, Quaternion.identity).GetComponent<Customer>();
                customer.Init(experiencemanager, currencyManager, manager);
                Debug.Log("Customer Spawned");
            }

            yield return new WaitForSeconds(1f);
        }
    }

    public void DecreaseCounter()
    {
        counter--;
    }
}
