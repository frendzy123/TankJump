using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDScript : MonoBehaviour {

	private GameObject player;
	private Text[] hud;

	// Use this for initialization
	void Start () {
		
		player = GameObject.FindWithTag("Player");
		hud = GetComponentsInChildren<Text>();
	}
	
	// Update is called once per frame
	void Update () {

		hud[0].text = (player.GetComponent<PlayerController>().health).ToString();
		hud[1].text = (player.GetComponent<PlayerController>().ammo).ToString();
	}
}
