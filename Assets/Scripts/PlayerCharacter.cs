using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCharacter : MonoBehaviour
{
    private int health;
    public int maxHealth;
    public Image healthbar;

    [SerializeField] UIController UI;

    private void Start()
    {
        health = maxHealth;
    }

    private void Update()
    {
        Die();
    }

    public void Hurt(int damage)
    {
        if (health > 0)
        { 
            health -= damage;
            healthbar.transform.localScale = new Vector3(health / (float)maxHealth, 1f, 1f);
            //Debug.Log($"Health: {health}");
        }
    }

    public void Heal(int healing)
    {
        if (health > 0)
        {
            health += healing;
            healthbar.transform.localScale = new Vector3(health / (float)maxHealth, 1f, 1f);
        }
    }

    public void Die()
    {
        if (health == 0)
        {
            UI.OnOpenGameOverPopup();
        }
    }
}
