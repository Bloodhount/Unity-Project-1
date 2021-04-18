using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAmountBullets : MonoBehaviour
{
    [SerializeField] private Text AmountAmmoText;

    private Image AmountBullettsImg;

    public int CurrentAmmoBullets;
    //private int MaxAmmoBullets = 30;

    PlayerControll Player;

    void Start()
    {
        AmountBullettsImg = GetComponent<Image>();
        Player = FindObjectOfType<PlayerControll>();
        //AmountAmmoText = GetComponent<Text>();
        //CurrentAmmoBullets = Player._bulletsPl;
    }

    void Update()
    {
        CurrentAmmoBullets = Player._bulletsPl;
        AmountAmmoText.text = CurrentAmmoBullets.ToString() + " bulletts";
        //AmountBullettsImg.fillAmount = CurrentAmmoBullets / MaxAmmoBullets;
        //AmountAmmoText.text = CurrentAmmoBullets.ToString();
    }
}
