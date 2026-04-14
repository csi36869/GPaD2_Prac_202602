using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsPopup : MonoBehaviour
{
    [SerializeField] MouseLook mouseLookPlayer;
    [SerializeField] MouseLook mouseLookCamera;
    [SerializeField] RayShooter rayShooter;

    public void Open()
    {
        gameObject.SetActive(true);
        Time.timeScale = 0.0f;
        mouseLookPlayer.enabled = false;
        mouseLookCamera.enabled = false;
        rayShooter.enabled = false;
    }

    public void Close()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1.0f;
        mouseLookPlayer.enabled = true;
        mouseLookCamera.enabled = true;
        rayShooter.enabled = true;
    }

    public void OnSubmitName(string name)
    {
        Debug.Log(name);
    }

    public void OnSpeedValue(float speed)
    {
        Messenger<float>.Broadcast(GameEvent.SPEED_CHANGED, speed);
    }

    public void Restart()
    {
        SceneManager.LoadScene("GameScene");
        Time.timeScale = 1.0f;
        mouseLookPlayer.enabled = true;
        mouseLookCamera.enabled = true;
        rayShooter.enabled = true;
    }
}
