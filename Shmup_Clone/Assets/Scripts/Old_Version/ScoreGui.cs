using UnityEngine;
using System.Collections;

public class ScoreGui : MonoBehaviour {
	
	public int ScoreTotal;

	// Use this for initialization
	void Start () {

		ScoreTotal = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
		guiText.text = "SCORE: " + ScoreTotal;

	}

	public void AddScore(int enemyValue)
	{
		ScoreTotal = ScoreTotal + enemyValue;
	}
}
