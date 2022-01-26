using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    private Transform _target;

    public float speed = 15;
    public GameObject impactEffect;

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
        Quaternion _lookRotation = Quaternion.LookRotation(dir);
        Vector3 _rotation = Quaternion.Lerp(transform.rotation, _lookRotation, Time.deltaTime * 10).eulerAngles;
        transform.rotation = Quaternion.Euler(0f, _rotation.y, 0f);

        float distanceThisFrame = speed * Time.deltaTime;

        if(dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
    }

    private void HitTarget()
    {
        GameObject effectIns =  Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effectIns, 2f);
        Destroy(_target.gameObject);
        Destroy(gameObject);
    }
}
