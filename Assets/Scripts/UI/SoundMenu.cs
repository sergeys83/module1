using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SoundMenu : Menu
{
   // public Button PlayButton;
   public Text textSound;
   public Text textVfx;
   
    public Slider soundSlider;
    public Slider vfxSlider;
    
    public void Awake   ()
    {
        BackButtonHandler(Hide);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Hide()
    {
        base.Hide();
        var optionMenu = GameObject.Find("Options").GetComponent<OptionMenu>();
        optionMenu.Show();
        Debug.Log("HELLO");
    }
   
}
