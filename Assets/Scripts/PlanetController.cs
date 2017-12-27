using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetController : MonoBehaviour 
{
	public GameObject[] Planets;

	Queue<GameObject> avaiablePlanets = new Queue<GameObject>();

	// Use this for initialization
	void Start () 
	{
		avaiablePlanets.Enqueue (Planets [0]);
		avaiablePlanets.Enqueue (Planets [1]);
		avaiablePlanets.Enqueue (Planets [2]);

		InvokeRepeating ("MovePlanetDown", 0, 20f);
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	void MovePlanetDown()
	{
		EnqueuePlanets ();

		if (avaiablePlanets.Count == 0)
			return;

		GameObject aPlanet = avaiablePlanets.Dequeue ();

		aPlanet.GetComponent<Planet> ().isMoving = true;
	}

	void EnqueuePlanets()
	{
		foreach (GameObject aPlanet in Planets) 
		{
			if ((aPlanet.transform.position.y < 0) && (!aPlanet.GetComponent<Planet> ().isMoving)) 
			{
				aPlanet.GetComponent<Planet> ().ResetPosition ();

				avaiablePlanets.Enqueue (aPlanet);
			}
		}
	}

}
