using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour , IMenu
{
    public Button backButton;

    public virtual void Show()
    {
        this.gameObject.SetActive(true);
    }
    public virtual void Hide()
    {
        this.gameObject.SetActive(false);
    }

    public virtual void BackButtonHandler(Action onBack)
    {
        backButton.onClick.AddListener(() => onBack());
    }


}
