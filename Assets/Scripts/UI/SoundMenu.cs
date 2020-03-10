using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;


[Serializable]
public class SoundSliderData
{
    public Slider VolumeSlider;
    public Text VolumeText;
    public string MixerName;
    private AudioMixer Mixer;

    public void SliderChanged(float volume)
    {
        Mixer.SetFloat(MixerName, volume);
        VolumeText.text = volume.ToString("F0");
    }

    public void Init(AudioMixer mixer)
    {
        Mixer = mixer;

        float currentBGVolume;
        Mixer.GetFloat(MixerName, out currentBGVolume);
        VolumeText.text = currentBGVolume.ToString("F0");
        VolumeSlider.value = currentBGVolume;

        VolumeSlider.onValueChanged.AddListener(SliderChanged);
    }
}


public class SoundMenu : Menu
{
   // public Button PlayButton;
  
    public AudioMixer Mixer;
    public SoundSliderData[] SoundSettings;
    public void Awake   ()
    {
        BackButtonHandler(Hide);
        foreach (SoundSliderData soundSetting in SoundSettings)
            soundSetting.Init(Mixer);
    }
    
    public override void Hide()
    {
        base.Hide();
        var optionMenu = GameObject.Find("Options").GetComponent<OptionMenu>();
        optionMenu.Show();
        
    }
   
}

