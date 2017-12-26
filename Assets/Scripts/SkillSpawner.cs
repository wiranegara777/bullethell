using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillSpawner : MonoBehaviour {

	public GameObject SkillGO; // untuk prefab
	bool respawn = true;
	//float maxSpawnRateInSeconds = 5f;

	// Use this for initialization
	void Start () 
	{

	}

	// Update is called once per frame
	void Update () 
	{
		if (respawn == true) 
		{
			SpawnSkill();
			respawn = false;
			Invoke ("Respawn", 30f);
		}
	}

	void Respawn()
	{
		respawn = true; 
	}

	void SpawnSkill()
	{
		//bottom left point of the screen
		Vector2 min = Camera.main.ViewportToWorldPoint (new Vector2 (0,0));

		Vector2 max = Camera.main.ViewportToWorldPoint (new Vector2 (1,1));

		//instansiate an enemy
		GameObject anSkill = (GameObject)Instantiate(SkillGO);
		anSkill.transform.position = new Vector2 (Random.Range (min.x, max.x), max.y);

		//ScheduleNextEnemySpawn ();
	}


}
