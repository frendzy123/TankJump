﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class BulletDestroy : MonoBehaviour {

	public float delay; // Duration the bullet exists in the game.
	public Sprite explosion;


	// Use this for initialization
	void Start() 
	{
		Destroy(this.gameObject, delay); // Destroy after the specified delay has passed
	}
	
	// Update is called once per frame
	void Update() 
	{
		
	}

	// Function used to destroy when bullet collides with something.
	void DestroyOnCollision()
	{
		
		Destroy(this.gameObject);
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.GetComponent<Collider2D>().tag == "Environment") {
			Debug.Log ("collision");
			GetComponent<SpriteRenderer>().sprite = explosion;
			GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
			Destroy(this.gameObject, 0.5f);

		}
	}
}
