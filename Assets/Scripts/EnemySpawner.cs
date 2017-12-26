using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour 
{
	public GameObject EnemyGO; // untuk prefab

	float maxSpawnRateInSeconds = 5f;

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void SpawnEnemy()
	{
		//bottom left point of the screen
		Vector2 min = Camera.main.ViewportToWorldPoint (new Vector2 (0,0));

		Vector2 max = Camera.main.ViewportToWorldPoint (new Vector2 (1,1));

		//instansiate an enemy
		GameObject anEnemy = (GameObject)Instantiate(EnemyGO);
		anEnemy.transform.position = new Vector2 (Random.Range (min.x, max.x), max.y);

		ScheduleNextEnemySpawn ();
	}

	void ScheduleNextEnemySpawn()
	{
		float spawnInNSeconds;

		if (maxSpawnRateInSeconds > 1f) {
			//pick a number between 1 and max SpawnRateInSeconds
			spawnInNSeconds = Random.Range (1f, maxSpawnRateInSeconds);
		} else
			spawnInNSeconds = 1f;

		Invoke ("SpawnEnemy", spawnInNSeconds);
	}

	void IncreaseSpawnRate()
	{
		if (maxSpawnRateInSeconds > 1f)
			maxSpawnRateInSeconds--;
		if (maxSpawnRateInSeconds == 1f)
			CancelInvoke ("IncreaseSpawnRate");
	}

	public void ScheduleEnemySpawner()
	{
		Invoke ("SpawnEnemy", maxSpawnRateInSeconds);

		//increase spawn rate every 30s
		InvokeRepeating ("IncreaseSpawnRate",0f,30f);
	}

	public void UnscheduleEnemySpawner()
	{
		CancelInvoke ("SpawnEnemy");
		CancelInvoke ("IncreaseSpawnRate");
		maxSpawnRateInSeconds = 5f;
	}
}
