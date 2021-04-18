using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject mainPanel;
    [SerializeField] private GameObject optionsPanel;

    [SerializeField] private Button btnStart;
    [SerializeField] private Button btnMain;
    [SerializeField] private Button btnOptions;
    [SerializeField] private Button btnExit;

    private void Awake()
    {
        btnStart.onClick.AddListener(StartGame);
        btnMain.onClick.AddListener(ShowMain);
        btnOptions.onClick.AddListener(ShowOptions);
        btnExit.onClick.AddListener(ExitGame);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void ShowMain()
    {
        mainPanel.SetActive(true);
        optionsPanel.SetActive(false);
    }
    public void ShowOptions()
    {
        optionsPanel.SetActive(true);
        mainPanel.SetActive(false);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
