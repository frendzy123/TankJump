﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	private Rigidbody2D body;
	public int health;
	public int ammo;
	public float speed = 2.0f;

	// Use this for initialization
	void Start() 
	{
		health = 100;
		ammo = 3;
		body = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update() 
	{

		Movement();
	}

	private void Movement()
	{

		var move = new Vector3(Input.GetAxis("Horizontal"), 0);
		transform.position += move * speed * Time.deltaTime;
	}
		
}
