using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour 
{
	public GameObject GameManagerGO;
	GameObject pesawat;
	public float health;
	Image barHealth;
	//public Image healthImage
	// Use this for initialization

	public float Health
	{
		get
		{
			return this.health;
		}
		set
		{
			this.health = value;
			//UpdateHealth ();
		}
	}

	void Start () 
	{
		barHealth = GetComponent<Image> ();
		pesawat = GameObject.FindGameObjectWithTag ("PlayerShipTag");
	}
	
	// Update is called once per frame
	void Update () 
	{
		barHealth.fillAmount = (health / 100);
		if (health <= 0) 
		{
			//pesawat.SetActive (false);
			GameManagerGO.GetComponent<GameManager> ().SetGameManagerState (GameManager.GameManagerState.Winner);
		}
	}

}
