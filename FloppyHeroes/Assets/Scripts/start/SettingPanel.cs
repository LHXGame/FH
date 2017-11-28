using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class SettingPanel : BaseUIPanel{
    private CanvasGroup canvasGroup;
    private Button returnToMainMenuButton;
    private Transform leftDg; //DoTween动画操作的左边物体
    private Transform rightDg; //DoTween动画操作的右边物体
    private Slider musicVolumeSlider; //背景音乐声音大小

    void Awake()
    {
        canvasGroup = transform.GetComponent<CanvasGroup>();
        returnToMainMenuButton = transform.Find("returnToMainMenu").GetComponent<Button>();
        leftDg = transform.Find("LeftDg");
        rightDg = transform.Find("RightDg");
        musicVolumeSlider = transform.Find("musicVolumeSlider").GetComponent<Slider>();
        addListener();
    }

    public override void Enter()
    {
        //进来时的动画
        canvasGroup.alpha = 1;
        canvasGroup.blocksRaycasts = true;
    }


    public override void Pause()
    {
        Debug.Log("停止响应");
        //停止面板的所有响应
        canvasGroup.blocksRaycasts = false;
        //canvasGroup.interactable = false;
        // canvasGroup.alpha = 0;
    }

    public override void Resume()
    {
        //恢复面板的所有响应
        //停止面板的所有响应
        canvasGroup.blocksRaycasts = true;
        //canvasGroup.interactable = true;
        //canvasGroup.alpha = 1;
    }

    public override void Exit()
    {
        //退出动画
        canvasGroup.alpha = 0;
        canvasGroup.blocksRaycasts = false;
    }

    /// <summary>
    /// 注册按钮和滑动条回调事件
    /// </summary>
    private void addListener()
    {
        returnToMainMenuButton.onClick.AddListener(onReturnToMainMenuButtonClick);
        musicVolumeSlider.onValueChanged.AddListener(onMusicVolumeSilder);
    }

    /// <summary>
    /// 返回主菜单按钮回调
    /// </summary>
    private void onReturnToMainMenuButtonClick()
    {
        dgTweenCallback(UIPanelType.none,true);
    }

    /// <summary>
    /// 背景音乐滑动条回调
    /// </summary>
    private void onMusicVolumeSilder(float volume)
    {
        AudioManager.Instance.setMusicVolume(volume);
    }

    /// <summary>
    /// DoTween动画并加载场景
    /// </summary>
    private void dgTweenCallback(UIPanelType uiPanelType,bool select)
    {
        //tweenerLeft = leftDg.DOLocalMoveX(330, 2).OnComplete(() => { tweenerLeft.PlayBackwards });//暂无效果
        leftDg.DOLocalMoveX(330, 2).OnComplete(() => { leftDg.DOLocalMoveX(0, 2); });
        rightDg.DOLocalMoveX(-330, 2).OnComplete(() => { rightDg.DOLocalMoveX(0, 2).OnComplete(() => { onPushOrPopPanel(uiPanelType,select); }); });
    }

    /// <summary>
    /// 加载或者弹出面板,false为Push，true为Pop
    /// </summary>
    private void onPushOrPopPanel(UIPanelType uiPanelType, bool select)
    {
        if (select == false)
            uiMng.PushPanel(uiPanelType);
        else
            uiMng.PopPanel();
    }
}
