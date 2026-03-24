using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SettingsPopup : MonoBehaviour
{
    [SerializeField] Slider speedSlider;
    [SerializeField] Slider volumeSlider;
    [SerializeField] TMP_InputField nameInputField;

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
        Debug.Log(name);
        PlayerPrefs.SetString("name", nameInputField.text);
    }

    public void OnSpeedValue(float speed)
    {
        PlayerPrefs.SetFloat("speed", speed);
        Messenger<float>.Broadcast(GameEvent.SPEED_CHANGED, speed);
    }

    public void OnVolumeValue(float volume)
    {
        PlayerPrefs.SetFloat("volume", volume);
        Messenger<float>.Broadcast(GameEvent.VOLUME_CHANGED, volume);
    }
}
