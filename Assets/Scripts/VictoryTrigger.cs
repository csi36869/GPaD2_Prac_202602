using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;

public class VictoryTrigger : MonoBehaviour
{
    [SerializeField] GameObject gameOverPopup;
    [SerializeField] int enemyShotTarget = 5;

    [SerializeField] UIController uiController;
    [SerializeField] TMP_Text monitorText;

    private void OnTriggerEnter(Collider other)
    {
        if (uiController.GetScore() >= enemyShotTarget)
        {
            GameOverPopup popup = gameOverPopup.GetComponent<GameOverPopup>();
            popup.SetTitle("Congratulations");
            popup.SetMessage("You Escaped!");
            gameOverPopup.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            monitorText.text = "Left " + (enemyShotTarget - uiController.GetScore());
        }
    }

}
