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
        Debug.Log("Mostrando tela de vit�ria...");
        endGameController.ShowVictoryScreen(); // Tenta mostrar a tela de vit�ria
        yield return new WaitForSeconds(5); // Aumenta o atraso para garantir que a tela apare�a

        Debug.Log("Carregando pr�xima cena...");
        if (STAGE_CONTROLLER < MAX_STAGES)
        {
            STAGE_CONTROLLER++;
            SceneManager.LoadScene(STAGE_CONTROLLER);
        }
        else
        {
            Debug.Log("Jogo completo. N�o h� mais fases para carregar.");
            // Aqui voc� pode fazer algo quando todas as fases forem completadas, como mostrar um cr�dito final ou recome�ar o jogo.
        }
    }
}
