using UnityEngine.Audio;
using UnityEngine;

public class AudioMgr : MonoBehaviour {

	public static AudioClip Coin, Hit, Hurt, Hurt2, Lose,
		pick, explosion, drain;
	static AudioSource audioSrc;

	// Use this for initialization
	void Start () {
		Coin = Resources.Load<AudioClip> ("Coin");
		Hit = Resources.Load<AudioClip> ("Hit");
		Hurt = Resources.Load<AudioClip> ("Hurt");
		Hurt2 = Resources.Load<AudioClip> ("Hurt2");
		Lose = Resources.Load<AudioClip> ("Lose");
		pick = Resources.Load<AudioClip> ("pick");
		explosion = Resources.Load<AudioClip> ("explosion");
		drain = Resources.Load<AudioClip> ("drain");

		audioSrc = GetComponent<AudioSource> ();
	}

	// Update is called once per frame
	void Update () {
		
	}

	public static void PlaySound (string clip) {
		switch (clip) {
		case "Coin":
			audioSrc.PlayOneShot (Coin);
			break;
		case "Hit":
			audioSrc.PlayOneShot (Hit);
			break;
		case "Hurt":
			audioSrc.PlayOneShot (Hurt);
			break;
		case "Hurt2":
			audioSrc.PlayOneShot (Hurt2);
			break;
		case "Lose":
			audioSrc.PlayOneShot (Lose);
			break;
		case "Pick":
			audioSrc.PlayOneShot (pick);
			break;
		case "Explosion":
			audioSrc.PlayOneShot (explosion);
			break;
		case "Drain":
			audioSrc.PlayOneShot (drain);
			break;
		}
	}
}
