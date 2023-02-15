using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : HaoMonoBehaviour
{
    private static InputManager instance;
    [SerializeField] private Vector2 mousePosWorld;
    
    public static InputManager Instance { get => instance; }
    public  Vector3 MousePosWorld { get => mousePosWorld; }

    protected override void Awake()
    {
        if (InputManager.instance != null) Debug.LogError("only one InputManager exist");
        InputManager.instance = this;
        Cursor.visible = false;
    }

    protected void FixedUpdate()
    {
        this.GetMousePos();
    }

    protected void GetMousePos()
    {
        this.mousePosWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
