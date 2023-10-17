using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CountdownTimer : MonoBehaviour
{
    public float initialCountdownTime = 31.0f;
    public TextMeshProUGUI textMeshPro;
    public Image fillImage;
    private float countdownTime;
    private bool isPaused = false;

    private void Start()
    {
        // textMeshPro = GetComponent<TextMeshProUGUI>();
        countdownTime = initialCountdownTime;
        UpdateCountdownText();
    }

   private void Update()
    {        
        if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Alpha4) || Input.GetKeyDown(KeyCode.Alpha5)){
            countdownTime = initialCountdownTime;
            UpdateCountdownText();
        }

        if (Input.GetKeyDown(KeyCode.Alpha6)) {
            if (isPaused)
            {
                isPaused = false;
            }
            else
            {
                isPaused = true;
            }
        }

        if (countdownTime <= 0) {
            countdownTime = 0;
            UpdateCountdownText();
        }
        else if (!isPaused) {
            countdownTime -= Time.deltaTime;
            UpdateCountdownText();
        }        
    }

    private void UpdateCountdownText()
    {
        int seconds = Mathf.FloorToInt(countdownTime);
        textMeshPro.text = seconds.ToString();
        float fillAmount = countdownTime / initialCountdownTime;
        fillImage.fillAmount = fillAmount;
    }
}
