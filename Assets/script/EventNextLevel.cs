using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EventNextLevel : MonoBehaviour {

	public static bool gameIsWin = true;
	public GameObject WinUI;
	public string level;
	// Use this for initialization
	void Start () {
		WinUI.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Win() {
		WinUI.SetActive (true);
		Time.timeScale = 0f;
	}

	public void NextLevel() {
		SceneManager.LoadScene (level);
	}

	public void Restart() {
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
	}

	public void Exit() {
		SceneManager.LoadScene (0);
	}

	private void OnTriggerEnter2D(Collider2D other) {

		if (other.CompareTag("Player")) {
			if (gameIsWin) {
				Win();
			}
		}
	}
}
