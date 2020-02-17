using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;



public class LevelMenu : Menu
{
    public List<SceneInit> sceneLoader = new List<SceneInit>();
    public MainMenu mainMenu;
    public string sceneName;
      
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < sceneLoader.Count; i++)
        {
            Debug.Log($"{sceneLoader[i].scene} ={sceneLoader.Count}  ");
            sceneLoader[i].init();
        }
     
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

    // Update is called once per frame
    void Update()
    {
        
    }

   
}
