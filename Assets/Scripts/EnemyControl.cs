using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour 
{
	public GameObject ExplosionGO;
	public AudioClip ledakan;
	public AudioSource sumber;
	float speed;

	// Use this for initialization
	void Start ()
	{
		speed = 0.75f;	
		sumber = GetComponent<AudioSource>(); 
	}
	
	// Update is called once per frame
	void Update () 
	{
		//Get the enemy current position
		Vector2 position = transform.position;	

		//compute the enem new position
		position = new Vector2 (position.x, position.y - speed *Time.deltaTime);

		//update the enemy position
		transform.position = position;

		//bottom left point of the screen
		Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0,0));

		if (transform.position.y < min.y) 
		{
			
			Destroy (gameObject);
		}



	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if ((col.tag == "PlayerShipTag") || (col.tag == "PlayerBulletTag"))
		{
			sumber.PlayOneShot(ledakan);
			PlayExplosion ();
			Destroy (gameObject);
		}
	}

	void PlayExplosion()
	{
		GameObject explosion = (GameObject)Instantiate (ExplosionGO);

		explosion.transform.position = transform.position;
	}
}
