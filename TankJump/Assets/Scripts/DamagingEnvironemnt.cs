using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagingEnvironemnt : MonoBehaviour {

	public int damage;
	public int damageDelay;
	private bool on;

	// Use this for initialization
	void Start () {
		
		damage = 20;
		damageDelay = 2;
		on = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionStay2D(Collision2D coll)
	{

		if(coll.gameObject.tag == "Player") 
		{
			if(on) 
			{

				on = false;
				coll.gameObject.GetComponent<PlayerController> ().changeHealth(-damage);
				Invoke ("Delay", damageDelay);
			}
		}
	}

	void Delay(){
		on = true;
	}
}