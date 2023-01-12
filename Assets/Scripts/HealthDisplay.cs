using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class HealthDisplay : MonoBehaviour
{
    #region if we wanted to create canvas & TextMeshPro programatically
    /*private GameObject _canvas;
    private GameObject _health;
    private TextMeshPro _playerHealthText;*/
    #endregion
    
    [SerializeField] private TMP_Text _playerHealthText;
    [SerializeField] private TMP_Text _allyHealthText;
    [SerializeField] private Player _player;
    [SerializeField] private Ally _ally;

    private int _playerLastHealthAmount;
    private int _allyLastHealthAmount;

    public IntVariable _playerHealth;

    private void Awake()
    {
        _playerLastHealthAmount = _player.Health;
        _allyLastHealthAmount = _ally.Health;
    }
    // Start is called before the first frame update
    void Start()
    {
        SetHealthText("Player", _player.Health);
        SetHealthText("Ally", _ally.Health);

        Debug.Log(_playerHealth.Value);
    }

    // Update is called once per frame
    void Update()
    {
        if (_player.Health != _playerLastHealthAmount)
        {
            _playerHealthText.text = SetHealthText("Player", _player.Health);
            _playerLastHealthAmount = _player.Health;
        } else if (_ally.Health != _allyLastHealthAmount)
        {
            _allyLastHealthAmount = _ally.Health;
            _allyHealthText.text = SetHealthText("Ally", _ally.Health);
        }
    }

    public string SetHealthText(string character, int amount)
    {
        return $"{character} HP = {amount.ToString()}";
    }
}
