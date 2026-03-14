using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    private int health;
    void Start()
    {
        health = 5;
    }
    public void Hurt(int damage)
    {
        health -= damage;
        Debug.Log($"Health: {health}");
    }

    public void Heal(int healAmt)
    {
        health += healAmt;
        Debug.Log($"Health: {health}");
    }
}
