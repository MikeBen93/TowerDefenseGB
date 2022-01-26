using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    private Transform _target;
    private Vector3 _dir;
    private Quaternion _lookRotation;
    private Vector3 _rotation;

    [Header("Unity Setup Fields")]

    public string enemyTag = "Enemy";
    public float turnSpeed = 10f;

    [Header("Shooting attributes")]
    //shooting parameters
    public float range = 15f;
    public float fireRate = 1f;
    private float fireCountdown = 0;
    public GameObject arrowPrefab;
    public Transform firePoint;

    private void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.25f);
    }

    private void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if(nearestEnemy != null && shortestDistance <= range)
        {
            _target = nearestEnemy.transform;
        } else
        {
            _target = null;
        }
    }

    private void Update()
    {
        if(_target == null) return;

        //target lock on
        _dir = _target.position - transform.position;
        _lookRotation = Quaternion.LookRotation(_dir);
        _rotation = Quaternion.Lerp(transform.rotation, _lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        transform.rotation = Quaternion.Euler(0f, _rotation.y, 0f);

        if(fireCountdown<=0)
        {
            Shoot();
            fireCountdown = 1 / fireRate;
        }

        fireCountdown -= Time.deltaTime;
    }

    private void Shoot()
    {
        GameObject arrowGO = Instantiate(arrowPrefab, firePoint.position, firePoint.rotation);
        Arrow arrow = arrowGO.GetComponent<Arrow>();

        if(arrow != null) arrow.SetAim(_target);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
