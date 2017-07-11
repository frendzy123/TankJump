using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDestroy : MonoBehaviour {

	public float delay; // Duration the bullet exists in the game.

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
}
