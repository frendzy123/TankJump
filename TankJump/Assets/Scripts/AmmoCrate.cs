using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoCrate : MonoBehaviour {

	public int ammoCount;

	// Use this for initialization
	void Start () {

		ammoCount = 3;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D(Collision2D coll)
	{

		if(coll.gameObject.tag == "Player") 
		{

			coll.gameObject.GetComponent<PlayerController>().ammo += ammoCount;
			Destroy(this.gameObject);
		}
	}
}
