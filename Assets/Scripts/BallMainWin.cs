using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class BallMainWin : MonoBehaviour
{
    public static int STAGE_CONTROLLER = 1;
    private static int MAX_STAGES = 3;

    private bool isSceneLoading = false;

    public Button NextStageButton;

    private void Start()
    {
        if (NextStageButton)
        {
            Debug.Log("STAGE_CONTROLLER: " + STAGE_CONTROLLER);
            NextStageButton.onClick.AddListener(NextStage);
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
}
