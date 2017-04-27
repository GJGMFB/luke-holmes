using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class timer : MonoBehaviour {
	public float timeLimit;
	public GameObject text;
	public GameObject winText;
	public GameObject fade;
	private float startTime;

	// Use this for initialization
	void Start () {
		startTime = Time.time + timeLimit + 1; // Plus 1 will show the actual time limit for 1 second
		Invoke ("win", timeLimit);
	}
	
	// Update is called once per frame
	void Update () {
		if (startTime - Time.time >= 0)
			text.GetComponent<Text> ().text = "" + Mathf.FloorToInt(startTime - Time.time);
	}

	void win() {
		Debug.Log ("winner!");

		// Set win in the global game manager
		if (SceneManager.GetActiveScene ().name == "minigame1") {
			gameManager.setMiniGame1 (1);
		} else {
			// It's minigame2
			gameManager.setMiniGame2(1);
		}

		winText.SetActive (true);
		gameManager.setMiniGame1 (1);
		StartCoroutine (SlowTime ());
		StartCoroutine(FadeTo(1.0f, 2.0f));
		Invoke ("switchScene", 2);
	}

	void switchScene() {
		gameManager.loadNewLevel(gameManager.getLastLevel());
	}

	IEnumerator FadeTo(float aValue, float aTime) {
		Image image = fade.GetComponent<Image> ();
		image.rectTransform.sizeDelta = new Vector2 (Screen.width, Screen.height);
		Color c = image.color;
		float alpha = c.a;

		yield return new WaitForSecondsRealtime (2);

		for (float t = 0f; t < 1f; t += Time.unscaledDeltaTime / aTime) {
			c = new Color (c.r, c.g, c.b, Mathf.Lerp (alpha, aValue, t));
			image.color = c;
			yield return null;
		}

		Time.timeScale = 1;
	}

	IEnumerator SlowTime() {
		float t = 0;
		float s = 1f;

		while (Time.timeScale > 0.1f) {
			Time.timeScale = Mathf.Lerp (s, 0f, t);
			t += Time.unscaledDeltaTime / 2f;
			yield return null;
		}
	}
}
