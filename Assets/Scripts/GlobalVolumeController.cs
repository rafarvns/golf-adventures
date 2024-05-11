using UnityEngine;
using UnityEngine.UI;

public class GlobalVolumeController : MonoBehaviour
{
    public static GlobalVolumeController Instance;  // Singleton instance
    public Slider volumeSlider;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);  // Faz o GameObject persistir entre cenas
        }
        else if (Instance != this)
        {
            Destroy(gameObject);  // Garante que apenas uma instância exista
        }
    }

    void Start()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("Volume", 0.5f);  // Carrega o volume salvo
        volumeSlider.onValueChanged.AddListener(SetVolume);
        SetVolume(volumeSlider.value);  // Aplica o volume inicial
    }

    public void SetVolume(float volume)
    {
        AudioListener.volume = volume;  // Ajusta o volume global
        PlayerPrefs.SetFloat("Volume", volume);  // Salva o volume
    }
}
