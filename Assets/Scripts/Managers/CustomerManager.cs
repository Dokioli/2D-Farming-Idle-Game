using System.Collections;
using UnityEngine;

public class CustomerManager : MonoBehaviour
{
    AudioManager audioManager;
    private CustomerManager manager;
    private CurrencyManager currencyManager;
    private Experiencemanager experiencemanager;

    [SerializeField] GameObject[] customerPrefab;
    [SerializeField] Transform[] spawnTransform;

    float timer = 0;
    [SerializeField] int maxSpawn;
    private int currentSpawnIndex;
    public int counter;

    private void Start()
    {
        audioManager = FindFirstObjectByType<AudioManager>();
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
                Transform spawnPoint = spawnTransform[currentSpawnIndex];

                Customer customer = Instantiate(customerPrefab[randomIndex], spawnPoint.position, Quaternion.identity).GetComponent<Customer>();
                customer.Init(experiencemanager, currencyManager, manager);

                currentSpawnIndex = (currentSpawnIndex + 1) % spawnTransform.Length;
            }

            yield return new WaitForSeconds(1f);
        }
    }

    public void DecreaseCounter()
    {
        counter--;
    }
}
