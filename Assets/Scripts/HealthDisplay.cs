using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HealthDisplay : MonoBehaviour
{
    #region if we wanted to create canvas & TextMeshPro programatically
    /*private GameObject _canvas;
    private GameObject _health;
    private TextMeshPro _healthText;*/
    #endregion
    
    [SerializeField] private TextMeshProUGUI _healthText;

    public Player Player;
    int _healthAmount;
    // Start is called before the first frame update
    void Start()
    {
        _healthAmount = Player.Health;
        _healthText.text = $"Player HP = {_healthAmount.ToString()}";
        #region if we wanted to create canvas & TextMeshPro programatically
        /*
        // create Canvas programatically
        _canvas = new GameObject();
        _canvas.name = "HealthDisplay";
        _canvas.AddComponent<Canvas>();

        // create text content programatically
        _health = new GameObject();
        _health.transform.parent = _canvas.transform;
        _health.name = "Health Status";

        // set text content
        _healthText = _health.AddComponent<TextMeshPro>();
        _healthText.text = _healthAmount.ToString();
        _healthText.fontSize = 12;
        */
        #endregion
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
