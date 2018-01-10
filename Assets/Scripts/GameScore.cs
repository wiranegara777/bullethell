using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class GameScore : MonoBehaviour 
{
	public GameObject GameManagerGO;
	Text scoreTextUI;
	int score;

	public int Score
	{
		get
		{
			return this.score;
		}
		set
		{
			this.score = value;
			UpdateScoreTextUI ();
		}
	}
	// Use this for initialization
	void Start () 
	{
		scoreTextUI = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (this.score == 1500) 
		{
			GameManagerGO.GetComponent<GameManager> ().SetGameManagerState (GameManager.GameManagerState.BossScene);
		}	
	}

	void UpdateScoreTextUI()
	{
		string scoreStr = string.Format ("{0:00000000}", score);
		scoreTextUI.text = scoreStr;
	}
}
