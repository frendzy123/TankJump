using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructableEnvironment : MonoBehaviour {

	public int delay;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D coll)
	{

		if (coll.gameObject.tag == "Explosion") 
		{

			Destroy (this.gameObject);
		}
	}

	void OnCollisionEnter2D(Collision2D coll)
	{

		if (coll.gameObject.tag == "Player") 
		{

			Destroy (this.gameObject, delay);
		}
	}
}
