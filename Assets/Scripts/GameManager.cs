using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public string levelToLoad;
	public Image uscLogo;
	public float fadeDuration;
	public float pauseDuration;
	public Canvas startScreen;

	// Use this for initialization
	private void Start()
	{
		// set starting variables
		//fadeDuration = 1.0f;
		//pauseDuration = 2.0f;

		// setup fade
		uscLogo.canvasRenderer.SetAlpha(0.0f);
	}
	public void PressButton()
	{
		startScreen.enabled = false;
		StartCoroutine(BeginPlay());
	}
	private IEnumerator BeginPlay()
	{
		FadeIn(uscLogo);
		yield return new WaitForSeconds(pauseDuration); // this is "delay" in ue4
		FadeOut(uscLogo);
		yield return new WaitForSeconds(pauseDuration);
		SceneManager.LoadScene(levelToLoad);
	}

	void FadeIn(Image image)
	{
		print("fading in");
		image.CrossFadeAlpha(1, fadeDuration, false);
	}
	void FadeOut(Image image)
	{
		print("fading out");
		image.CrossFadeAlpha(0, fadeDuration, false);
	}
	public void Quit()
	{
		Application.Quit();
	}
}
