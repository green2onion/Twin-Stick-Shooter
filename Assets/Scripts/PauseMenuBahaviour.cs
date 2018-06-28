
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PauseMenuBahaviour : MonoBehaviour
{
	public Canvas pauseMenu;
	public KeyCode pause = KeyCode.Escape;
	public void Resume()
	{
		Time.timeScale = 1;
		pauseMenu.gameObject.SetActive(false);
	}
	public void RestartScene()
	{
		Time.timeScale = 1;
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
	public void QuitToStart()
	{
		Time.timeScale = 1;
		SceneManager.LoadScene("MainMenu");
	}
	private void TogglePauseMenu()
	{
		if (Input.GetKeyDown(pause))
		{
			if (pauseMenu.gameObject.activeSelf)
			{
				pauseMenu.gameObject.SetActive(false);
				Time.timeScale = 1;
			}
			else
			{
				pauseMenu.gameObject.SetActive(true);
				Time.timeScale = 0;
			}
		}
	}
	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		TogglePauseMenu();
	}
}
