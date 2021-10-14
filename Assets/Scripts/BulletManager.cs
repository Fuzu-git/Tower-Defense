
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    private Transform _target;
    
    public float speed = 30f;

    public int damage = 5;

    public void Chase(Transform target)
    {
        _target = target;
        
    }
    
    void Update()
    {
        if (_target == null)
        {
            Destroy(gameObject);
        }
        
        Vector3 direction = _target.position - transform.position;
        float frameDistance = speed * Time.deltaTime;

        if (direction.magnitude <= frameDistance)
        {
            HitTarget();
            return;
        }
        
        transform.Translate(direction.normalized * frameDistance, Space.World);
        transform.LookAt(_target);

        

        void HitTarget()
        {
            Damage(_target);
            Destroy((gameObject));
        }

        void Damage(Transform Enemy)
        {
            Enemy e = Enemy.GetComponent<Enemy>();
            
            if (e != null)
            { 
                e.TakeDamage(damage);
            }
        }
    }
}

