using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explodeBehavior : MonoBehaviour {

	public int returnVelConst = -1;
	public int selfDamage = 20;
	private Vector3 bulletVelocity = Vector3.zero;
	Rigidbody2D playerBody;

	// Use this for initialization
	void Start () {
		Destroy (this.gameObject, 0.5f);
	}

	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.GetComponent<Collider2D> ().tag == "Player") {
			playerBody = other.GetComponent<Rigidbody2D>();
			playerBody.velocity = bulletVelocity * returnVelConst;
			other.gameObject.GetComponent<PlayerController>().health -= selfDamage;
		}
	}

	public void KnockbackSpeed(Vector3 vel) {
		bulletVelocity = vel;
	}

}
