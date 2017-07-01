using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour {

	// Use this for initialization
	void Start() 
	{
		
	}
	
	// Update is called once per frame
	void Update() 
	{

		Aim();
	}

	// Function that rotates turret to face cursor.
	void Aim()
	{

		Vector3 mousePos = Input.mousePosition; //Obtain mouse position
		mousePos.z = 5f;
		Vector3 objectPos = Camera.main.WorldToScreenPoint(transform.position); //Get coordinates of turret

		mousePos.x = mousePos.x - objectPos.x;
		mousePos.y = mousePos.y - objectPos.y;

		float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg; //Calculate angle in rads using tan of x and y
		transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
	}
}
