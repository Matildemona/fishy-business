using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// should maybe make a level loader later idk
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    int currentHealth;

    [Header("Healthbar Settings")]
    [Tooltip("Maximum amount of health.")]
    public int maxHealth = 100;
    [Tooltip("How much damage to loose each time.")]
    public int overTimeDamageAmount = 20;
    [Tooltip("How long before more damage should be taken.")]
    public float waitBeforeDamage = 1f;

    [Header("Scripts")]
    public Healthbar healthbar;

    public GameObject gameOverCanvas;
    public GameObject inGameCanvas;

    public TMP_Text finalText;
    public TMP_Text deathCauseText;

    public Score score;


    void Start()
    {
        currentHealth = maxHealth;
        healthbar.SetMaxHealth(maxHealth);
        DamageOverTime(overTimeDamageAmount);
        Time.timeScale = 1;
    }

    void Update()
    {

        if (currentHealth <= 0)
        {
            gameOverCanvas.SetActive(true);
            inGameCanvas.SetActive(false);
            finalText.text = "You got " + score.scoretext.text + " up the stream!"; 
            deathCauseText.text = "You died of " + PlayerCollisionHandler.currentCollision + "!";
            Time.timeScale = 0;
        }

        //If player collided with "death cause" and it has 0 health: death cause "insert death cause".
        //Death Causes: Starved, Eaten(bird, fish), Poison, Human, contamination, plastic fork(tin can, bottle cap).

    }
    public void TakeDamage(int damage)
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
        yield return new WaitForSeconds(waitBeforeDamage);
        }
    }

    public void ReloadLevel()
    {
        gameOverCanvas.SetActive(false);
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
