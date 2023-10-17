using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using System.Collections.Generic;

public class CountdownTimer : MonoBehaviour
{
    public float initialCountdownTime = 31.0f;
    public TextMeshProUGUI textMeshPro;
    public Image backImage;
    public Image fillImage;
    // public AudioClip tickSound;
    // public AudioSource audioSource;
    private float countdownTime;
    private bool isPaused = false;

    private void Start()
    {
        // textMeshPro = GetComponent<TextMeshProUGUI>();
        countdownTime = initialCountdownTime;
        UpdateCountdown();
    }

   private void Update()
    {   
        if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Alpha4) || Input.GetKeyDown(KeyCode.Alpha5)){
            countdownTime = initialCountdownTime;
            textMeshPro.gameObject.SetActive(true);
            fillImage.gameObject.SetActive(true);
            backImage.gameObject.SetActive(true);
            UpdateCountdown();
        }

        if (Input.GetKeyDown(KeyCode.Space)) {
            isPaused = !isPaused;
        }

        if (Input.GetKeyDown(KeyCode.Alpha0)) {
            HideCountdown();
        }

        if (countdownTime <= 0) {
            countdownTime = 0;
            UpdateCountdown();
        }
        else if (!isPaused) {
            countdownTime -= Time.deltaTime;
            // audioSource.PlayOneShot(tickSound);
            UpdateCountdown();
        }        
    }

    private void UpdateCountdown()
    {
        int seconds = Mathf.FloorToInt(countdownTime);
        textMeshPro.text = seconds.ToString();
        float fillAmount = countdownTime / initialCountdownTime;
        fillImage.fillAmount = fillAmount;
    }

    private void HideCountdown()
    {
        textMeshPro.gameObject.SetActive(false);
        fillImage.gameObject.SetActive(false);
        backImage.gameObject.SetActive(false);
    }
}
