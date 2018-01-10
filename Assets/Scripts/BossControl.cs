using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossControl : MonoBehaviour {

	GameObject scoreUITextGO;
	GameObject healthBarGO;
	GameObject HealthMati;
	public GameObject ExplosionGO;
	public AudioClip ledakan;
	public AudioSource sumber;
	float speed;
	bool GerakHorizontal;
	bool kanan;

	// Use this for initialization
	void Start ()
	{
		GerakHorizontal = false;
		kanan = true;
		speed = 0.3f;	
		sumber = GetComponent<AudioSource>(); 

		HealthMati = GameObject.FindGameObjectWithTag ("health");
		scoreUITextGO = GameObject.FindGameObjectWithTag ("SCORE");
		healthBarGO = GameObject.FindGameObjectWithTag ("BossHealth");
	}

	// Update is called once per frame
	void Update () 
	{
		//Get the enemy current position
		Vector2 position = transform.position;	

		if (GerakHorizontal == false) 
		{
			//compute the enem new position
			position = new Vector2 (position.x, position.y - speed * Time.deltaTime);
		} else
		{
			if (kanan == true) {
				position = new Vector2 (position.x + speed * Time.deltaTime, position.y);
				if (position.x >= 5.8f) {
					kanan = false;
				}
			} else 
			{
				position = new Vector2 (position.x - speed * Time.deltaTime, position.y);
				if (position.x <= -5.8f) {
					kanan = true;
				}
			}

		}
		//update the enemy position
		transform.position = position;

		//bottom left point of the screen
		Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0,0.8f));

		if (transform.position.y < min.y) 
		{
			GerakHorizontal = true;
			speed = 1.4f;
			//Destroy (gameObject);
		}



	}
		

	void OnTriggerEnter2D(Collider2D col)
	{
		if ((col.tag == "PlayerShipTag") || (col.tag == "PlayerBulletTag"))
		{
			sumber.PlayOneShot(ledakan);
			PlayExplosion ();

			//scoreUITextGO.GetComponent<GameScore> ().Score += 100;
			healthBarGO.GetComponent<HealthBar> ().Health -= 0.5f;

			if (healthBarGO.GetComponent<HealthBar> ().Health <= 0) 
			{
				scoreUITextGO.GetComponent<GameScore> ().Score += 100000;
				Destroy (gameObject);
				//HealthMati.SetActive (false);
			}	
		}
	}

	void PlayExplosion()
	{
		GameObject explosion = (GameObject)Instantiate (ExplosionGO);

		explosion.transform.position = transform.position;
	}
}
