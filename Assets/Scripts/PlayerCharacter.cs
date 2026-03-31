using UnityEngine;
using UnityEngine.UI;

public class PlayerCharacter : MonoBehaviour
{
    private int health;
    [SerializeField] int maxHealth=5;
    [SerializeField] Image healthBar;
    void Start()
    {
        health = maxHealth;
    }
    public void Hurt(int damage)
    {
        if (health > 0) { 
            health -= damage;
            healthBar.transform.localScale = new Vector3(health / (float)maxHealth, 1, 1);
            //Debug.Log($"Health: {health}");
        }
    }

    public void Heal(int healAmt)
    {
        if (health < maxHealth)
        {
            health += healAmt;
            healthBar.transform.localScale = new Vector3(health / (float)maxHealth, 1, 1);
            //Debug.Log($"Health: {health}");
        }
    }
}
