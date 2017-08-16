﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {

	public GameObject PauseUI;
	public GameObject shootingPoint;
	public GameObject turret;

	private bool paused = false;

	// Use this for initialization
	void Start () {
		PauseUI.SetActive (false);

	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetButtonDown ("Pause")) {
			ChangePauseState();
		}
			
		if (shootingPoint == null) {
			shootingPoint = GameObject.FindGameObjectWithTag ("ShootingPoint");
		}

		if (turret == null) {
			turret = GameObject.FindGameObjectWithTag ("Turret");
		}
	}

	public bool GetPauseStatus() {
		return paused;
	}

	private void ChangePauseState() {
		paused = !paused;
		shootingPoint.GetComponent<Shooting>().Pause();
		turret.GetComponent<TurretController>().Pause();

		if (paused) {
			PauseUI.SetActive(true);
			Time.timeScale = 0;
		} else {
			PauseUI.SetActive(false);
			Time.timeScale = 1;
		}
	}

	public void Resume() {
		Debug.Log("clicked");
		ChangePauseState();
	}
}
