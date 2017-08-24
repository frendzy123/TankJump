﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour {

	private Text[] hud;
	public GameObject HUD;
	public GameObject projectile;

	public int health;
	public int ammo;
	public float speed;
	public float invincibilityTime = 0.2f;

	private GameObject turret;

	private bool isPaused = false;
	private bool isInvincible = false;

	private Rigidbody2D rigid;


	// Use this for initialization
	void Start() 
	{
		health= 100;
		ammo = 500;
		speed = 2.0f;

		HUD = GameObject.FindWithTag("HUD");

		hud = HUD.GetComponentsInChildren<Text>();

		hud [0].text = health.ToString();
		hud [1].text = ammo.ToString();

		turret = transform.Find("turret").gameObject;
		rigid = this.gameObject.GetComponent<Rigidbody2D> ();

	}

	// Update is called once per frame
	void Update() {

		if (rigid.IsSleeping ())
		{

			rigid.WakeUp();
		}

		if (!isPaused) {
			Aim ();

			if (Input.GetKeyDown (KeyCode.Mouse0)) {
				Shoot ();
			}
		}
	}

	// Update is called once per physics loop
	void FixedUpdate()
	{
		Vector3 playerPos = transform.position;

		transform.position = Movement(playerPos);
	}




/* ------------- Player Movement ---------------*/
	private Vector3 Movement(Vector3 pos)
	{
		var move = new Vector3(Input.GetAxis("Horizontal"), 0);
		pos += move * speed * Time.deltaTime;

		/*if (pos.x > Camera.main.orthographicSize+21f) {
			pos.x = Camera.main.orthographicSize+21f;
		}

		if (pos.x < -Camera.main.orthographicSize+10f) {
			pos.x = -Camera.main.orthographicSize+10f;
		}*/

		return pos;

	}

/*------------ Turret Movement -----------------*/
	void Aim()
	{

		Vector3 mousePos = Input.mousePosition; //Obtain mouse position
		Vector3 objectPos = Camera.main.WorldToScreenPoint(turret.transform.position); //Get coordinates of turret

		mousePos.x = mousePos.x - objectPos.x;
		mousePos.y = mousePos.y - objectPos.y;

		float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg; //Calculate angle in rads using tan of x and y
		turret.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
	}

/*------------- Player Shooting ----------------*/
	private void Shoot()
	{
		if(ammo > 0)
		{
			Vector3 shooting_point = turret.transform.GetChild(0).transform.position;

			Debug.Log (shooting_point);

			GameObject bullet = (GameObject) Instantiate(projectile, shooting_point, turret.transform.rotation); // Instantiates the bullet
			Physics2D.IgnoreCollision(bullet.GetComponent<Collider2D>(), turret.GetComponent<Collider2D>()); // Ignore collisions with turret
			//Physics2D.IgnoreCollision(bullet.GetComponent<Collider2D>(), transform.parent.parent.GetComponent<Collider2D>()); // Ignore collisions with tank
			Rigidbody2D bulletRigid = (Rigidbody2D) bullet.GetComponent<Rigidbody2D>(); // Get rigidbody from the bullet.
			bulletRigid.velocity = turret.transform.right * speed; // Add a velocity towards the direction of the shooting points
			ChangeAmmo(-1);
		}

	}


/*------------ Public methods -----------------*/
	public int ViewHealth() {
		return health;
	}

	public int ViewAmmo() {
		return ammo;
	}

	public void ChangeHealth(int n) {
		health += n;
		hud[0].text = health.ToString();
	}

	public void ChangeAmmo(int n) {
		ammo += n;
		hud[1].text = ammo.ToString();
	}

	public void Pause() {
		isPaused = !isPaused;
	}

	public bool CheckPause() {
		return isPaused;
	}

	public bool CheckInvincible() {
		return isInvincible;
	}

	public void EnableInvincible() {
		isInvincible = !isInvincible;
		Invoke ("DisableInvincible", invincibilityTime);
	}

	public void DisableInvincible() {
		isInvincible = false;
	}

	public void DealDamage(int n)
	{

		if (!CheckInvincible()) 
		{

			ChangeHealth(n);
			EnableInvincible();
		}
	}
}
