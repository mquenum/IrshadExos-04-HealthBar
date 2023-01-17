using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    [SerializeField] private IntVariable _hp;

    private int _lastHealthAmount;

    private void Awake()
    {
        _lastHealthAmount = _hp.Value;
    }

    // Start is called before the first frame update
    void Start()
    {
        SetHealthText(_hp.Value);
    }

    // Update is called once per frame
    void Update()
    {
        if (_hp.Value != _lastHealthAmount)
        {
            SetHealthText(_hp.Value);
        }
    }

    public void SetHealthText(int amount)
    {
        TMP_Text _healthAmount = gameObject.GetComponent<TMP_Text>();

        _healthAmount.text = amount.ToString();
        _lastHealthAmount = amount;
    }
}
