using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class CountDownStart : MonoBehaviour
{

    [SerializeField] TMP_Text readyText;
    [SerializeField] TMP_Text setText;
    [SerializeField] TMP_Text goText;
    [SerializeField] Canvas countDownCanvas;
    [SerializeField] Canvas inGameCanvas;
    [SerializeField] AudioManager audioManager;
    [SerializeField] PlayerRigMovement playerRigMovement;
    [SerializeField] PlayerHealth playerHealth;
    [SerializeField] PlayerControls playerControls;

    void Start()
    {
        setText.enabled = false;
        goText.enabled = false;
        StartCoroutine(CountDownCanvas());
    }

    public IEnumerator CountDownCanvas()
    {
        inGameCanvas.enabled = false;
        playerRigMovement.enabled = false;
        playerHealth.enabled = false;
        playerControls.enabled = false;
        readyText.enabled = false;
        yield return new WaitForSeconds(0.5f);
        readyText.enabled = true;

        AudioManager.Instance.PlaySFX(audioManager.readysetSFX);
        yield return new WaitForSeconds(1);
        readyText.enabled = false;
        setText.enabled = true;
        AudioManager.Instance.PlaySFX(audioManager.readysetSFX);
        yield return new WaitForSeconds(1);
        setText.enabled = false;
        goText.enabled = true;
        AudioManager.Instance.PlaySFX(audioManager.goSFX);
        yield return new WaitForSeconds(1);
        Time.timeScale = 1;
        countDownCanvas.enabled = false;
        playerRigMovement.enabled = true;
        playerHealth.enabled = true;
        playerControls.enabled = true;
        inGameCanvas.enabled = true;
    }
}
