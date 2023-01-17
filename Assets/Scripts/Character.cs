using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private int _initialHealth = 100;
    [SerializeField] private IntVariable _health;
    // readonly property: can get the value but not set it
    // allow setting values by doing what we could do with function

    public int Health { get { return _health.Value; } }

    private void Awake()
    {
        _health.Value = _initialHealth;
    }

    public void HealthManager(int damage)
    {
        _health.Value = _health.Value - damage;

        if (_health.Value <= 0)
        {
            _health.Value = 0;
        }
    }
}
