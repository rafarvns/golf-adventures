using UnityEngine;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour
{
    public Slider volumeSlider;
    public AudioSource audioSource;

    void Start()
    {
        // Carregar o volume salvo ou usar um padrão
        volumeSlider.value = PlayerPrefs.GetFloat("Volume", 0.5f);
        audioSource.volume = volumeSlider.value;
        volumeSlider.onValueChanged.AddListener(SetVolume);
    }

    public void SetVolume(float volume)
    {
        Debug.Log("Volume set to: " + volume); // Para debugging
        audioSource.volume = volume;
        PlayerPrefs.SetFloat("Volume", volume);
    }
}
