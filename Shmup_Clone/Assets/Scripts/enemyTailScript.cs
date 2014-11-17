using UnityEngine;
using System.Collections;

public class enemyTailScript : MonoBehaviour {

	public enum enemyType
	{
		Red,
		Blue,
		Green,
	}
	
	public enemyType enemyCurrent;

	public basicEnemyScript snakeHead;

	// Use this for initialization
	void Start () {
	
		gameObject.name = "Snake_Tail";
		
		childColorMatch();

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void childColorMatch()
	{
		
		snakeHead = GameObject.Find ("Snake_Head").GetComponent<basicEnemyScript>();


			if(snakeHead.enemyCurrent == basicEnemyScript.enemyType.Red)
			{
				enemyCurrent = enemyType.Red;
				gameObject.renderer.material.color = Color.red;
			}
			
			if(snakeHead.enemyCurrent == basicEnemyScript.enemyType.Blue)
			{
				enemyCurrent = enemyType.Blue;
				gameObject.renderer.material.color = Color.blue;
			}
			
			if(snakeHead.enemyCurrent == basicEnemyScript.enemyType.Green)
			{
				enemyCurrent = enemyType.Green;
				gameObject.renderer.material.color = Color.green;
			}

	}	
}
