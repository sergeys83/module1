﻿
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : Menu
{
    public Button btnContinue;
    public Button btnReset;
    private Scene currentScene;
    public string mainmenu;
    public UIBattle uiBattle;

    // Start is called before the first frame update
    void Start()
    {
        currentScene = SceneManager.GetActiveScene();
        btnReset.onClick.AddListener(Restart);
        btnContinue.onClick.AddListener(Hide);
        BackButtonHandler(LoadMainMenu);
    }

    private void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(currentScene.name);
    }

    public void LoadMainMenu()
    {
        Hide();
        SceneManager.LoadScene(mainmenu);
    }

    public override void Hide()
    {
        Time.timeScale = 1;
        base.Hide();
        uiBattle.ActivateUI();
    }
    public override void Show()
    {
        Time.timeScale = 0;
        base.Show();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}