using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;


public class OptionMenu : Menu
{
    public List<string> sceneList = new List<string>();
   
    public Button btnLevel_1;
    public Button btnLevel_2;
    public MainMenu mainMenu;
      
    // Start is called before the first frame update
    void Start()
    {
      BackButtonHandler(Hide);
    }

    private void LoadLevel(string scene)
    {
        SceneManager.LoadScene(scene);
    }
    private void ShowLevelMenu()
    {
        base.Hide();

    }

    public void LoadMainMenu()
    {
        Hide();
    }

    public override void Hide()
    {
       base.Hide();
        mainMenu.Show();

    }

    public override void Show()
    {
        base.Show();
    }

      
}
