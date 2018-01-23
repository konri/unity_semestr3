using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainGame : MonoBehaviour {


	public Text scoreTextField;
	public RawImage background;
	public Text finalScoreText;
	public Text finalScore;
	public Text finalBestScoreText;
	public Text finalBestScore;

	public Text menuBestScore;
	public Button replayBtn;

	public Canvas canvas;


	public Vector3 playerPosition;
	public GameObject player;



	// Use this for initialization
	void Start () {
		scoreTextField.enabled = false;
		HideEndGame ();
		LoadHighScore ();
	
	}
	
	// Update is called once per frame
	void Update () {
		if (GameManager.instance.GameStarted && GameManager.instance.PlayerActive) {
			//start 
			scoreTextField.enabled = true;
			UpdateScore ();
		}

		if (GameManager.instance.GameOver) {
			scoreTextField.enabled = false;
			UpdateFinalScore ();
			ShowEndGame ();
		}
		
	}

	public void Replay() {
		GameManager.instance.reset ();
		ResetPlayerPosition ();
		HideEndGame ();

	}


	void UpdateScore() {
		scoreTextField.text = "" + GameManager.instance.points;
	}

	void UpdateFinalScore() {
		finalScore.text = "" + GameManager.instance.points;
		finalBestScore.text = "" + GameManager.instance.maxPoints;
	}

	void HideEndGame() {
		background.enabled = false;
		finalScore.enabled = false;
		finalScoreText.enabled = false;
		finalBestScore.enabled = false;
		finalBestScoreText.enabled = false;
		replayBtn.enabled = false;
		canvas.enabled = false;
		replayBtn.GetComponentInChildren<CanvasRenderer>().SetAlpha(0);

	}

	void ShowEndGame() {
		background.enabled = true;
		finalScore.enabled = true;
		finalScoreText.enabled = true;
		finalBestScore.enabled = true;
		finalBestScoreText.enabled = true;
		replayBtn.enabled = true;
		canvas.enabled = true;
		replayBtn.GetComponentInChildren<CanvasRenderer>().SetAlpha(1);

	}

	void ResetPlayerPosition() {
		player.transform.localPosition = playerPosition;
		var playerRigidBody = player.GetComponent<Rigidbody> ();
		playerRigidBody.velocity = Vector3.zero;
		playerRigidBody.angularVelocity = Vector3.zero; 
		playerRigidBody.useGravity = false;
		playerRigidBody.detectCollisions = true;
	
	}

	void LoadHighScore() {
		BestScore bestScore = SaveLoad.Load ();
		if (bestScore != null) {
			menuBestScore.text = "Best Score: " + bestScore.score;
			GameManager.instance.setHighScore (bestScore.score);
		}
	}

}
