using System;
using System.Collections.Generic;
using UnityEngine;

public interface IMenu 
{
    void Show();
    void Hide();
    void BackButtonHandler(Action onBack);
}
