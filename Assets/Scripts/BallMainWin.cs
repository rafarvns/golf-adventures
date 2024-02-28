using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallMainWin : MonoBehaviour
{
   
    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.tag.Equals("WinHole"))
        {
            Debug.Log("venceu!");
            SceneManager.LoadScene("Stage1Scene");
        }
    }
}
