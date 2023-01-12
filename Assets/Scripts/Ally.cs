using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ally : MonoBehaviour
{
    [SerializeField] private int _initialHealth = 100;
    [SerializeField] private int _distanceToPlayer;
    [SerializeField] private Player _player;
    [SerializeField] private HealthDisplay _healthDisplay;
    [SerializeField] private float _speed = 5f;

    private int _health;

    public int Health
    {
        get { return _health; }
    }

    private void Awake()
    {
        _health = _initialHealth;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(_player.transform);
        if(Vector3.Distance(transform.position, _player.transform.position) > _distanceToPlayer)
        {
            transform.position += transform.forward * _speed * Time.deltaTime;
            // other way without LookAt
            // transform.position = Vector3.MoveTowards(transform.position, _player.transform.position, _speed * Time.deltaTime)
        }
    }

    private void HealthManager(int damage)
    {
        _health = _health - damage;

        if (_health <= 0)
        {
            _health = 0;
        }

        _healthDisplay.SetHealthText("Ally", _health);
    }

    private void OnTriggerEnter(Collider other)
    {
        Bomb bomb = other.gameObject.GetComponent<Bomb>();
        Debug.Log(other.gameObject);

        HealthManager(bomb.Damage);

        Destroy(bomb);
    }
}
