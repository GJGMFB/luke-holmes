using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class gameManager
{
	private static string lastLevel;
	private static int miniGame1Status;
	private static int miniGame2Status;
	private static int ballBreakerStatus;
	private static int ballBreaker2Status;
	private static bool tutorialShow;
	private static bool movementOn;
	private static bool isLastPlayerPosSet;
	private static Stack<Vector3> lastPlayerPos;

	static gameManager() {
		miniGame1Status = -1;
		ballBreakerStatus = -1;
		miniGame2Status = -1;
		ballBreaker2Status = -1;
		tutorialShow = true;
		movementOn = true;
		isLastPlayerPosSet = false;
		lastLevel = null;
		lastPlayerPos = new Stack<Vector3> ();
	}

	// See if we beat all minigames
	public static bool checkCompletion() {
		if (miniGame1Status == 1 && miniGame2Status == 1 && ballBreakerStatus == 1 && ballBreaker2Status == 1) {
			return true;
		}

		return false;
	}

	public static void loadFinalLevel() {
		setLastLevel (SceneManager.GetActiveScene ().name);
		SceneManager.LoadScene ("marberg");
	}

	public static int getMiniGameStatus(string name) {
		if (name == "ballBreaker")
			return ballBreakerStatus;
		if (name == "miniGame1")
			return miniGame1Status;

		return -1;
	}

	public static void setBallBreaker(int status) {
		ballBreakerStatus = status;
	}

	public static int getBallBreaker() {
		return ballBreakerStatus;
	}

	public static void setBallBreaker2(int status) {
		ballBreaker2Status = status;
	}

	public static int getBallBreaker2() {
		return ballBreaker2Status;
	}

	public static void setLastPlayerPos(Vector3 p) {
		lastPlayerPos.Push(p);
		isLastPlayerPosSet = true;
	}

	public static Vector3 getLastPlayerPos() {
		return lastPlayerPos.Pop();
	}

	public static void unsetLastPlayerPosStatus() {
		isLastPlayerPosSet = false;
	}

	public static bool getLastPlayerPosStatus() {
		return isLastPlayerPosSet;
	}

	public static void setLastLevel(string level)
	{
		lastLevel = level;
	}

	public static string getLastLevel()
	{
		return lastLevel;
	}

	public static void loadNewLevel(string scene) {
		if (checkCompletion ())
			loadFinalLevel();
		else
			SceneManager.LoadScene (scene);
	}

	public static void setMiniGame1(int status) {
		miniGame1Status = status;
	}

	public static int getMiniGame1() {
		return miniGame1Status;
	}

	public static void setMiniGame2(int status) {
		miniGame2Status = status;
	}

	public static int getMiniGame2() {
		return miniGame2Status;
	}

	public static void toggleTutorial() {
		tutorialShow = !tutorialShow;
	}

	public static void hideTutorial() {
		tutorialShow = false;
	}
		
	public static bool getTutorial() {
		return tutorialShow;
	}

	public static void enableMovement() {
		movementOn = true;
	}

	public static void disableMovement() {
		movementOn = false;
	}

	public static bool checkMovement() {
		return movementOn;
	}
}
