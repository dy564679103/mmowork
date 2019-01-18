﻿using Models;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Managers;

public class UIMinimap : MonoBehaviour
{
    [SerializeField]
    private Collider minimapBoundingBox;

    [SerializeField]
    private Image minimap;

    [SerializeField]
    private Image arrow;

    [SerializeField]
    private Text mapName;

    Transform playerTransform;

    void Start()
    {
        this.InitMap();

        //User.Instance.CurrentMapData.Resource;
    }

    void InitMap()
    {
        this.mapName.text = User.Instance.CurrentMapData.Name;
        if (this.minimap.overrideSprite == null)
        {
            this.minimap.overrideSprite = MinimapManager.Instance.LoadCurrentMinimap();
        }
        this.minimap.SetNativeSize();
        this.minimap.transform.localPosition = Vector3.zero;

        this.playerTransform = User.Instance.CurrentCharacterObject.transform;
    }

    void Update1()
    {
        float realWidth = minimapBoundingBox.bounds.size.x;
        float realHeight = minimapBoundingBox.bounds.size.z;

        float relativeX = playerTransform.position.x - minimapBoundingBox.bounds.min.x;
        float relativeY = playerTransform.position.z - minimapBoundingBox.bounds.min.z;

        float pivotX = relativeX / realWidth;
        float pivotY = relativeY / realHeight;

        this.minimap.rectTransform.pivot = new Vector2(pivotX, pivotY);
        this.minimap.rectTransform.localPosition = Vector2.zero;

        this.arrow.transform.eulerAngles = new Vector3(0, 0, playerTransform.eulerAngles.y);
    }
}
