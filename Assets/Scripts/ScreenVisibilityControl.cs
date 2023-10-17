using UnityEngine;
using UnityEngine.UI;

public class ScreenVisibilityControl : MonoBehaviour
{
    public Image coverImage;

    private void Start()
    {
        coverImage.enabled = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            coverImage.enabled = true; 
        }
        if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Alpha4) || Input.GetKeyDown(KeyCode.Alpha5) )
        {
            coverImage.enabled = false; 
        }
    }
}
