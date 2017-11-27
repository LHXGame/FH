using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour {
    private static CursorManager _instance;
    private Vector2 hotpoint = Vector2.zero; //UI坐标，0 0代表鼠标指针的热点区域为
    private bool isCurLockTarget = false;

    public Texture2D cursor_normalup;
    public Texture2D cursor_normaldown;


    public static CursorManager Instance()
    {
        return _instance;
    }
    void Awake()
    {
        _instance = this;
        SetCursorNormalUp();
    }

    public void SetCursorNormalUp()
    {
        Cursor.SetCursor(cursor_normalup, hotpoint, CursorMode.Auto);
    }
    
    
}
