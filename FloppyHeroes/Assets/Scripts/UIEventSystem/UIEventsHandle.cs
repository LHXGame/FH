using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIEventsHandle : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
{
    public string tipMessage;

    void Awake()
    {
        if (tipMessage == "")
            tipMessage = transform.name;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        ToolTip.Instance().Show(tipMessage);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        ToolTip.Instance().Hide();
    }
}