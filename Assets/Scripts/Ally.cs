using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ally : MonoBehaviour
{
    [SerializeField] private int _distanceToPlayer;
    [SerializeField] private Player _player;
    [SerializeField] private float _speed = 5f;

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
}
