using System.Linq;
using UnityEngine;

public class AutoAttack : MonoBehaviour
{
    // Prefab of the projectile to fire
    public Projectile projectilePrefab;
    // Transform indicating where to spawn projectiles
    public Transform firePoint;
    // How many projectiles to fire per second
    public float fireRate = 1f;
    // Maximum range to search for enemies
    public float attackRange = 5f;

    private float fireTimer;

    void Update()
    {
        // accumulate time for firing based on fireRate
        fireTimer += Time.deltaTime;
        // if enough time has passed, attempt to fire
        if (fireTimer >= 1f / fireRate)
        {
            fireTimer = 0f;
            Enemy nearest = FindNearestEnemy();
            if (nearest != null)
            {
                // compute normalized direction towards the enemy
                Vector2 direction = (nearest.transform.position - firePoint.position).normalized;
                // instantiate projectile and set its direction
                Projectile projectile = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);
                projectile.SetDirection(direction);
            }
        }
    }

    // Finds the nearest enemy within attackRange
    Enemy FindNearestEnemy()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        Enemy nearest = null;
        float minDist = float.MaxValue;
        foreach (Enemy enemy in enemies)
        {
            float dist = Vector2.Distance(transform.position, enemy.transform.position);
            if (dist < minDist && dist <= attackRange)
            {
                minDist = dist;
                nearest = enemy;
            }
        }
        return nearest;
    }
}
