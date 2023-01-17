using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] private int _damage = 10;

    public int Damage
    {
        get
        {
            return _damage;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Character charToHurt = other.GetComponent<Character>();

        charToHurt.HealthManager(_damage);
        Destroy(gameObject);
    }
}
