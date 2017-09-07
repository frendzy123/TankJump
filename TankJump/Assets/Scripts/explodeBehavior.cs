using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explodeBehavior : MonoBehaviour {

	public int returnVelConst = -1;
	public int selfDamage = 10;

	private Vector3 bulletVelocity = Vector3.zero;
	Rigidbody2D playerBody;

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter2D(Collider2D other) {
		//GameObject col = FindParent(other.gameObject, "Player");
		//Debug.Log(other);

		if (other.tag == "Player") {
			Vector2 playerLocation = other.gameObject.transform.position;
			Vector2 explosionLocation = gameObject.transform.position;

			Vector2 direction = (playerLocation - explosionLocation);


			if (direction.x < 0) {
				returnVelConst = -1;
			}

			else {
				returnVelConst = 1;
				bulletVelocity = new Vector2 (Mathf.Abs (bulletVelocity.x), Mathf.Abs(bulletVelocity.y));
			}

			playerBody = other.GetComponent<Rigidbody2D>();
			Debug.Log ("bulletVelocity " + bulletVelocity);
			Debug.Log ("return " + returnVelConst);



			playerBody.velocity = bulletVelocity * returnVelConst;
			Debug.Log ("player " + playerBody.velocity);


			other.GetComponentInParent<PlayerMovement>().DealDamage(-selfDamage);
			other.GetComponentInParent<PlayerMovement> ().DisableMovement();
		}
			
	}

	public void KnockbackSpeed(Vector3 vel) {
		bulletVelocity = vel;
	}

}
