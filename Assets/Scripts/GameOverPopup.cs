using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOverPopup : MonoBehaviour
{
    [SerializeField] TMP_Text titleText;
    [SerializeField] TMP_Text msgText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameObject.SetActive(false);
    }

    public void SetTitle(string msg)
    {
        titleText.text = msg;
    }

    public void SetMessage(string msg)
    {
        msgText.text = msg;
    }


    public void OnRestart()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(0);
    }
}
