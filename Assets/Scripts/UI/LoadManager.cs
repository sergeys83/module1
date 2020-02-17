using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class LoadManager : MonoBehaviour, IPointerClickHandler
{
    List<GameObject> btnList = new List<GameObject>();
    
    public Button PlayButton;
    public void Awake   ()
    {
        PlayButton.onClick.AddListener(PlayGame);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayGame()
    {
        Debug.Log("HELLO");
    }
    private void SceneManage()
    {
        SceneManager.LoadScene(1);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        ((IPointerClickHandler)PlayButton).OnPointerClick(eventData);
    }
}
