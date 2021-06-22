using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ZombieHealth : MonoBehaviour
{

    public float startHealth = 100f;
    private float currentHealth;
    public Slider healthBar;

    public GameObject healthBarUI;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = startHealth;
        healthBar.value = calculateHealth();
    }
    void Update()
    {
        if (currentHealth < startHealth)
        {
            healthBarUI.SetActive(true);
        }
        healthBar.value = calculateHealth();
    }
    public int GetHealth() { return ((int)currentHealth); }
    public void Hit(int damage)
    {
        currentHealth -= damage;

        if (currentHealth < 0)
        {
            currentHealth = 0;
            //TODO: Zombiyi Öldür.
            Debug.Log("Zombie Öldü");
        }
        Debug.Log("Zombi hasar aldı" + currentHealth);

    }

    float calculateHealth()
    {
        return currentHealth / startHealth;
    }

}
