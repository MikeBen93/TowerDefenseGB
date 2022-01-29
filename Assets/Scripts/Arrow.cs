using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    private Transform _target;

    public float speed = 15;
    public GameObject impactEffect;
    public float explosionRadius = 0f;
    public int damage = 50;

    public void SetAim(Transform target)
    {
        _target = target;
    }

    private void SeekAim()
    {

    }

    private void Update()
    {
        if(_target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = _target.position - transform.position;
        //Quaternion _lookRotation = Quaternion.LookRotation(dir);
        //Vector3 _rotation = Quaternion.Lerp(transform.rotation, _lookRotation, Time.deltaTime * 10).eulerAngles;
        //transform.rotation = Quaternion.Euler(0f, _rotation.y, 0f);

        float distanceThisFrame = speed * Time.deltaTime;

        if(dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
        transform.LookAt(_target);
    }

    private void HitTarget()
    {
        GameObject effectIns =  Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effectIns, 3f);

        if(explosionRadius > 0f)
        {
            Explode();
        } else
        {
            Damage(_target);
        }

        Destroy(gameObject);
    }

    private void Damage(Transform enemy)
    {
        Enemy e = enemy.GetComponent<Enemy>();

        if (e != null)
        {
            e.TakeDamage(damage);
        }
    }

    private void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);

        foreach(Collider collider in colliders)
        {
            if (collider.tag == "Enemy")
            {
                Damage(collider.transform);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}
