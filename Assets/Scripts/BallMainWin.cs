using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class BallMainWin : MonoBehaviour
{
    public static int STAGE_CONTROLLER = 1;
    private static int MAX_STAGES = 3;
    public EndGameController endGameController;

    private bool isSceneLoading = false;

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag("WinHole") && !isSceneLoading)
        {
            isSceneLoading = true;
            StartCoroutine(ShowVictoryAndLoadNext());
        }
    }

    private IEnumerator ShowVictoryAndLoadNext()
    {
        Debug.Log("Mostrando tela de vitória...");
        endGameController.ShowVictoryScreen(); // Tenta mostrar a tela de vitória
        yield return new WaitForSeconds(5); // Aumenta o atraso para garantir que a tela apareça

        Debug.Log("Carregando próxima cena...");
        if (STAGE_CONTROLLER < MAX_STAGES)
        {
            STAGE_CONTROLLER++;
            SceneManager.LoadScene(STAGE_CONTROLLER);
        }
        else
        {
            Debug.Log("Jogo completo. Não há mais fases para carregar.");
            // Aqui você pode fazer algo quando todas as fases forem completadas, como mostrar um crédito final ou recomeçar o jogo.
        }
    }
}
