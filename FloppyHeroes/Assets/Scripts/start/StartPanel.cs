using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class StartPanel : BaseUIPanel {
    private Button singlePlayerModeButton;
    private Button tutorialButton;
    private Button exitGameButton;
    private Button achievementButton;
    private Button creditsButton;
    private Button settingsButton;
    private Button customGameModeButton;
    private Transform leftDg; //DoTween动画操作的左边物体
    private Transform rightDg; //DoTween动画操作的右边物体
    private Tweener tweenerLeft;
    private Tweener tweenerRight;
    private CanvasGroup canvasGroup;

    void Awake()
    {
        singlePlayerModeButton = transform.Find("ButtonGroup/SinglePlayerModeButton").GetComponent<Button>();
        tutorialButton = transform.Find("ButtonGroup/TutorialButton").GetComponent<Button>();
        exitGameButton = transform.Find("ButtonGroup/ExitGameButton").GetComponent<Button>();
        achievementButton = transform.Find("ButtonGroup/AchievementButton").GetComponent<Button>();
        creditsButton = transform.Find("ButtonGroup/CreditsButton").GetComponent<Button>();
        settingsButton = transform.Find("ButtonGroup/SettingsButton").GetComponent<Button>();
        customGameModeButton = transform.Find("ButtonGroup/CustomGameModeButton").GetComponent<Button>();
        leftDg = transform.Find("LeftDg");
        rightDg = transform.Find("RightDg");
        canvasGroup = transform.GetComponent<CanvasGroup>();
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
    /// 注册按钮回调事件
    /// </summary>
    private void addListener()
    {
        singlePlayerModeButton.onClick.AddListener(onSinglePlayerModeButtonClick);
        tutorialButton.onClick.AddListener(onTutorialButtonClick);
        exitGameButton.onClick.AddListener(onExitGameButtonClick);
        achievementButton.onClick.AddListener(onAchievementButtonClick);
        creditsButton.onClick.AddListener(onCreditsButtonButtonClick);
        settingsButton.onClick.AddListener(onSettingsButtonClick);
        customGameModeButton.onClick.AddListener(onCustomGameModeButtonClick);
    }

    private void onSinglePlayerModeButtonClick()
    {

    }

    private void onTutorialButtonClick()
    {

    }

    private void onExitGameButtonClick()
    {
        Application.Quit();
    }

    private void onAchievementButtonClick()
    {

    }

    private void onCreditsButtonButtonClick()
    {

    }

    private void onSettingsButtonClick()
    {
        dgTweenCallback(UIPanelType.settingPanel,false);
    }

    private void onCustomGameModeButtonClick()
    {

    }

    /// <summary>
    /// DoTween动画并加载场景
    /// </summary>
    private void dgTweenCallback(UIPanelType uiPanelType,bool select)
    {
        //tweenerLeft = leftDg.DOLocalMoveX(330, 2).OnComplete(() => { tweenerLeft.PlayBackwards });//暂无效果
        tweenerLeft = leftDg.DOLocalMoveX(330,2).OnComplete(()=> { leftDg.DOLocalMoveX(0, 2); });
        tweenerRight = rightDg.DOLocalMoveX(-330, 2).OnComplete(()=> { rightDg.DOLocalMoveX(0, 2).OnComplete(()=> { onPushOrPopPanel(uiPanelType,select); }); });
    }

    /// <summary>
    /// 加载或者弹出面板,false为Push，true为Pop
    /// </summary>
    private void onPushOrPopPanel(UIPanelType uiPanelType,bool select)
    {
        if (select == false)
            uiMng.PushPanel(uiPanelType);
        else
            uiMng.PopPanel();
    }
}
