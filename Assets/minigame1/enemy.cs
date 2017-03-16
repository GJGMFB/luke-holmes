using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class enemy : MonoBehaviour {
	public float destroyAtPos;
	public GameObject ui;
	public GameObject fade;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.x > destroyAtPos)
			Destroy (this.gameObject);
	}

	void OnCollisionEnter(Collision col) {
		if (col.gameObject.name == "Ball") {
			GameObject instance = Instantiate (ui);
			instance.SetActive(true);

			StartCoroutine (SlowTime ());
			StartCoroutine(FadeTo(1.0f, 2.0f));
			Invoke ("switchScene", 2);
		}
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

	void switchScene() {
		SceneManager.LoadScene ("scene");
	}
}
