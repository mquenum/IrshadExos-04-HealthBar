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
}
