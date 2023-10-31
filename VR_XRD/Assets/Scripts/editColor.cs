using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class editColor : MonoBehaviour
{
    public Button button;
    private Color originalColor;
    public Color pressedColor;
    private void Start()
    {
        originalColor = button.colors.normalColor;

        // Lyt efter klikbegivenheden og tilknyt metoden ChangeColor til det.
        button.onClick.AddListener(ChangeColor);
    }

    private void OnTriggerEnter(Collider other)
    {
        ChangeColor();
    }

    private void ChangeColor()
    {
        // Ændr knappens farve til den ønskede farve (pressedColor).
        ColorBlock colors = button.colors;
        colors.normalColor = pressedColor;
        button.colors = colors;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
