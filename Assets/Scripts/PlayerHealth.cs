using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public int overTimeDamageAmount = 20;

    public Healthbar healthbar;

    void Start()
    {
        currentHealth = maxHealth;
        healthbar.SetMaxHealth(maxHealth);
        DamageOverTime(overTimeDamageAmount);
    }

    void Update()
    {
        //just for bug testing
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(20);
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
        while (maxHealth > 0)
        {
        TakeDamage(damage);
        healthbar.SetHealth(currentHealth);
        yield return new WaitForSeconds(1f);
        }
    }
}
