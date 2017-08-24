using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ColorToPrefab {
	public Color32 color;
	public GameObject prefab;
}

public class LevelEditor : MonoBehaviour {

	public Texture2D level;
	private int levelNumber;
	private string levelPath;

	public ColorToPrefab[] colorMappings;

	// Use this for initialization
	void Awake ()
	{

		//level = Resources.Load("Levels/Level1") as Texture2D;
		LoadLevel();
	}

	void Start () 
	{
		
		levelNumber = 1;
		levelPath = "Levels/Level";
	}

	private void LoadLevel() {
		EmptyLevel();

		Color32[] allPixels = level.GetPixels32();
		int width = level.width;
		int height = level.height;

		for (int x = 0; x < width; x++) {
			for (int y = 0; y < height; y++) {
				GenerateTile(allPixels[(y * width) + x], x, y);
			}	
		}

	}

	private void EmptyLevel() {
		//Finds and destroys all tiles
		while (transform.childCount > 0) {
			Transform c = transform.GetChild(0); //Gets first child
			c.SetParent (null); //makes child orphan
			Destroy (c.gameObject);//destroys child 
		}
	}


	private void GenerateTile(Color32 c, int x, int y) 
	{
		
		if (c.a <= 0) {
			return;
		}

		foreach (ColorToPrefab colorMapping in colorMappings) 
		{
			
			if (colorMapping.color.Equals(c)) 
			{
				
				//Debug.Log (colorMapping.color);
				Instantiate (colorMapping.prefab, new Vector2 (x, y), Quaternion.identity, transform);
				return;
			}	
		}

		//Debug.LogError ("No color found: "+ c.ToString()+ " at x: "+x.ToString()+" and y: "+ y.ToString());
	}

	public void nextLevel()
	{

		levelNumber += 1;
		string path = levelPath + levelNumber.ToString();
		level = Resources.Load(path) as Texture2D;
		LoadLevel();
	}
}
