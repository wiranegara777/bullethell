using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour 
{

	public GameObject playerButton;
	public GameObject playerShip;
	public GameObject enemySpawner;
	public GameObject GameOverGO;
	public GameObject winner;
	public GameObject scoreUITextGO;
	public GameObject TimeCounterGO;
	public GameObject BossSpawner;
	public GameObject HealthBar;
	public GameObject Health;
	public GameObject instruksi1;
	public GameObject instruksi2;
	public GameObject logo;

	//Image healths;

	public enum GameManagerState
	{
		Opening,
		Gameplay,
		GameOver,
		BossScene,
		Winner,
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
			GameOverGO.SetActive (false);
			//set playbutton visible(active)
			HealthBar.SetActive (false);


			playerButton.SetActive (true);
			//playerShip.SetActive (false);
				
			break;
		case GameManagerState.Gameplay:

			Health.GetComponent<HealthBar> ().Health = 100;

			playerButton.SetActive (false);
			//healths = GetComponent<Image> ();

			instruksi1.SetActive (false);
			instruksi2.SetActive (false);
			logo.SetActive (false);

			scoreUITextGO.GetComponent<GameScore> ().Score = 0;

			BossSpawner.GetComponent<BossSpawner> ().Udah = true;

			playerShip.GetComponent<PlayerControl> ().Init ();

			enemySpawner.GetComponent<EnemySpawner> ().ScheduleEnemySpawner ();

			TimeCounterGO.GetComponent<TimeCounter> ().StartTimeCounter ();

			break;

		case GameManagerState.GameOver:

			//STOP THE TIME COUNTER

			TimeCounterGO.GetComponent<TimeCounter> ().StopTimeCounter();

			//stop enemy spawner
			enemySpawner.GetComponent<EnemySpawner>().UnscheduleEnemySpawner();

			//Display game over
			GameOverGO.SetActive(true);

			//change game manager state to opening state
			//Invoke("ChangeToOpeningState",8f);
			StartCoroutine(counter());

			break;
		case GameManagerState.BossScene:
			HealthBar.SetActive (true);
			BossSpawner.GetComponent<BossSpawner> ().SpawnBoss ();
			//enemySpawner.GetComponent<EnemySpawner> ().UnscheduleEnemySpawner ();

			break;
		
		case GameManagerState.Winner:
			TimeCounterGO.GetComponent<TimeCounter> ().StopTimeCounter ();
			//enemySpawner.GetComponent<EnemySpawner> ().UnscheduleEnemySpawner ();
			winner.SetActive (true);

			//Invoke ("ChangeToOpeningState", 8f);
			StartCoroutine(counter());

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

	IEnumerator counter(){
		yield return new WaitForSeconds (8f);
		SceneManager.LoadScene ("GameEngine");
	} 
}
