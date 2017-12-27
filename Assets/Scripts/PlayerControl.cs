using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;


public class PlayerControl : MonoBehaviour {

	public GameObject GameManagerGO;

	public GameObject PlayerBulletGO; // gameplayer bullet
	public GameObject BulletPositionPlayer;
	public GameObject BulletPositionPlayer2;
	public GameObject BulletPositionPlayer3;
	public GameObject ExplosionGO;
	//public audio AudioSource;
	public float speed;
	public Text LivesUIText;

	const int MaxLives = 3; 
	int lives;
	//int skillCoolDown = 15;
	bool skill = false;

	public void Init()
	{
		lives = MaxLives;

		LivesUIText.text = lives.ToString ();

		transform.position = new Vector2 (0, 0);

		gameObject.SetActive (true);
	}

	public AudioClip tembak;
	public AudioSource audiosumber;
	// Use this for initialization
	void Start () {
		//tembak = GameObject.FindObjectOfType<AudioSource> ();
		//GetComponent<AudioSource>().playOnAwake = false;
		//GetComponent<AudioSource>().clip = tembak;
		audiosumber = GetComponent<AudioSource>(); 
		//audiosumber.clip = tembak;
	}

	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown ("space")) 
		{
			//AudioClip AudioSource = instantiatedProjectile.GetComponent(AudioSource);
			//AudioClip = false;
			audiosumber.PlayOneShot(tembak,0.5f);
			if (skill == true)
			{
				GameObject bullet = (GameObject)Instantiate (PlayerBulletGO);
				GameObject bullet2 = (GameObject)Instantiate (PlayerBulletGO);
				GameObject bullet3 = (GameObject)Instantiate (PlayerBulletGO);
				bullet.transform.position = BulletPositionPlayer.transform.position;
				bullet2.transform.position = BulletPositionPlayer2.transform.position;
				bullet3.transform.position = BulletPositionPlayer3.transform.position;
				
			}
			else
			{
				GameObject bullet = (GameObject)Instantiate (PlayerBulletGO);

				bullet.transform.position = BulletPositionPlayer.transform.position;	
			}


		}

	
		float x = Input.GetAxisRaw ("Horizontal"); //left, right
		float y = Input.GetAxisRaw ("Vertical"); //up, down

		Vector2 direction = new Vector2 (x, y).normalized;

		Move (direction);
	}

	void Cooldown(){
		skill = false;
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
			lives--;
			LivesUIText.text = lives.ToString ();
			if (lives == 0)
			{
				GameManagerGO.GetComponent<GameManager> ().SetGameManagerState (GameManager.GameManagerState.GameOver);

				//Destroy (gameObject);
				gameObject.SetActive(false);
			}
		}

		else if (col.tag == "Skill1Tag") 
		{
			skill = true;
			Invoke ("Cooldown",15f);
		}
	}

	void PlayExplosion()
	{
		GameObject explosion = (GameObject)Instantiate (ExplosionGO);

		explosion.transform.position = transform.position;
	}
}
