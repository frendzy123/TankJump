using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour {

	public GameObject explosion;
	public int returnVelConst = -1;
	public float hitRadius = 1;

	// Use this for initialization
	void Start() 
	{

	}

	// Update is called once per frame
	void Update() 
	{

	}

	// Function used to destroy when bullet collides with something.
	void OnTriggerEnter2D(Collider2D other) {
		if (other.GetComponent<Collider2D> ().tag == "Environment") {

			Vector3 bulletVelocity = GetComponent<Rigidbody2D> ().velocity; 
			GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
			GameObject explode = (GameObject)Instantiate (explosion, transform.position, transform.rotation);
			explode.GetComponent<explodeBehavior> ().KnockbackSpeed (bulletVelocity);
			Destroy (this.gameObject);
		}
	}
}
