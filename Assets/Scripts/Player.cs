using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class Player : MonoBehaviour
{
    [SerializeField] private int _initialHealth = 100;
    private int _health;
    // readonly property: can get the value but not set it
    // allow setting values by doing what we could do with function
    public int Health { get { return _health; } }

    private void Awake()
    {
        _health = _initialHealth;
    }

    private void HealthManager(int damage)
    {
        _health = _health - damage;
        
        if (_health <= 0) {
            _health = 0;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject);
        Bomb bomb = other.gameObject.GetComponent<Bomb>();

        HealthManager(bomb.Damage);

        Destroy(bomb);
    }
}
