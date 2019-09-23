using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

	public void Jogar ()
	{
		SceneManager.LoadScene(1);

	}

	public void Home ()
	{
		SceneManager.LoadScene(0);

	}

	public void Sair ()
	{
		Application.Quit();
	}



}
