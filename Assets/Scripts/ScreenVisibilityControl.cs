using UnityEngine;
using UnityEngine.UI;

public class ScreenVisibilityControl : MonoBehaviour
{
    public Image failImage;
    public Image successImage;

    private void Start()
    {
        failImage.enabled = false;
        successImage.enabled = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            failImage.enabled = true; 
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            successImage.enabled = true; 
        }
        if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Alpha4) || Input.GetKeyDown(KeyCode.Alpha5) || Input.GetKeyDown(KeyCode.Return))
        {
            failImage.enabled = false; 
            successImage.enabled = false; 
        }
    }
}
