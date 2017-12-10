using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGun : MonoBehaviour 
{
	public GameObject EnemyBulletGO;
	// Use this for initialization
	void Start () 
	{
		Invoke ("FireEnemyBullet", 1f);
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	void FireEnemyBullet()
	{
		GameObject playerShip = GameObject.Find ("PlayerGO2");
			if(playerShip != null)
			{
				GameObject EnemyBullet = (GameObject)Instantiate(EnemyBulletGO);

				EnemyBullet.transform.position = transform.position;
				
			Vector2 direction = playerShip.transform.position;

			EnemyBullet.GetComponent<EnemyBullet> ().SetDirection (direction);

			}
	}
}
