using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleManager : MonoBehaviour
{
	public GameObject transitionBegin;
	public GameObject transitionEnd;
	public GameObject tutoImage;
	private AudioSource aSource;

	private void Start()
	{
		Time.timeScale = 1;
		transitionBegin.SetActive(true);
		tutoImage.SetActive(false);
		transitionEnd.SetActive(false);
		aSource = gameObject.GetComponent<AudioSource>();
	}

	public void botonjugar()
	{
		transitionEnd.SetActive(true);
		aSource.Play();
	}

	public void botontuto()
	{
		tutoImage.SetActive(true);
		aSource.Play();

	}

	public void botonnotuto()
	{
		tutoImage.SetActive(false);
		aSource.Play();

	}

	public void botonSailr()
	{
		aSource.Play();
		Application.Quit();
	}
}
