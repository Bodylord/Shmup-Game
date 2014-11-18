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

	public bool isHeadDead;

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
		
		snakeHead = GameObject.Find ("Snake_Head " + GameObject.Find ("EnemySpawner").GetComponent<enemySpawning>().id).GetComponent<basicEnemyScript>();


			if(snakeHead.enemyCurrent == basicEnemyScript.enemyType.Red)
			{
				enemyCurrent = enemyType.Red;
				gameObject.renderer.material.color = Color.red;
				gameObject.tag = "Red";
			}
			
			if(snakeHead.enemyCurrent == basicEnemyScript.enemyType.Blue)
			{
				enemyCurrent = enemyType.Blue;
				gameObject.renderer.material.color = Color.blue;
				gameObject.tag = "Blue";
			}
			
			if(snakeHead.enemyCurrent == basicEnemyScript.enemyType.Green)
			{
				enemyCurrent = enemyType.Green;
				gameObject.renderer.material.color = Color.green;
				gameObject.tag = "Green";
			}

	}

	void OnTriggerEnter2D (Collider2D hit)
	{
		if(hit.tag == "Red_Projectile" && this.gameObject.tag == "Red")
		{
			print("ow red");
			Destroy(gameObject);
		}
		
		if(hit.tag == "Blue_Projectile" && this.gameObject.tag == "Blue")
		{
			print("ow blue");
			Destroy(gameObject);
		}
		
		if(hit.tag == "Green_Projectile" && this.gameObject.tag == "Green")
		{
			print("ow green");
			Destroy(gameObject);
		}
		
	}


}
