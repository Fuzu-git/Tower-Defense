
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 10f;

    private Transform _target;
    
    private int _wavepoint = 0;
    public static int Health = 10;
    public static int reward = 2;
    void Start()
    {
        _target = Waypoints.Pins[0];
    }
    
    void Update()
    {
        Vector3 direction = _target.position - transform.position;
        transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, _target.position) <= 0.2f)
        {
            NextWavepoint();
        }

        void NextWavepoint()
        {
            if (_wavepoint >= Waypoints.Pins.Length - 1)
            {
                NexusPath();
            }
            _wavepoint++;
            _target = Waypoints.Pins[_wavepoint];
        }

        void NexusPath()
        {
            PlayerManager.Lives--;
            Destroy(gameObject);
        }
    }

    public void TakeDamage(int amount)
    {
        Health -= amount;
        
        if (Health <= 0)
        {
            
            Die();
        }
    }

    void Die()
    {
        PlayerManager.Money += reward;
        Destroy(gameObject);
    }
}
