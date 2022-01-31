using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float startSpeed = 10f;
    [HideInInspector]
    public float speed;
    public float health = 100;
    public int worth = 50; //amount of money gained from enemy killing
    public GameObject deathEffect;

    private void Start()
    {
        speed = startSpeed;
    }
    public void TakeDamage(float amount)
    {
        health -= amount;

        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        PlayerStats.Money += worth;
        GameObject effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 5f);
        Destroy(gameObject);
    }

    public void Slow(float ratio)
    {
        speed = startSpeed * (1 - ratio);
    }
}
