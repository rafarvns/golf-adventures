using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallMainWin : MonoBehaviour
{
    public static int STAGE_CONTROLLER = 1;
    private static int MAX_STAGES = 3;

    private bool isSceneLoading = false;
    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.tag.Equals("WinHole") && !isSceneLoading)
        {
            isSceneLoading = true;
            if (STAGE_CONTROLLER < MAX_STAGES)
            {
                STAGE_CONTROLLER++;
                SceneManager.LoadScene(STAGE_CONTROLLER);
            }
            else
            {
                Debug.Log("ZEREI");
            }
        }
    }
}
