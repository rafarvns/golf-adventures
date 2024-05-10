using UnityEngine;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{
    public Slider volumeSlider;
    private float previousVolume = 1.0f;

    void Start()
    {
        previousVolume = PlayerPrefs.GetFloat("SavedVolume", 1.0f);
        volumeSlider.value = previousVolume;
        AudioListener.volume = previousVolume;

        volumeSlider.onValueChanged.AddListener(SetVolume);
    }

    public void SetVolume(float volume)
    {
        previousVolume = volume;
        AudioListener.volume = volume;
        PlayerPrefs.SetFloat("SavedVolume", volume);
    }

    public void ToggleSound()
    {
        if (AudioListener.volume > 0)
        {
            previousVolume = AudioListener.volume;
            AudioListener.volume = 0;
        }
        else
        {
            AudioListener.volume = previousVolume;
        }

        volumeSlider.value = AudioListener.volume;
    }
}
