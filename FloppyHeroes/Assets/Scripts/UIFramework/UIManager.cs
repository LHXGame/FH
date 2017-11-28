using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager
{
    //UIPanel类型对应的路径
    private Dictionary<UIPanelType, string> uiPathDict;
    //保存实例化出来的UIPanel
    private Dictionary<UIPanelType, GameObject> uiPanelDict;
    //保存UIPanel先后顺序的栈
    private Stack<GameObject> uiPanelStack;

    private Transform canvasTransform;
    private Transform CanvasTransform
    {
        get
        {
            if(canvasTransform == null)
            {
                canvasTransform = GameObject.Find("Canvas").transform;
            }
            return canvasTransform;
        }
    }
   

    public void Init()
    {
        parseUIPanelJsonFile();
        uiPanelDict = new Dictionary<UIPanelType, GameObject>();
        uiPanelStack = new Stack<GameObject>();
    }

    //解析json数据的内部类
    private class UIPanelJsonInfoClass
    {
        public List<UIPanelJsonInfo> infoList;
    }

    /// <summary>
    /// 解析UIPanelJson文件，Json文件记录了UIPanel的路径信息
    /// </summary>
    private void parseUIPanelJsonFile()
    {
        uiPathDict = new Dictionary<UIPanelType, string>();

        TextAsset ta = Resources.Load<TextAsset>("UIPanelJsonFile/UIPanelJsonFile");

        //返回一个json对象
        UIPanelJsonInfoClass jsonObject = JsonUtility.FromJson<UIPanelJsonInfoClass>(ta.text);
        
        if(jsonObject == null)
        {
            Debug.LogWarning("解析json出错!");
        }
        else
        {
            foreach (var info in jsonObject.infoList)
            {
                uiPathDict.Add(info.panelEnumType, info.path);
            }
        }       
    }

    /// <summary>
    /// UIPanel进栈
    /// </summary>
    public void PushPanel(UIPanelType panelType)
    {
        GameObject uipanelGo = getPanelFromDict(panelType);
        if(uipanelGo != null)
        {
            //进栈前判断栈是否空
            if(uiPanelStack.Count > 0)
            {
                //栈顶的UIPanel暂停
                uiPanelStack.Peek().GetComponent<BaseUIPanel>().Pause();

            }
            uiPanelStack.Push(uipanelGo);
            uipanelGo.GetComponent<BaseUIPanel>().Enter();
        }
    }

    /// <summary>
    /// UIPanel出栈
    /// </summary>
    public void PopPanel()
    {
        if (uiPanelStack.Count > 0)
        {
            //栈顶的UIPanel 退出
            uiPanelStack.Peek().GetComponent<BaseUIPanel>().Exit();
            uiPanelStack.Pop();
            //Pop完，恢复当前栈顶的UIPanel
            if(uiPanelStack.Count > 0)
            {
                uiPanelStack.Peek().GetComponent<BaseUIPanel>().Resume();
            }
        }
    }

    /// <summary>
    /// 从字典中获取UIPanel，如果UIPanel不存在，则实例化,如果路径不存在(json文件路径没写错不会出现)，就会返回空
    /// </summary>
    private GameObject getPanelFromDict(UIPanelType panelType)
    {
        GameObject uiPanelGo = null;
        uiPanelDict.TryGetValue(panelType, out uiPanelGo);
        if(uiPanelGo == null)
        {
            string uiPanelPath;
            uiPathDict.TryGetValue(panelType, out uiPanelPath);
            if (string.IsNullOrEmpty(uiPanelPath)) return null;
            GameObject uiPanelPrefab = Resources.Load<GameObject>(uiPanelPath);
            GameObject newuiPanelGo = GameObject.Instantiate(uiPanelPrefab);
            newuiPanelGo.name = uiPanelPrefab.name;
            newuiPanelGo.transform.SetParent(CanvasTransform,false);
            uiPanelDict.Add(panelType, newuiPanelGo);
            newuiPanelGo.GetComponent<BaseUIPanel>().SetUIMng(this);
            return newuiPanelGo;
        }
        else
        {
            return uiPanelGo;
        }
    }
}
