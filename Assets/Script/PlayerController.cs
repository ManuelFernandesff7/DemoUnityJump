using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	public GameObject game;
	public GameObject enemyGenerator;
	// Use this for initialization
	private Animator animator;
	void Start () {
		animator = GetComponent<Animator> ();
		
	}
	
	// Update is called once per frame
	void Update () {
		bool gamePlaying = game.GetComponent<GameController> ().gameState == GameController.GameState.Playing;
		if (gamePlaying && (Input.GetKeyDown ("up") || Input.GetMouseButtonDown (0))) {
			UpdateState ("PlayerJump");
		}
		
	}
	public void UpdateState(string state = null){
		if (state != null) {
			animator.Play (state);
		}
	
	}

	void OnTriggerEnter2D( Collider2D other){
		if (other.gameObject.tag == "Enemy") {
			UpdateState("PlayerDead");
		}
		game.GetComponent<GameController>().gameState = GameController.GameState.Ended;
		enemyGenerator.SendMessage ("CancelGenerator",true);

	}
}
