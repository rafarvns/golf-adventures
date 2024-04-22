using UnityEngine;

public class EndGameController : MonoBehaviour
{
    public GameObject victoryScreenPrefab;
    public GameObject defeatScreenPrefab;

    public void ShowVictoryScreen()
    {
        Debug.Log("Instanciando tela de vit�ria...");
        GameObject canvasGameObject = FindObjectOfType<Canvas>().gameObject; // Encontra o Canvas na cena
        if (canvasGameObject == null)
        {
            Debug.LogError("Canvas n�o encontrado na cena!");
            return;
        }

        var victoryScreenInstance = Instantiate(victoryScreenPrefab);
        victoryScreenInstance.transform.SetParent(canvasGameObject.transform, false);
        victoryScreenInstance.transform.localPosition = Vector3.zero; // Centraliza na tela
        victoryScreenInstance.SetActive(true); // Garante que o prefab est� ativo
    }

    public void ShowDefeatScreen()
    {
        Debug.Log("Instanciando tela de derrota...");
        GameObject canvasGameObject = FindObjectOfType<Canvas>().gameObject; // Encontra o Canvas na cena
        if (canvasGameObject == null)
        {
            Debug.LogError("Canvas n�o encontrado na cena!");
            return;
        }

        var defeatScreenInstance = Instantiate(defeatScreenPrefab);
        defeatScreenInstance.transform.SetParent(canvasGameObject.transform, false);
        defeatScreenInstance.transform.localPosition = Vector3.zero; // Centraliza na tela
        defeatScreenInstance.SetActive(true); // Garante que o prefab est� ativo
    }
}