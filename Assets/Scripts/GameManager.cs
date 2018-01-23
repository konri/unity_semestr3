using UnityEngine;
using System.Collections;
using UnityEngine.Assertions;

public class GameManager : MonoBehaviour {

	public static GameManager instance = null;

	[SerializeField] private GameObject mainMenu;
	private int defaultSpeed = 2;
	private int velocityChangeSpeed = 4;


	private bool playerActive = false;
	private bool gameOver = false;
	private bool gameStarted = false;

	private int _points = 0;
	private int _maxPoints = 0;
	private int speed = 4;

	public bool PlayerActive {
		get { return playerActive; }
	}

	public bool GameOver {
		get { return gameOver; }
	}

	public bool GameStarted {
		get { return gameStarted; }
	}

	public int points { 
		get { return _points; }
	}

	public int maxPoints {
		get { return _maxPoints; }
			
	}

	public int GameSpeed { 
		get { return speed; }
	}


	void Awake() {
		if (instance == null) {
			instance = this;
		} else if (instance != this) {
			Destroy (gameObject);
		}

		DontDestroyOnLoad (gameObject);

		Assert.IsNotNull (mainMenu);
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void PlayerCollided() {
		gameOver = true;
		if (_maxPoints < _points) {
			_maxPoints = _points;
			var bestScore = new BestScore ();
			bestScore.score = _maxPoints;
			SaveLoad.Save (bestScore);
		}
	}

	public void PlayerStartedGame() {
		playerActive = true;
	}

	public void EnterGame() {
		mainMenu.SetActive (false);
		_points = 0;
		gameStarted = true;
		playerActive = false;
	}

	public void addScore() {
		_points += 1;
		if (_points % velocityChangeSpeed == 0) {
			speed += 1;
		}
	}

	public void reset () {
		_points = 0;
		speed = defaultSpeed;
		gameOver = false;
		playerActive = false;
		gameStarted = true;
	}

	public void setHighScore(int score) {
		_maxPoints = score;
	}
}
