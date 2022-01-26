using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 4f;

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
    void GetNextWaypoint()
    {
        if(_waypointIndex >= Waypoints.waypoints.Length - 1)
        {
            Destroy(gameObject);
            return;
        }

        _waypointIndex++;
        _target = Waypoints.waypoints[_waypointIndex];
    }
}
