using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Experiencemanager : MonoBehaviour
{
    [SerializeField] int currentLevel = 0;
    int experiencePoints = 0;
    int maxExperiencePoints = 100;
    int additionalExperiencePoints = 100;

    [SerializeField] Image experiencefill;
    [SerializeField] TextMeshProUGUI currentLevelText;

    public int CurrentLevel
    {
        get { return currentLevel; }
    }

    public void AddPoints(int amount)
    {
        experiencePoints += amount;

        if (experiencePoints >= maxExperiencePoints)
        {
            LevelUp();
        }
        UpdateUI();
    }

    private void UpdateUI()
    {
        experiencefill.fillAmount = (float)experiencePoints / maxExperiencePoints;
        currentLevelText.text = "Level : " + currentLevel;
    }

    private void LevelUp()
    {
        currentLevel++;
        experiencePoints = 0;
        maxExperiencePoints += additionalExperiencePoints;
    }
}
