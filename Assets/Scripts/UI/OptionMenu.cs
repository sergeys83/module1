using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;


public class OptionMenu : Menu
{
    public Button sound;
    public Button other;
    public MainMenu mainMenu;
    public SoundMenu soundMenu;
      
    // Start is called before the first frame update
    void Start()
    {
        sound.onClick.AddListener(ShowSoundMenu);
        BackButtonHandler(Hide);
    }

   private void ShowSoundMenu()
   {
        soundMenu.Show();
        base.Hide();

    }

    public override void Hide()
    {
       base.Hide();
        mainMenu.Show();

    }
      
}
