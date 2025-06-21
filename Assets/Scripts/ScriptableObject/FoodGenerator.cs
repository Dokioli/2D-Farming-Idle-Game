using UnityEngine;

[CreateAssetMenu(fileName = "FoodGenerator", menuName = "Scriptable Objects/FoodGenerator")]
public class FoodGenerator : ScriptableObject
{
    public string FoodItem;
    public float SpawnRate;
    public float delay;
    public int MaxStorage;
    public int CostToUpgradeStorage;
    public int CostToUpgradeSpawnRate;
    public int CostToUnlockArea;
    public int RequiredLevel;
    public bool IsLocked;
}
