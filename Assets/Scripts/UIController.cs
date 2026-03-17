using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    [SerializeField] TMP_Text scoreLabel;
    [SerializeField] SettingsPopup settingsPopup;

    private void Start()
    {
        settingsPopup.Close();
    }

    void Update()
    {
        scoreLabel.text = Time.realtimeSinceStartup.ToString();
    }
    public void OnOpenSettings()
    {
        settingsPopup.Open();
    }
}
