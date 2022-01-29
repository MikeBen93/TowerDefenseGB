using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 4f;
    public int health = 100;
    public int value = 50;
    public GameObject deathEffect;

    private Transform _target;
    private int _waypointIndex = 0;

    private void Start()
    {
        _target = Waypoints.waypoints[_waypointIndex];
    }

    private void Update()
    {
        Vector3 direction = _target.position - transform.position;
        transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);

        if (ReachedWaypoint()) GetNextWaypoint();
    }

    /// <summary>
    /// Function to checek if enemy has reached waypoint
    /// </summary>
    /// <returns></returns>
    private bool ReachedWaypoint()
    {
        return Vector3.Distance(_target.position, transform.position) < 0.4f; 
    }

    /// <summary>
    /// Function to set new waypoint 
    /// </summary>
    private void GetNextWaypoint()
    {
        if(_waypointIndex >= Waypoints.waypoints.Length - 1)
        {
            EndPath();
            return;
        }

        _waypointIndex++;
        _target = Waypoints.waypoints[_waypointIndex];
    }

    private void EndPath()
    {
        PlayerStats.Lives--;
        Destroy(gameObject);
    }

    public void TakeDamage(int amount)
    {
        health -= amount;

        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        PlayerStats.Money += value;
        GameObject effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 5f);
        Destroy(gameObject);
    }
}
