using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAmountBombs : MonoBehaviour
{
    [SerializeField] private Text AmountBomb;

    private Image AmountBombImage;

    public int CurrentAmountBombs;

    PlayerControll Player;

    void Start()
    {    
        Player = FindObjectOfType<PlayerControll>();
        //AmountBomb = GetComponent<Text>();
       // CurrentAmountBombs = Player._bombsPl;
    }

    void Update()
    {
        CurrentAmountBombs = Player._bombsPl;
        AmountBomb.text = CurrentAmountBombs.ToString() + " bombs ";
    }
}
