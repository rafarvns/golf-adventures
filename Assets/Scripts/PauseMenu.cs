using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public Button pauseButton;
    public Button backButton;
    public Button resumeButton;

    void Start()
    {
        pauseButton.onClick.AddListener(Pause);
        backButton.onClick.AddListener(BackToMainMenu);
        resumeButton.onClick.AddListener(Resume);
        pauseMenuUI.SetActive(false);
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
    }

    void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
    }

    void BackToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenuScene"); 
    }
}
