using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SettingsPopup : MonoBehaviour
{
    [SerializeField] Slider speedSlider;
    [SerializeField] Slider volumeSlider;
    [SerializeField] TMPro.TMP_InputField nameInputField;
    void Start()
    {
        speedSlider.value = PlayerPrefs.GetFloat("speed", 1);
        volumeSlider.value = PlayerPrefs.GetFloat("volume", 0.5f);
        nameInputField.text = PlayerPrefs.GetString("name", "Player1");
    }
    public void Open()
    {
        gameObject.SetActive(true);
    }
    public void Close()
    {
        gameObject.SetActive(false);
    }

    public void OnSubmitName(string name)
    {
        //Debug.Log(name);
        PlayerPrefs.SetString("name", name);
    }
    public void OnSpeedValue(float speed)
    {
        Debug.Log($"Speed: {speed}");
        PlayerPrefs.SetFloat("speed", speed);
        Messenger<float>.Broadcast(GameEvent.SPEED_CHANGED, speed);
    }

    public void OnVolumeValue(float volume)
    {
        Debug.Log($"Volume: {volume}");
        PlayerPrefs.SetFloat("volume", volume);
        
    }
}