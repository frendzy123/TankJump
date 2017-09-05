using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentMovement : MonoBehaviour {

	public bool vertical;
	public bool horizontal;
	public float speed;
	public float distance;
	public int delay;
	Vector3 startingPosition;

	private bool back = true;

	// Use this for initialization
	void Start () 
	{
		speed = 0.04f;
		startingPosition = gameObject.transform.position;
		delay = 5;
		distance = 3.0f;
	}
	
	// Update is called once per frame
	void Update () 
	{

		if (vertical) 
		{
			
			StartCoroutine ("VerticalMovement");
		}
		else if (horizontal)
		{

			StartCoroutine ("HorizontalMovement");
		}
	}

	IEnumerator VerticalMovement()
	{
		

		if (gameObject.transform.position.y < startingPosition.y + distance && back) {
			
			gameObject.transform.position += Vector3.up * speed;
		} 

		else 
		{

			back = false;
		}

		if (gameObject.transform.position.y > startingPosition.y && !back) {

			gameObject.transform.position += Vector3.up * -speed;
		}

		else 
		{

			back = true;
		}

		yield return new WaitForSeconds (delay);
	}

	IEnumerator HorizontalMovement()
	{

		if (gameObject.transform.position.x < startingPosition.x + distance && back) {

			gameObject.transform.position += Vector3.right * speed;
			//Debug.Log (1);
		} 

		else 
		{

			back = false;
		}

		if (gameObject.transform.position.x > startingPosition.x && !back) {

			gameObject.transform.position += Vector3.right * -speed;
			//Debug.Log (0);
		}

		else 
		{

			back = true;
		}

		yield return new WaitForSeconds (delay);
	}
}
