using System;
using UnityEngine;
using TMPro;

public class PlayCounter : MonoBehaviour
{
    public TextMeshProUGUI playCountText;
    public TextMeshProUGUI starCountText;
    private int playCount = 0;

    private void Start()
    {
        playCountText.text = playCount + " / " + BallMainWin.GetMaxPlaysForStage();
        starCountText.text = "0 / 3";
    }

    public void IncrementPlayCount()
    {
        playCount++;
        if (playCount > BallMainWin.GetMaxPlaysForStage())
        {
            BallMainWin.GameOver();
        }
        else
        {
            playCountText.text = playCount + " / " + BallMainWin.GetMaxPlaysForStage();
        }
    }

    public void UpdateStars()
    {
        starCountText.text = BallMainWin.CollectedStarsCount() + " / 3";
    }
}