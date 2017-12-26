using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class EnemyGun : MonoBehaviour 
{
	public GameObject EnemyBulletGO;
	bool CanShoot = true;
	public AudioClip tembak;
	public AudioSource audiosumber;
	// Use this for initialization
	void Start () 
	{
		//	Invoke ("FireEnemyBullet", 1f);
		//GetComponent<AudioSource>().playOnAwake = false;
		//GetComponent<AudioSource>().clip = tembak;
		audiosumber = GetComponent<AudioSource>(); 

	}
	
	// Update is called once per frame
	void Update () 
	{
		if (CanShoot == true)
		{
		FireEnemyBullet();
			CanShoot = false;
			Invoke ("Reload", 1.5f);
		}
	}

	void Reload(){
	//	yield WaitForSeconds(1);
		CanShoot = true;
	}

	void FireEnemyBullet()
	{
		//GameObject playerShip = GameObject.Find ("PlayerGO2");
			//	if(playerShip != null)
		//	{
		        //GetComponent<AudioSource>().Play();
		        audiosumber.PlayOneShot(tembak,0.5f);
				GameObject EnemyBullet = (GameObject)Instantiate(EnemyBulletGO);

				EnemyBullet.transform.position = transform.position;
				
				
		//	Vector2 direction = playerShip.transform.position;

		//	EnemyBullet.GetComponent<EnemyBullet> ().SetDirection (direction);

		//	}
	}
}
