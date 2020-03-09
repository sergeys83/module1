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
  
    // Start is called before the first frame update
    private void Awake()
    {
        foreach (var item in sceneLoader)
        {
            Debug.Log(item.scene);
            item.btn.onClick.AddListener(()=>
            {
                Hide();
                GameObject.Find("Menu").SetActive(false);
                SceneLoad.Instance.LoadLevel(item.scene);
            });
        }
    }
    void Start()
    {
        BackButtonHandler(Hide);
    }

    public override void Hide()
    {
       base.Hide();
        mainMenu.Show();

    }
  
    // Update is called once per frame
    void Update()
    {
        
    }

   
}
