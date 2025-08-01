using UnityEngine;

public class ExperienceGem : MonoBehaviour
{
    public int experienceAmount = 1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            LevelUpSystem levelUpSystem = other.GetComponent<LevelUpSystem>();
            if (levelUpSystem != null)
            {
                levelUpSystem.GainExperience(experienceAmount);
            }
            Destroy(gameObject);
        }
    }
}
