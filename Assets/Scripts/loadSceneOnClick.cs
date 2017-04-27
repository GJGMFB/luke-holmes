using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadSceneOnClick : MonoBehaviour {
	//public string scene;
	public void LoadByName(string sceneName)
    {
		SceneManager.LoadScene(sceneName);
    }
}
