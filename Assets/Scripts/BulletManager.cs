using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    private Transform _target;

    public float speed = 30f;

    public void Chase(Transform target)
    {
        _target = target;
        
    }
    
    void Update()
    {
        Vector3 direction = _target.position - transform.position;
        float frameDistance = speed * Time.deltaTime;

        if (direction.magnitude <= frameDistance)
        {
            HitTarget();
            return;
        }
        
        transform.Translate(direction.normalized * frameDistance, Space.World);
        
        
        
        if (_target == null)
        {
            Destroy(gameObject);
            return; 
        }

        void HitTarget()
        {
            Destroy((gameObject));
        }
    }
}

