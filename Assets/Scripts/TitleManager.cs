using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleManager : MonoBehaviour
{
    public GameObject transitionBegin;
    public GameObject transitionEnd;
    public GameObject tutoImage;

    private void Start()
    {
        Time.timeScale = 1;
        transitionBegin.SetActive(true);
        tutoImage.SetActive(false);
        transitionEnd.SetActive(false);
    }

    public void botonjugar()
    {
        transitionEnd.SetActive(true);
    }

    public void botontuto()
    {
        tutoImage.SetActive(true);
    }

    public void botonnotuto()
    {
        tutoImage.SetActive(false);
    }

    public void botonSailr()
    {
        Application.Quit();
    }
}
