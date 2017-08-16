using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour {

	public GameObject projectile;
	public GameObject player;
	public GameObject hud;

	public float speed;

	private bool is_paused = false;

	// Use this for initialization
	void Start() 
	{
		hud = GameObject.FindWithTag ("HUD");
	}
	
	// Update is called once per frame
	void Update() 
	{
		if (!is_paused && Input.GetKeyDown (KeyCode.Mouse0)) {
			Shoot ();
		}
	}

	public void Pause() {
		is_paused = !is_paused;
	}

	void Shoot()
	{


		if(player.GetComponent<PlayerController>().ammo > 0)
		{
			GameObject bullet = (GameObject) Instantiate(projectile, transform.position, transform.rotation); // Instantiates the bullet
			Physics2D.IgnoreCollision(bullet.GetComponent<Collider2D>(), transform.parent.GetComponent<Collider2D>()); // Ignore collisions with turret
			//Physics2D.IgnoreCollision(bullet.GetComponent<Collider2D>(), transform.parent.parent.GetComponent<Collider2D>()); // Ignore collisions with tank
			Rigidbody2D bulletRigid = (Rigidbody2D) bullet.GetComponent<Rigidbody2D>(); // Get rigidbody from the bullet.
			bulletRigid.velocity = transform.right * speed; // Add a velocity towards the direction of the shooting points
			//transform.parent.parent.GetComponent<PlayerController>().ammo -= 1;
			transform.parent.parent.GetComponent<PlayerController> ().changeAmmo (-1);


		}
		
	}
}
