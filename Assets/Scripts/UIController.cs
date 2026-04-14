using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    [SerializeField] TMP_Text scoreLabel;
    [SerializeField] SettingsPopup settingsPopup;
    [SerializeField] SettingsPopup AudioSetting;
    [SerializeField] SettingsPopup gameOverPopup;
    [SerializeField] SettingsPopup victoryPopup;

    private int score;

    void OnEnable()
    {
        Messenger.AddListener(GameEvent.ENEMY_HIT, OnEnemyHit);
    }

    void OnDisable()
    {
        Messenger.RemoveListener(GameEvent.ENEMY_HIT, OnEnemyHit);
    }

    private void Start()
    {
        score = 0;
        scoreLabel.text = score.ToString();

        settingsPopup.Close();
        AudioSetting.Close();
        gameOverPopup.Close();
        victoryPopup.Close();
    }

    private void Update()
    {
        if (score == 5)
        {
            OnOpenVictoryPopup();
        }
    }

    public void OnOpenSettings()
    {
        settingsPopup.Open();
    }

    public void OnOpenAudioSettings()
    {
        AudioSetting.Open();
    }

    public void OnOpenGameOverPopup()
    {
        gameOverPopup.Open();
    }

    public void OnOpenVictoryPopup()
    {
        victoryPopup.Open();
    }

    private void OnEnemyHit()
    {
        score += 1;
        scoreLabel.text = score.ToString();
    }
}