using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;



public class LevelMenu : Menu
{
    public LevelMenu Instance;
    public List<SceneInit> sceneLoader = new List<SceneInit>();
    public MainMenu mainMenu;
    public string curScene, scene;

    // Start is called before the first frame update
    private void Awake()
    {
        foreach (var item in sceneLoader)
        {
            Debug.Log(item.scene);
            item.btn.onClick.AddListener(()=>LoadLevel(item.scene));
        }
    }
    void Start()
    {
            
        BackButtonHandler(Hide);
    }

    public void LoadLevel(string scene)
    {
        AsyncOperation task = SceneManager.LoadSceneAsync(scene, LoadSceneMode.Additive);
       
        task.allowSceneActivation=true;
        StartCoroutine(SceneLoader(task,scene));
       
    }

    IEnumerator SceneLoader(AsyncOperation response, string sceneName)
    {
        while (!response.isDone)
        {
            Debug.Log(response.progress);
            yield return null;
        }
        Scene curScene = SceneManager.GetSceneByName(sceneName);
        Debug.Log(curScene.name);
        SceneManager.SetActiveScene(curScene);
        Debug.Log("SCENE LOADED ^^" + sceneName);
        GameObject.Find("Menu").SetActive(false);
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
  /*  public override void Show()
    {
        base.Show();
    }
*/
    // Update is called once per frame
    void Update()
    {
        
    }

   
}
