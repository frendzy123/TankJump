using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour {

	public GameObject projectile;
	public float speed;

	// Use this for initialization
	void Start() 
	{
		
	}
	
	// Update is called once per frame
	void Update() 
	{

		Shoot();
	}

	void Shoot()
	{

		if(Input.GetKeyDown(KeyCode.Mouse0))
		{
			GameObject bullet = (GameObject) Instantiate(projectile, transform.position, transform.rotation); // Instantiates the bullet
			Physics2D.IgnoreCollision(bullet.GetComponent<Collider2D>(), transform.parent.GetComponent<Collider2D>()); // Ignore collisions with turret
			//Physics2D.IgnoreCollision(bullet.GetComponent<Collider2D>(), transform.parent.parent.GetComponent<Collider2D>()); // Ignore collisions with tank
			Rigidbody2D bulletRigid = (Rigidbody2D) bullet.GetComponent<Rigidbody2D>(); // Get rigidbody from the bullet.
			bulletRigid.velocity = transform.right * speed; // Add a velocity towards the direction of the shooting points
		}
	}
}
