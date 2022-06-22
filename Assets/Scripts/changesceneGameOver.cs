using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changesceneGameOver : MonoBehaviour
{
    public void ChangeScene()
    {
        if (SceneManager.GetActiveScene().name == "title")
        {
            SceneManager.LoadScene("escenajuego");
        }
        else
        {
            SceneManager.LoadScene("title");
        }
    }

}
