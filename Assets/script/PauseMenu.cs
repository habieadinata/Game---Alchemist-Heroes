using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

	public static bool gameIsPause = false;
	public GameObject pauseUI;


	void Start () {
		Resume ();
		pauseUI.SetActive (false);
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape)) {
			if (gameIsPause) {
				Resume ();
			} 
			else {
				Pause ();
			}
		}
	}

	public void Resume () {
		pauseUI.SetActive (false);
		Time.timeScale = 1f;
		gameIsPause = false;
	}

	public void Pause () {
		pauseUI.SetActive (true);;
		Time.timeScale = 0f;
		gameIsPause = true;
	}

	public void MainMenu () {
		SceneManager.LoadScene (0);
	}
}
