using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagingEnvironemnt : MonoBehaviour {

	public int damage;
	public int damageDelay;

	// Use this for initialization
	void Start () {
		
		damage = 20;
		damageDelay = 2;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionStay2D(Collision2D coll)
	{

		if(coll.gameObject.tag == "Player") 
		{
			
			coll.gameObject.GetComponent<PlayerMovement>().DealDamage(-damage);
		}
	}
}