using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI playCountText;
    private int playCount = 0;

    void Update()
    {
        // o script foi feito em concordancia com as teclas que ja tinha do movimento da bola atraves das letras "a", "s", d e "w"
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S) ||
            Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
        {
            IncrementPlayCount();
        }
    }

    public void IncrementPlayCount()
    {
        playCount++;
        playCountText.text = "Jogadas: " + playCount;
    }
}