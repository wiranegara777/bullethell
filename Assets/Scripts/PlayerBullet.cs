using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour 
{
	float speed;
	// Use this for initialization
	void Start ()
	{
		speed = 5.5f;
	}
	
	// Update is called once per frame
	void Update () 
	{
		//get bullet current position
		Vector2 position = transform.position;

		//compute the bullet new position
		position = new Vector2 (position.x, position.y + speed * Time.deltaTime);

		//update the bullet position
		transform.position = position;

		//this is the top right of the screen
		Vector2 max = Camera.main.ViewportToWorldPoint (new Vector2 (1,1));

		//if the bullet went outside destroy the bullet
		if (transform.position.y > max.y) 
		{
			Destroy (gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.tag == "EnemyShipTag")
		{
			Destroy (gameObject);
		}
	}
}
