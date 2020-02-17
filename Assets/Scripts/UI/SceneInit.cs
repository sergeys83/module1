using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

[System.Serializable]
public class SceneInit
{
   public string scene;
   public Button btn;

   public void init()
    {
        btn.onClick.AddListener(() => SceneManager.LoadScene(scene));
    }
}


