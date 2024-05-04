using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class BallMainWin : MonoBehaviour
{
    public static int STAGE_CONTROLLER = 1;
    private static int MAX_STAGES = 3;
    // public EndGameController endGameController;

    private bool isSceneLoading = false;

    public bool executeNow = false;

    private void Update()
    {
        if (executeNow && !isSceneLoading)
        {
            isSceneLoading = true;
            StartCoroutine(ShowVictoryAndLoadNext());
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag("WinHole") && !isSceneLoading)
        {
            isSceneLoading = true;
            SceneManager.LoadScene("VictoryScene");
        }
    }

    private IEnumerator ShowVictoryAndLoadNext()
    {
        yield return new WaitForSeconds(2);
        if (STAGE_CONTROLLER < MAX_STAGES)
        {
            STAGE_CONTROLLER++;
            SceneManager.LoadScene(STAGE_CONTROLLER);
        }
        else
        {
            Debug.Log("Jogo completo. Não há mais fases para carregar.");
        }
    }
}
