using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	private Rigidbody2D body;

	// Use this for initialization
	void Start() 
	{

		body = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update() 
	{

		Movement();
	}

	private void Movement()
	{

		if (Input.GetKeyDown (KeyCode.D))
			body.velocity = Vector2.right;
		
		else if (Input.GetKeyUp (KeyCode.D))
			body.velocity = Vector2.zero;

		if (Input.GetKeyDown (KeyCode.A))
			body.velocity = Vector2.left;

		else if (Input.GetKeyUp (KeyCode.A))
			body.velocity = Vector2.zero;
	}
}
