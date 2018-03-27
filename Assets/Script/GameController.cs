using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//Manuejado de esenas
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
	[Range (0f,0.20f)]
	public float parallaxSpeed = 0.02f;
	public RawImage background;
	public RawImage platform;
	public GameObject uiIdle;
	public enum GameState{IDle,Playing,Ended}

	public GameState gameState = GameState.IDle;
	public GameObject player;

	public GameObject enemyGenerator;
	// Use this for initialization
	void Start () {

		Screen.orientation = ScreenOrientation.LandscapeLeft;
	}
	
	// Update is called once per frame
	void Update () {
		//Empieza el juego
		if (gameState == GameState.IDle && (Input.GetKeyDown ("up") || Input.GetMouseButtonDown (0))) {
			gameState = GameState.Playing;
			uiIdle.SetActive (false);
			player.SendMessage ("UpdateState","PlayerRun");
			enemyGenerator.SendMessage ("StartGenerator");
		} 
		//Juego en marcha
		else if (gameState == GameState.Playing) {
			Parallax ();
			
		}
		else if (gameState == GameState.Ended) {
			//Parallax ();
			if (Input.GetKeyDown ("up") || Input.GetMouseButtonDown (0)) {
				RestartGame ();
			}
		}
	}

	void Parallax(){
		float finalSpeed = parallaxSpeed * Time.deltaTime;
		background.uvRect = new Rect (background.uvRect.x + finalSpeed, 0f, 1f, 1f);
		platform.uvRect = new Rect (platform.uvRect.x + finalSpeed * 4, 0f, 1f, 1f);
	}

	public void RestartGame(){
		SceneManager.LoadScene ("jump");
	}
}
