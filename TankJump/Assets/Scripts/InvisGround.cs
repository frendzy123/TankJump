using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisGround : MonoBehaviour {

	private SpriteRenderer renderer;

	// Use this for initialization
	void Start () {

		renderer = this.gameObject.GetComponent<SpriteRenderer>();
		renderer.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D coll)
	{

		if (coll.gameObject.tag == "Explosion") 
		{

			renderer.enabled = true;
		}
	}

	void OnCollisionEnter2D(Collision2D coll)
	{

		if (coll.gameObject.tag == "Player") 
		{

			renderer.enabled = true;
		}
	}
}
