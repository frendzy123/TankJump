using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public int health;
	public int ammo;
	public float speed = 2.0f;
	public float tankRadius = 0.5f;

	// Use this for initialization
	void Start() 
	{
		health = 100;
		ammo = 3;
	}
	
	// Update is called once per frame
	void Update() 
	{
		Vector3 playerPos = transform.position;

		transform.position = Movement(playerPos);
	
	}

	private Vector3 Movement(Vector3 pos)
	{
		var move = new Vector3(Input.GetAxis("Horizontal"), 0);
		pos += move * speed * Time.deltaTime;

		if (pos.x + tankRadius > Camera.main.orthographicSize) {
			pos.x = Camera.main.orthographicSize - tankRadius;
		}

		if (pos.x - tankRadius < -Camera.main.orthographicSize) {
			pos.x = -Camera.main.orthographicSize + tankRadius;
		}

		return pos;

	}
		
}
