using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void ChangeScene(string MainMenuScene)
    {
        SceneManager.LoadScene(MainMenuScene);
    }
}
 // Script para mudar de cena nos créditos