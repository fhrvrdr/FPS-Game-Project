using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth;
    private int currentHealth;

    public Text healthDisplay;
    void Start()
    {
        currentHealth = maxHealth;
        healthDisplay.text = "Health: " + currentHealth.ToString();
    }

    public void DeductHealth(int damage)
    {
        currentHealth = currentHealth - damage;
        Debug.Log("Playerın Canı azaldı " + currentHealth);
        healthDisplay.text = "Health: " + currentHealth.ToString();
        if (currentHealth <= 0)
        {
            KillPlayer();
        }
    }

    private void KillPlayer()
    {
        print("Player Öldü");
        SceneManager.LoadScene(2);
    }

    public void AddHelth(int value)
    {

        currentHealth = currentHealth + value;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

}
