using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// should maybe make a level loader later idk
using UnityEngine.SceneManagement;


public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public int overTimeDamageAmount = 20;

    public Healthbar healthbar;

    public GameObject youDied;

    void Start()
    {
        currentHealth = maxHealth;
        healthbar.SetMaxHealth(maxHealth);
        DamageOverTime(overTimeDamageAmount);
        Time.timeScale = 1;
    }

    void Update()
    {
        //just for bug testing
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(20);
        }

        if (currentHealth <= 0)
        {
            youDied.SetActive(true);
            Time.timeScale = 0;
        }
    }
    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthbar.SetHealth(currentHealth);
    }
    public void AddHealth(int health)
    {
        currentHealth += health;
        healthbar.SetHealth(currentHealth);
    }

    public void DamageOverTime(int damage)
    {
        StartCoroutine(DamageOverTimeCoroutine(damage));
    }

    IEnumerator DamageOverTimeCoroutine(int damage)
    {
        //there's some sort of bug where healthbar goes over 100, but I'll fix that later.
        //should this be a smooth transition or a hash one? like adding decimals to the subtraction.
        while (maxHealth > 0)
        {
        TakeDamage(damage);
        healthbar.SetHealth(currentHealth);
        yield return new WaitForSeconds(1f);
        }
    }

    public void ReloadLevel()
    {
        youDied.SetActive(false);
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
