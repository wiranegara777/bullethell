using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerControl : MonoBehaviour {

	public GameObject PlayerBulletGO; // gameplayer bullet
	public GameObject BulletPositionPlayer;
	public GameObject ExplosionGO;
	public float speed;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown ("space")) 
		{
			GameObject bullet = (GameObject)Instantiate (PlayerBulletGO);
			bullet.transform.position = BulletPositionPlayer.transform.position;
		}

		float x = Input.GetAxisRaw ("Horizontal"); //left, right
		float y = Input.GetAxisRaw ("Vertical"); //up, down

		Vector2 direction = new Vector2 (x, y).normalized;

		Move (direction);
	}

	void Move(Vector2 direction)
	{
		Vector2 min = Camera.main.ViewportToWorldPoint (new Vector2 (0, 0));
		Vector2 max = Camera.main.ViewportToWorldPoint (new Vector2 (1, 1));

		max.x = max.x - 0.255f; 
		min.x = min.x + 0.225f;

		max.y = max.y - 0.285f;
		min.y = min.y + 0.285f;

		//get player position
		Vector2 pos = transform.position;
		//kalkulasi new position
		pos += direction * speed * Time.deltaTime;

		//make sure position not outside the screen
		pos.x = Mathf.Clamp (pos.x, min.x, max.x);
		pos.y = Mathf.Clamp (pos.y, min.y, max.y); 

		//update the player position
		transform.position = pos;
	}
	void OnTriggerEnter2D(Collider2D col)
	{
		if ((col.tag == "EnemyShipTag") || (col.tag == "EnemyBulletTag"))
		{
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
