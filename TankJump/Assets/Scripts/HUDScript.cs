using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDScript : MonoBehaviour {

	public GameObject player;

	private Text[] hud;

	// Use this for initialization
	void Start () {

		hud = GetComponentsInChildren<Text>();
	}

	// Update is called once per frame
	void Update () {
		if (player == null) {
			player = GameObject.FindGameObjectWithTag ("Player");
		}

		Debug.Log(player.GetComponent<PlayerController>().viewHealth());
		//Debug.Log (player.GetComponent<PlayerController>().viewHealth());
		//Debug.Log (player.GetComponent<PlayerController> ().viewAmmo());

		//hud[0].text = (player.GetComponent<PlayerController>().viewHealth()).ToString();
		//hud[1].text = (player.GetComponent<PlayerController>().viewAmmo()).ToString();
	}
}
