using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 10f;

    private Transform _target;
    private int _wavepoint = 0;
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
                Destroy(gameObject);
            }
            _wavepoint++;
            _target = Waypoints.Pins[_wavepoint];
        }
    }
}
