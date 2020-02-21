﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBattle : MonoBehaviour
{
    public Button btnAttack;
    public Button btnPause;
    public Button btnNextTarget;
    public GameManager gm;
    public PauseMenu pause;
    // Start is called before the first frame update
    void Start()
    {
        btnAttack.onClick.AddListener(() =>gm.PlayerMove());
        btnPause.onClick.AddListener(DeactivateUI);
        btnNextTarget.onClick.AddListener(() => gm.SwitchCharacter());
    }

    public void DeactivateUI()
    {
        btnAttack.interactable = false;
        btnNextTarget.interactable = false;
        pause.Show();
    }
    public void ActivateUI()
    {
        btnAttack.interactable = true;
        btnNextTarget.interactable = true;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}