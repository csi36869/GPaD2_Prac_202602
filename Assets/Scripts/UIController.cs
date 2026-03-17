using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using TMPro;


public class UIController : MonoBehaviour
{
    [SerializeField] TMP_Text scoreLabel;
    [SerializeField] SettingsPopup settingsPopup;
    void Start()
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
