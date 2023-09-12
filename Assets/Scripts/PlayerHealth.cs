using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using DG.Tweening;


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
        gameOverCanvas.SetActive(false);
        inGameCanvas.SetActive(true);
    }

    void Update()
    {

        if (currentHealth <= 0)
        {
            gameOverCanvas.SetActive(true);
            inGameCanvas.SetActive(false);
            finalText.text = "You got " + score.scoretext.text + " up the stream!";

            if (PlayerCollisionHandler.currentCollision == null)
            {
                deathCauseText.text = "You died of hunger!";

            }
            else
            {
            deathCauseText.text = "You died of " + PlayerCollisionHandler.currentCollision + "!";
            }
            Time.timeScale = 0;
        }

    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthbar.SetHealth(currentHealth);
    }
    public void AddHealth(int health)
    {
        currentHealth += health;

        if (currentHealth >= maxHealth)
        {
            currentHealth = maxHealth;
        }

        healthbar.SetHealth(currentHealth);
    }

    public void DamageOverTime(int damage)
    {
        StartCoroutine(DamageOverTimeCoroutine(damage));
    }

    IEnumerator DamageOverTimeCoroutine(int damage)
    {
        while (maxHealth > 0)
        {
        TakeDamage(damage);
        healthbar.SetHealth(currentHealth);
        yield return new WaitForSeconds(waitBeforeDamage);
        }
    }

    /*
    IEnumerator Die()
    {
        Time.timeScale = 0.3f;
        yield return new WaitForSeconds(0.3f);
        gameOverCanvas.SetActive(true);
        inGameCanvas.SetActive(false);
        finalText.text = "You got " + score.scoretext.text + " up the stream!";
        deathCauseText.text = "You died of " + PlayerCollisionHandler.currentCollision + "!";
        //bug: dosen't seem to do timescale 0 at this point - gonna fix later.
        Time.timeScale = 0;
    }
    */

    public void ReloadLevel()
    {
        gameOverCanvas.SetActive(false);
        DOTween.Clear(true);
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
