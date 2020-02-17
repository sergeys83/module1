
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

    // Start is called before the first frame update
    void Start()
    {
        currentScene = SceneManager.GetActiveScene();

        BackButtonHandler(LoadMainMenu);
    }

   
    public void LoadMainMenu()
    {
        Hide();
        SceneManager.LoadScene(mainmenu);
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
