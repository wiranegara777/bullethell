using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawner : MonoBehaviour {

	bool udah = true;

	public bool Udah{
		set {
			this.udah = value;
		} 
	}

	public GameObject BossGO;
	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	public void SpawnBoss()
	{
		if (udah) {
			GameObject anEnemy = (GameObject)Instantiate (BossGO);
			anEnemy.transform.position = new Vector2 (0.009f, 4.704f);
			udah = false;
		}
	}
}
