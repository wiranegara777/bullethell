using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour 
{
	public GameObject AbilityGO;
	float speed;

	// Use this for initialization
	void Start ()
	{
		speed = 1.25f;	 
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
		if ((col.tag == "PlayerShipTag"))
		{
			PlayAbility ();
			Destroy (gameObject);
		}
	}

	void PlayAbility()
	{
		GameObject explosion = (GameObject)Instantiate (AbilityGO);

		explosion.transform.position = transform.position;
	}
}
