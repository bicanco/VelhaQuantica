using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu2 : MonoBehaviour
{

	public void Home ()
	{
		SceneManager.LoadScene(0);

	}

	public void Sair ()
	{
		Application.Quit();
	}



}
