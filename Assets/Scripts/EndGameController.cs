using UnityEngine;

public class EndGameController : MonoBehaviour
{
    public GameObject victoryScreenPrefab;
    public GameObject defeatScreenPrefab;

    public void ShowVictoryScreen()
    {
        Debug.Log("Instanciando tela de vitória...");
        GameObject canvasGameObject = FindObjectOfType<Canvas>().gameObject; 
        if (canvasGameObject == null)
        {
            Debug.LogError("Canvas não encontrado na cena!");
            return;
        }

        var victoryScreenInstance = Instantiate(victoryScreenPrefab);
        victoryScreenInstance.transform.SetParent(canvasGameObject.transform, false);
        victoryScreenInstance.transform.localPosition = Vector3.zero; 
        victoryScreenInstance.SetActive(true); 
    }

    public void ShowDefeatScreen()
    {
        Debug.Log("Instanciando tela de derrota...");
        GameObject canvasGameObject = FindObjectOfType<Canvas>().gameObject; 
        if (canvasGameObject == null)
        {
            Debug.LogError("Canvas não encontrado na cena!");
            return;
        }

        var defeatScreenInstance = Instantiate(defeatScreenPrefab);
        defeatScreenInstance.transform.SetParent(canvasGameObject.transform, false);
        defeatScreenInstance.transform.localPosition = Vector3.zero; 
        defeatScreenInstance.SetActive(true); 
    }
}