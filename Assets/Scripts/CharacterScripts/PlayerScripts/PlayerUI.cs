using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] private Text HealthText;
    [SerializeField] private Text AmountAmmoText;
    [SerializeField] private Text AmountBombText;
    private Image HealthBar;

    public float CurrentHealth;
    public int CurrentAmmoBullets;
    public int CurrentAmountBombs;

    private float MaxHealth = 100f;

    PlayerControll Player;

    private void Awake()
    {
        AmountAmmoText = GetComponent<Text>();
        AmountBombText = GetComponent<Text>();
        HealthText = GetComponent<Text>();
        HealthBar = GetComponent<Image>();
        Player = FindObjectOfType<PlayerControll>();
    }

    void Start()
    {

        CurrentHealth = Player._hpPl;
        CurrentAmmoBullets = Player._bulletsPl;
        CurrentAmountBombs = Player._bombsPl;
    }
    /*
    private Texture2D texture2D;
    private Sprite sprite;
    void Start()
    {
    texture2D = Resources.Load<Texture2D>("CoinImage");
    sprite = Sprite.Create(texture2D, new
    Rect(0,0,texture2D.width,texture2D.height), new Vector2(0.5f, 0.5f));
    GetComponent<Image>().sprite = sprite;
    }

    */

     void Update()
    {
        CurrentHealth = Player._hpPl;
        CurrentAmmoBullets = Player._bulletsPl;
        CurrentAmountBombs = Player._bombsPl;
        HealthBar.fillAmount = CurrentHealth / MaxHealth;
        HealthText.text = CurrentHealth.ToString() + " %";
        AmountAmmoText.text = CurrentAmmoBullets.ToString();
        AmountBombText.text = CurrentAmountBombs.ToString();
    }
}
