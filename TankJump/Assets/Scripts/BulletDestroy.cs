using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BulletDestroy : MonoBehaviour {

	public float delay; // Duration the bullet exists in the game.
	public Sprite explosion;
	public int returnVelConst = -1;
	private bool pushTank = false;
	Collider2D playerColl;


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
	void OnTriggerEnter2D(Collider2D other) {
		
		if(other.GetComponent<Collider2D>().tag == "Player")
		{
			playerColl = other.GetComponent<Collider2D>();	
			pushTank = true;
		}

		if (other.GetComponent<Collider2D> ().tag == "Environment") 
		{

			if(pushTank) 
			{

				Rigidbody2D playerRigid = playerColl.attachedRigidbody;
				Rigidbody2D bulletRigid = this.gameObject.GetComponent<Rigidbody2D>();
				playerRigid.velocity = bulletRigid.velocity * returnVelConst;
			}

			GetComponent<SpriteRenderer> ().sprite = explosion;
			GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
			Debug.Log(pushTank);
			Destroy (this.gameObject, 0.5f);
		} 
	}
}
