using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
	// abrindo menu
	public void Home ()
	{
		SceneManager.LoadScene(0);

	}

	//iniciando jogo
	public void Jogar ()
	{
		SceneManager.LoadScene(1);

	}

	//inciando tutorial
	public void Tutorial ()
	{
		SceneManager.LoadScene(2);

	}

	//encerrando o jogo
	public void Sair ()
	{
		Application.Quit();
	}



}
