using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartButtonGroup : MonoBehaviour {

    private Button singlePlayerModeButton;
    private Button tutorialButton;
    private Button exitGameButton;
    private Button achievementButton;
    private Button creditsButton;
    private Button settingsButton;
    private Button customGameModeButton;

    void Awake()
    {
        singlePlayerModeButton = transform.Find("SinglePlayerModeButton").GetComponent<Button>();
        tutorialButton = transform.Find("TutorialButton").GetComponent<Button>();
        exitGameButton = transform.Find("ExitGameButton").GetComponent<Button>();
        achievementButton = transform.Find("AchievementButton").GetComponent<Button>();
        creditsButton = transform.Find("CreditsButton").GetComponent<Button>();
        settingsButton = transform.Find("SettingsButton").GetComponent<Button>();
        customGameModeButton = transform.Find("CustomGameModeButton").GetComponent<Button>();
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

    }

    private void onCustomGameModeButtonClick()
    {

    }
}
