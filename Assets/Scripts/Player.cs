using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int _initialHealth = 100;
    private int _health;
    // readonly property: can get the value but not set it
    public int Health { get { return this._health; } }

    // Start is called before the first frame update
    void Start()
    {
        _health = _initialHealth;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
