using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;

public class PlayerCharacter : MonoBehaviour
{
    private int health;
    [SerializeField] int maxHealth;

    [SerializeField] Image healthBar;

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
