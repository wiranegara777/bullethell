using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class GameScore : MonoBehaviour 
{

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
		
	}

	void UpdateScoreTextUI()
	{
		string scoreStr = string.Format ("{0:00000000}", score);
		scoreTextUI.text = scoreStr;
	}
}
