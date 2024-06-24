using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class BallMainWin : MonoBehaviour
{
    public static int STAGE_CONTROLLER = 1;
    private static int MAX_STAGES = 3;
    private static int[] COLLECTED_STARS = new[] { 0, 0, 0};

    private bool isSceneLoading = false;

    public Button NextStageButton;
    public Button ResetGoMenuButton;
    public Button RestartStageButton;

    private void Start()
    {
        if (NextStageButton)
        {
            NextStageButton.onClick.AddListener(NextStage);
        }
        if (ResetGoMenuButton)
        {
            ResetGoMenuButton.onClick.AddListener(ResetGoMenu);
        }
        if (RestartStageButton)
        {
            RestartStageButton.onClick.AddListener(RestartStage);
        }
    }

    private void Update()
    {

    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag("WinHole") && !isSceneLoading)
        {
            isSceneLoading = true;
            SceneManager.LoadScene("VictoryScene");
        }
    }

    private void ResetGoMenu()
    {
        STAGE_CONTROLLER = 1;
        SceneManager.LoadScene(0);
    }

    private void NextStage()
    {
        Debug.Log("asdf   " + STAGE_CONTROLLER);
        if (STAGE_CONTROLLER < MAX_STAGES)
        {
            STAGE_CONTROLLER++;
            SceneManager.LoadScene(STAGE_CONTROLLER);
        }
        else
        {
            SceneManager.LoadScene("CreditsScene");
        }
    }
    
    private void RestartStage()
    {
        SceneManager.LoadScene(STAGE_CONTROLLER);
    }

    public static int GetMaxPlaysForStage()
    {
        switch (STAGE_CONTROLLER)
        {
            case 1:
                return 5;
            case 2:
                return 6;
            case 3:
                return 7;
            default:
                return 1;
        }
    }

    public static void GameOver()
    {
        SceneManager.LoadScene("GameOverScene");
    }
    
    public static void CollectStar()
    {
        if (STAGE_CONTROLLER < 1 || STAGE_CONTROLLER > MAX_STAGES)
        {
            Debug.LogError("Invalid stage number: " + STAGE_CONTROLLER);
            return;
        }

        COLLECTED_STARS[STAGE_CONTROLLER - 1]++;
        Debug.Log("Collected stars in stage " + STAGE_CONTROLLER + ": " + COLLECTED_STARS[STAGE_CONTROLLER - 1]);
    }

    public static int CollectedStarsCount()
    {
        if (STAGE_CONTROLLER < 1 || STAGE_CONTROLLER > MAX_STAGES)
        {
            Debug.LogError("Invalid stage number: " + STAGE_CONTROLLER);
            return 0 ;
        }
        return COLLECTED_STARS[STAGE_CONTROLLER - 1];
    }
}
