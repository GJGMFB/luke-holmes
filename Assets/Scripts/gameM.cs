using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameM : MonoBehaviour {

    public int lives = 3;
    public int bricks = 55;
    public float resetDelay = 1f;
    public Text livesText;
    public GameObject gameOver;
    public GameObject youWin;
    public GameObject bricksPrefab;
    public GameObject paddle;
    public static gameM instance = null;

    private GameObject clonePaddle;
	private int win;

	// Use this for initialization
	void Start () {

        if(instance == null)
        {
            instance = this;
        }
        else if(instance != this)
        {
            Destroy(gameObject);
        }

		win = -1;

        Setup();
	}

    public void Setup()
    {
        clonePaddle =  Instantiate(paddle);
		clonePaddle.name = "paddle";
		Instantiate (bricksPrefab, new Vector3(transform.position.x, transform.position.y - 0.5f, transform.position.z), Quaternion.identity);

    }

    void CheckGaneOver()
    {
        if(bricks < 1)
        {
			win = 1;
            youWin.SetActive(true);

			// Set win in the global game manager
			if (SceneManager.GetActiveScene ().name == "ballBreaker") {
				gameManager.setBallBreaker (1);
			} else {
				// It's ball breaker 2
				gameManager.setBallBreaker2(1);
			}

			gameManager.loadNewLevel(gameManager.getLastLevel());
        }

		if(lives < 1 && win != 1)
        {
            gameOver.SetActive(true);
			gameManager.loadNewLevel(gameManager.getLastLevel());
        }
    }

    void Reset()
    {
        Time.timeScale = 1f;
		gameManager.loadNewLevel(SceneManager.GetActiveScene().name);
    }


    public void LoseLife()
    {
        lives--;
        livesText.text = "LIVES: " + lives;
        Destroy(clonePaddle);
        Invoke("SetupPaddle", resetDelay);
        CheckGaneOver();
    }
    
    void SetupPaddle()
    {
        clonePaddle = Instantiate(paddle) as GameObject;
		clonePaddle.name = "paddle";
    }

    public void DestroyBrick()
    {
        bricks--;
        CheckGaneOver();
    }
}
