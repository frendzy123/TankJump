using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPack : MonoBehaviour {

	public int healthCount;

	// Use this for initialization
	void Start () {

		healthCount = 50;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D(Collision2D coll)
	{

		if(coll.gameObject.tag == "Player") 
		{

			coll.gameObject.GetComponent<PlayerController>().changeHealth(healthCount);
			Destroy(this.gameObject);
		}
	}
}
