using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	private Text[] hud;
	public GameObject HUD;

	public int health;
	public int ammo;
	public float speed;

	private bool is_paused = false;
	//public float tankRadius = 0.5f;

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

		if (pos.x > Camera.main.orthographicSize+21f) {
			pos.x = Camera.main.orthographicSize+21f;
		}

		if (pos.x < -Camera.main.orthographicSize+10f) {
			pos.x = -Camera.main.orthographicSize+10f;
		}

		return pos;

	}

	public int viewHealth() {
		return health;
	}

	public int viewAmmo() {
		return ammo;
	}

	public void changeHealth(int n) {
		health += n;
		hud[0].text = health.ToString();
	}

	public void changeAmmo(int n) {
		ammo += n;
		hud[1].text = ammo.ToString();
	}

	public void Pause() {
		is_paused = !is_paused;
	}

	public bool checkPause() {
		return is_paused;
	}
}
