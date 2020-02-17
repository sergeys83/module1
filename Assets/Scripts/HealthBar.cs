using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public TextMeshProUGUI textField;
    Health health;
    float displayedHelth;
    // Start is called before the first frame update
    void Start()
    {
        health = GetComponent<Health>();
        displayedHelth = health.current - 1f;
    }

    // Update is called once per frame
    void Update()
    {
        float value = health.current;
        if (Mathf.Abs(displayedHelth-value)>=0.000001f)
        {
            displayedHelth = value;
            textField.text = $"{value}";
        }
    }
}
