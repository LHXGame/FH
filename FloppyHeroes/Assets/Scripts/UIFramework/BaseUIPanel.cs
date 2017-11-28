using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// UIPanel枚举类型
/// </summary>
public enum UIPanelType
{
    none,
    startPanel,
    settingPanel,
}


/// <summary>
/// UIPanel的基类，继承自MonoBehaviour,派生类作为组件挂载
/// </summary>
public class BaseUIPanel : MonoBehaviour
{
    protected UIManager uiMng;

    public void SetUIMng(UIManager uimanager)
    {
        uiMng = uimanager;
    }

    /// <summary>
    /// UI面板创建时调用
    /// </summary>
    public virtual void Enter()
    {

    }

    /// <summary>
    /// UI面板暂时时调用
    /// </summary>
    public virtual void Pause()
    {

    }

    /// <summary>
    /// UI面板恢复使用时调用
    /// </summary>
    public virtual void Resume()
    {

    }

    /// <summary>
    /// UI面板退出时调用
    /// </summary>
    public virtual void Exit()
    {

    }
}
