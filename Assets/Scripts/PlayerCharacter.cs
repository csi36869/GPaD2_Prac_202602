using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class PlayerCharacter : MonoBehaviour
{
    private int health;
    private int heal;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = 5;   
    }

    public void Hurt (int damage)
    {
        health -= damage;
        Debug.Log($"Health: {health}");
    }

    public void Heal (int heal)
    {
        health += heal;
        Debug.Log($"Health: {health}");
    }
}
