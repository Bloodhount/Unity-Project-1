using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject gameMenu;

    [SerializeField] private Button btnMain;
    [SerializeField] private Button btnExit;

    //private void Awake()
    //{
    //    gameMenu.SetActive(false);
    //}

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            gameMenu.SetActive(!gameMenu.activeSelf);
        }
    }
}
