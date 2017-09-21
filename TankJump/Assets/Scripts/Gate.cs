using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour {

	private GameObject[] switches;
	private int count;
	private bool check = false;

	// Use this for initialization
	void Start () {

		count = 0;
		switches = GameObject.FindGameObjectsWithTag("Switch");
	}
	
	// Update is called once per frame
	void Update () {

		foreach(GameObject obj in switches)
		{

			if (obj != null && !obj.GetComponent<Switch> ().active) 
			{

				break;
			}

			count += 1;
		}

		if (count == switches.Length) 
		{
			
			Destroy (this.gameObject);
		} 

		else 
		{

			count = 0;
		}
	}
}
	
