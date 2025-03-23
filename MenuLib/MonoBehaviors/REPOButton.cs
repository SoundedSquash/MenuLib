﻿using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MenuLib.MonoBehaviors;

public sealed class REPOButton : REPOElement
{
    public MenuButton menuButton;

    public TextMeshProUGUI labelTMP;

    [Obsolete("Update the button clicked event using the 'onClick' field rather than through the button")]
    public Button button;
    
    public Action onClick;
    
    private string currentText;
    
    public Vector2 GetLabelSize() => labelTMP.GetPreferredValues(); 
    
    private void Awake()
    {
        rectTransform = transform as RectTransform;
        button = GetComponent<Button>();
        menuButton = GetComponent<MenuButton>();
        labelTMP = GetComponentInChildren<TextMeshProUGUI>();
        
        button.onClick = new Button.ButtonClickedEvent();
        button.onClick.AddListener(() => onClick?.Invoke());
        
        Destroy(GetComponent<MenuButtonPopUp>());
    }

    private void Update()
    {
        if (labelTMP.text == currentText)
            return;

        rectTransform.sizeDelta = GetLabelSize();
        currentText = labelTMP.text;
    }
    
    private void OnTransformParentChanged() => REPOReflection.menuButton_ParentPage.SetValue(menuButton, GetComponentInParent<MenuPage>());
}