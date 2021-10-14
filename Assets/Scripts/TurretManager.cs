
using UnityEngine;

public class TurretManager : MonoBehaviour
{

    private Transform _target;
    public Transform rotatingPart;
    public Transform firePoint; 

    public float turretRange = 15f;
    public float rotationSpeed = 5f;
    public float fireRate = 1f;
    private float _fireCoundown = 0f;

    public string enemyTag = "Enemy";

    public GameObject bulletPrefab;

    private void Start()
    {
        InvokeRepeating("TargetUpdate", 0f, 0.25f);
    }

    private void Update()
    {
        if (_target == null)
        {
            return; 
        }

        Vector3 focusDirection = _target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(focusDirection);
        Vector3 rotate = Quaternion.Lerp(rotatingPart.rotation, lookRotation, Time.deltaTime * rotationSpeed).eulerAngles;
        rotatingPart.rotation = Quaternion.Euler(0f, rotate.y, 0f);

        if (_fireCoundown <= 0f)
        {
            Shoot();
            _fireCoundown = 1f / fireRate;
        }
        _fireCoundown -= Time.deltaTime;
    }
    
    void TargetUpdate()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);

        float shortestDistance = Mathf.Infinity;
        GameObject closestEnemy = null;
        
        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);

            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                closestEnemy = enemy;
            }
        }

        if (closestEnemy != null && shortestDistance <= turretRange)
        {
            _target = closestEnemy.transform;
        }
        else
        {
            _target = null;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, turretRange);
    }

     void Shoot()
    {
       GameObject bulletGO = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation); 
       BulletManager bullet = bulletGO.GetComponent<BulletManager>();

       if (bullet !=null)
       {
           bullet.Chase(_target);
       }
    }
}