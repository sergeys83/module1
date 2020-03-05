using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoad : MonoBehaviour
{
    public static SceneLoad sl;
    private Scene currentScene;
    public GameObject menu;
    
    // Start is called before the first frame update
    private void Awake()
    { 
        sl = this;
        
        DontDestroyOnLoad(sl);
    }

    void Start()
    {
        currentScene = SceneManager.GetActiveScene();

    }

    public void LoadLevel(string scene=null)
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
        SceneManager.SetActiveScene(curScene);
        Debug.Log("SCENE LOADED: " + sceneName);
   
    }
    
    public void UnLoadLevel(string scene=null)
    {
        AsyncOperation task = SceneManager.UnloadSceneAsync(scene);
       
        task.allowSceneActivation=true;
        StartCoroutine(SceneUnload(task,scene));
        Debug.Log("SCENE LOADED: " + scene);
     
        menu.SetActive(true);
        menu.GetComponentInChildren<MainMenu>().Show();
    }
    
    IEnumerator SceneUnload(AsyncOperation response, string sceneName)
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
