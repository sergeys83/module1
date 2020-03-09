using System;
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
    public Action onMenuActivate;

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
       
        currentScene = SceneManager.GetActiveScene();
        SceneLoad.Instance.LoadLevel(currentScene.name);
    }

    public void LoadMainMenu()
    {
        Hide();
        SceneLoad.Instance.UnLoadLevel(currentScene.name);
       
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
        onMenuActivate.Invoke();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
