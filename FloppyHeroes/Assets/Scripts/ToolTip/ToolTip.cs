using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToolTip : MonoBehaviour {

    private static ToolTip _instance;
    private Text toolTipText;
    public static ToolTip Instance()
    {
        return _instance;
    }

    void Awake()
    {
        _instance = this;
        toolTipText = GetComponent<Text>();
        gameObject.SetActive(false);
    }


    void Update()
    {
        Vector2 position;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(transform.parent.transform as RectTransform, Input.mousePosition, null, out position);
        transform.localPosition = position;
    }

    public void Show(string text)
    {
        gameObject.SetActive(true);
        transform.SetAsLastSibling();
        updateText(text);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    private void updateText(string text)
    {
        toolTipText.text = text;
    }
}
