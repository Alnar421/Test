using UnityEngine;
using UnityEngine.UI;

public class LevelUpSystem : MonoBehaviour
{
    public int level = 1;
    public int experience = 0;
    public int experienceToLevel = 5;

    public Text levelText;
    public Slider experienceSlider;

    void Start()
    {
        UpdateUI();
    }

    public void GainExperience(int amount)
    {
        experience += amount;
        while (experience >= experienceToLevel)
        {
            experience -= experienceToLevel;
            level++;
            experienceToLevel = Mathf.CeilToInt(experienceToLevel * 1.5f);
            LevelUp();
        }
        UpdateUI();
    }

    void LevelUp()
    {
        // TODO: implement upgrade selection logic
    }

    void UpdateUI()
    {
        if (levelText != null)
        {
            levelText.text = "Level: " + level;
        }
        if (experienceSlider != null)
        {
            experienceSlider.maxValue = experienceToLevel;
            experienceSlider.value = experience;
        }
    }
}
