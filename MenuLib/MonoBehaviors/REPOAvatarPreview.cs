﻿using UnityEngine;
using UnityEngine.UI;

namespace MenuLib.MonoBehaviors;

public sealed class REPOAvatarPreview : REPOElement
{
    public bool enableBackgroundImage
    {
        get => backgroundImage.enabled;
        set => backgroundImage.enabled = value;
    }
    public Color backgroundImageColor
    {
        get => backgroundImage.color;
        set => backgroundImage.color = value;
    }
    
    private Image backgroundImage;

    private PlayerAvatarMenu playerAvatarMenu;
    
    private void Awake()
    {
        rectTransform = gameObject.AddComponent<RectTransform>();
        rectTransform.pivot = Vector2.right;
        rectTransform.anchorMin = rectTransform.anchorMax = Vector2.zero;
        rectTransform.sizeDelta = new Vector2(184f, 345f);

        playerAvatarMenu = GetComponentInChildren<PlayerAvatarMenuHover>().playerAvatarMenu;
        
        backgroundImage = gameObject.AddComponent<Image>();
        backgroundImage.enabled = false;
    }

    private void Start() => rectTransform.GetChild(0).localPosition = Vector3.zero;

    private void OnDestroy()
    {
        Destroy(playerAvatarMenu.cameraAndStuff.gameObject);
        Destroy(playerAvatarMenu.gameObject);
    }
}
