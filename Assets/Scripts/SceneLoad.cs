using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoad : Singleton<SceneLoad>
{
   
    private Scene currentScene;
    public GameObject menu;
    
    // Start is called before the first frame update
    protected override void Awake()
    { 
      DontDestroyOnLoad(this.gameObject);
    }

    public void LoadLevel(string scene=null)
    {
        currentScene = SceneManager.GetActiveScene();
        
        if (currentScene.buildIndex!=0)
        {
           UnLoadLevel(currentScene.name,scene);
           if (string.IsNullOrEmpty(scene))
           {
               menu.SetActive(false);
           
           }

        }
        
        AsyncOperation task = SceneManager.LoadSceneAsync(scene, LoadSceneMode.Additive);
       
        task.allowSceneActivation=true;
        StartCoroutine(SceneLoader(task,scene));
       
        SceneChanged msg = new SceneChanged(scene);
        EventManager.Instance.SendEvent(EventId.Scenechanged,msg);
    }

    IEnumerator SceneLoader(AsyncOperation response, string sceneName)
    {
        while (!response.isDone)
        {
            Debug.Log(response.progress);   //заменить на слайдер
            yield return null;
        }
        Scene curScene = SceneManager.GetSceneByName(sceneName);
        SceneManager.SetActiveScene(curScene);
        Debug.Log("SCENE LOADED: " + curScene.name);
   
    }
    
  //
    public void UnLoadLevel(string scene=null,string nextScene=null)
    {
        AsyncOperation task = SceneManager.UnloadSceneAsync(scene);
        task.allowSceneActivation=true;
        
        StartCoroutine(SceneUnload(task));
        
        Debug.Log("SCENE UnLOADED: " + scene);
        
        if (string.IsNullOrEmpty(nextScene))  //осталась только сцена с меню
        {
            menu.SetActive(true);
            
            SceneChanged msg = new SceneChanged(SceneManager.GetSceneAt(0).name);
            EventManager.Instance.SendEvent(EventId.Scenechanged,msg);
        }
        
    }
    
   
    IEnumerator SceneUnload(AsyncOperation response)
    {
        while (!response.isDone)
        {
            Debug.Log(response.progress);
            yield return null;
        }

        Scene curScene = SceneManager.GetSceneAt(0);
        SceneManager.SetActiveScene(curScene);
       
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
