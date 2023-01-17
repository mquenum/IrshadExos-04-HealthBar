using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HealthDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text _playerHealthText;
    [SerializeField] private TMP_Text _allyHealthText;
    [SerializeField] private Player _player;
    [SerializeField] private Ally _ally;

    private int _playerLastHealthAmount;
    private int _allyLastHealthAmount;

    public IntVariable _playerHealth;
    public IntVariable _allyHealth;

    private void Awake()
    {
        _playerLastHealthAmount = _playerHealth.Value;
        _allyLastHealthAmount = _allyHealth.Value;
    }

    // Start is called before the first frame update
    void Start()
    {
        SetHealthText("Player", _playerHealth.Value);
        SetHealthText("Ally", _allyHealth.Value);
    }

    // Update is called once per frame
    void Update()
    {
        if (_player.Health != _playerLastHealthAmount)
        {
            SetHealthText("Player", _player.Health);
            _playerLastHealthAmount = _player.Health;
        }
        else if (_ally.Health != _allyLastHealthAmount)
        {
            _allyLastHealthAmount = _ally.Health;
            SetHealthText("Ally", _ally.Health);
        }
    }

    public void SetHealthText(string character, int amount)
    {
        TMP_Text healthText = (character == "Player") ? _playerHealthText : _allyHealthText;
        healthText.text = $"{character} HP = {amount.ToString()}";
    }
}
