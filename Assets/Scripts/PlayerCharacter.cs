using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;

public class PlayerCharacter : MonoBehaviour
{
    private int health;
    [SerializeField] int maxHealth;

    [SerializeField] Image healthBar;
    [SerializeField] GameObject gameOverPopup;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = maxHealth;   
    }

    public void Hurt (int damage)
    {
        if (health > 0)
        {
            health -= damage;
            healthBar.transform.localScale = new Vector3(health / (float)maxHealth, 1, 1);
            Debug.Log($"Health: {health}");
            if(health == 0)
            {
                GameOverPopup popup = gameOverPopup.GetComponent<GameOverPopup>();
                popup.SetTitle("Game Over");
                popup.SetMessage("You Died!");
                gameOverPopup.SetActive(true);
                Time.timeScale = 0;
            }
        }
    }

    public void Heal (int heal)
    {
        if (!(health >= maxHealth || health <= 0))
        {
            health += heal;
            healthBar.transform.localScale = new Vector3(health / (float)maxHealth, 1, 1);
            Debug.Log($"Health: {health}");
        }
    }
}
