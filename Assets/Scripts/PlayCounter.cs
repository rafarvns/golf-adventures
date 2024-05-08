using UnityEngine;
using TMPro;

public class PlayCounter : MonoBehaviour
{
    public TextMeshProUGUI playCountText;
    private int playCount = 0;

    public void IncrementPlayCount()
    {
        playCount++;
        playCountText.text = playCount.ToString();
    }
}