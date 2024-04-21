using UnityEngine;

public class SettingsMenu : MonoBehaviour
{
    public GameObject soundButton;

    
    public void ToggleSoundButton()
    {
        soundButton.SetActive(!soundButton.activeSelf);
    }
}
