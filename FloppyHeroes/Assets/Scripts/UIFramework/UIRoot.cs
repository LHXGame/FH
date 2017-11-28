using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIRoot : MonoBehaviour {
    void Awake()
    {
        UIManager uiMng = new UIManager();
        uiMng.Init();
        uiMng.PushPanel(UIPanelType.startPanel);
    }
}
