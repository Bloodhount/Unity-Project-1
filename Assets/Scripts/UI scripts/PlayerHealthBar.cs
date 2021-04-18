using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{
    [SerializeField] private Text HealthText;

    private Image HealthBar;

    public float CurrentHealth;
    private float MaxHealth = 100f;

    PlayerControll Player;

    void Start()
    {
        HealthBar = GetComponent<Image>();
        Player = FindObjectOfType<PlayerControll>();
       // HealthText = GetComponent<Text>();
       // CurrentHealth = Player._hpPl;
    }

    void Update()
    {
        CurrentHealth = Player._hpPl;
        HealthBar.fillAmount = CurrentHealth / MaxHealth;
        HealthText.text = CurrentHealth.ToString() + " %";
        //HealthText.text = CurrentHealth.ToString() + " %";
    }
}
