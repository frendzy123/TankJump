using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explodeBehavior : MonoBehaviour {

	public int returnVelConst = -1;
	public int selfDamage = 10;
	public float explodeTime = 0.3f;

	private Vector3 bulletVelocity = Vector3.zero;
	Rigidbody2D playerBody;

	// Use this for initialization
	void Start () {
		Destroy (this.gameObject, explodeTime);
	}

	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter2D(Collider2D other) {
		//GameObject col = FindParent(other.gameObject, "Player");
		Debug.Log(other);

		if (other.tag == "Player" && !other.GetComponentInParent<PlayerMovement>().checkInvincible()) {
			//other.GetComponentInParent<PlayerMovement> ().enableInvincible();
			playerBody = other.GetComponent<Rigidbody2D>();
			playerBody.velocity = bulletVelocity * returnVelConst;
			//other.gameObject.GetComponent<PlayerController>().health -= selfDamage;

			other.GetComponentInParent<PlayerMovement> ().changeHealth (-selfDamage);
		}
	}

	GameObject FindParent (GameObject child, string tag) {
		Transform t = child.transform;

		while (t.parent != null) {
			if (t.parent.tag == tag) {
				return t.parent.gameObject;
			}
			t = t.parent.transform;
		}
		return null;
	} 

	public void KnockbackSpeed(Vector3 vel) {
		bulletVelocity = vel;
	}

}
