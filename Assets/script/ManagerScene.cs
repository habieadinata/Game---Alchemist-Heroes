using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerScene : MonoBehaviour {

	public void PlayGame () {
		
		SceneManager.LoadScene (1);
	}

	public void LevelSelect () {
		SceneManager.LoadScene(4);
	}

	public void Exit () {
		Application.Quit ();
	}

	public void level_1 () {
		SceneManager.LoadScene (1);
	}

	public void level_2 () {
		SceneManager.LoadScene (2);
	}

	public void level_3 () {
		SceneManager.LoadScene (3);
	}

	public void MainMenu () {
		SceneManager.LoadScene (0);
	}
}
