using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalPost : MonoBehaviour {

	private LevelEditor levelEditor;

	// Use this for initialization
	void Start()
	{

		levelEditor = GameObject.FindWithTag("LevelEditor").GetComponent<LevelEditor>();
	}
	
	// Update is called once per frame
	void Update() 
	{
		
	}

	void OnTriggerEnter2D(Collider2D col)
	{

		if (col.GetComponent<Collider2D>().tag == "Player") 
		{

			levelEditor.nextLevel();
		}
	}
}
