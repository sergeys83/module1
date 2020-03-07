
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class SummaryMenu : Menu
{
    private Scene currentScene;
    public TMP_Text winStr;
    public string mainmenu;
    public Image winImage;
    public string winString = "ПОБЕДА";
    public string loseString = "ПОРАЖЕНИЕ";
    public UIBattle uiBattle;
    public Button nextLevel;
    public string nextLvl;

    // Start is called before the first frame update
    void Start()
    {
        currentScene = SceneManager.GetActiveScene();
        if (string.IsNullOrEmpty(nextLvl))
        {
            nextLevel.interactable = false;
        }
        else
        {
            nextLevel.onClick.AddListener(NextLevel);
        }
        
        BackButtonHandler(LoadMainMenu);
    }

    private void Restart()
    {
        Time.timeScale = 1;
        
        //СДЕЛАТЬ КОРУТИНУ СЦЕНЛОАДЕР В ГЛАВНОМ ММЕНЮ
        
        currentScene = SceneManager.GetActiveScene();
        SceneManager.UnloadSceneAsync(currentScene.buildIndex);
        SceneManager.LoadScene(currentScene.name,LoadSceneMode.Additive);
    }

    public void NextLevel()
    {
        Hide();
        SceneLoad.sl.LoadLevel(nextLvl);
    }
    public void LoadMainMenu()
    {
        Hide();
        SceneLoad.sl.UnLoadLevel(currentScene.name);
    }
 
   public void SetResult(bool winner)
    {
        base.Show();
        uiBattle.DeactivateUI();

        if (winner)
        {
            winStr.text = winString;
            winImage.gameObject.SetActive(true);
        }
        else
        {
            nextLevel.interactable = false;
            winStr.text = loseString;
            winStr.color = Color.red;
            winImage.gameObject.SetActive(false);
        }
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
