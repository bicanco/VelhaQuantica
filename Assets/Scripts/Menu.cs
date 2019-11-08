using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
	public void Home ()
	{
		SceneManager.LoadScene(0);

	}

	public void Jogar ()
	{
		SceneManager.LoadScene(1);

	}


	public void Tutorial ()
	{
		SceneManager.LoadScene(2);

	}

	public void Sair ()
	{
		Application.Quit();
	}



}
