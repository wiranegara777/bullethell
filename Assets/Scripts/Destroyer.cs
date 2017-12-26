using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour {

	public AudioClip ledakan;
	public AudioSource sumber;

	void start(){
		sumber = GetComponent<AudioSource> ();
	}

	void DestroyGameObject()
	{
		Destroy (gameObject);
	}


}
