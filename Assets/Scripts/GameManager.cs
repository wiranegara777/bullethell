﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public GameObject playerButton;
	public GameObject playerShip;
	public GameObject enemySpawner;
	public GameObject GameOverGO;

	public enum GameManagerState
	{
		Opening,
		Gameplay,
		GameOver,
	}
	GameManagerState GMState;
	// Use this for initialization
	void Start () 
	{
		GMState = GameManagerState.Opening;	
	}
	
	// Update is called once per frame
	void Update () 
	{
			
	}

	void UpdateGameManagerState()
	{
		switch (GMState) 
		{
		case GameManagerState.Opening:
			//hide game over
			GameOverGO.SetActive(false);
			//set playbutton visible(active)
			playerButton.SetActive(true);

			break;
		case GameManagerState.Gameplay:
			playerButton.SetActive (false);

			playerShip.GetComponent<PlayerControl> ().Init ();

			enemySpawner.GetComponent<EnemySpawner> ().ScheduleEnemySpawner ();
			break;
		case GameManagerState.GameOver:
			//stop enemy spawner
			enemySpawner.GetComponent<EnemySpawner>().UnscheduleEnemySpawner();

			//Display game over
			GameOverGO.SetActive(true);

			//change game manager state to opening state
			Invoke("ChangeToOpeningState",8f);

			break;
		}
	}

	public void SetGameManagerState(GameManagerState state)
	{
		GMState = state;
		UpdateGameManagerState ();
	}

	public void StartGamePlay()
	{
		GMState = GameManagerState.Gameplay;
		UpdateGameManagerState ();
	}

	public void ChangeToOpeningState()
	{
		SetGameManagerState (GameManagerState.Opening);
	}
}
