using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeScreenManager : MonoBehaviour
{
	public void GoToPlayGround()
	{
		SceneManager.LoadScene("playground");
	}
	
	public void ExitGame()
	{
		Application.Quit();
	}
}
