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

	public Transform playerShipAsTarget;

	private LifeManager lm;

	// Use this for initialization
	void Start () {
	
		isHeadDead = false;

		gameObject.name = "Snake Tail " + GameObject.Find ("EnemySpawner").GetComponent<enemySpawning>().id;
		
		childColorMatch();

		gameObject.GetComponent<Animator>().SetInteger ("pattern", snakeHead.GetComponent<Animator>().GetInteger("pattern"));

	}
	
	// Update is called once per frame
	void Update () {
	
		if(isHeadDead == true)
		{
			Destroy(this.gameObject);
		}


		Vector3 diff = playerShipAsTarget.position - transform.position;
		diff.Normalize();

		float rot = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler(0f, 0f, rot-90);

	}

	public void childColorMatch()
	{
		snakeHead = GameObject.Find ("Snake_Head " + GameObject.Find ("EnemySpawner").GetComponent<enemySpawning>().id).GetComponent<basicEnemyScript>();

		if (snakeHead == null)
		{
			Destroy(gameObject);
		}

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

		lm = GameObject.Find("Game Manager").GetComponent<LifeManager>();

		if(hit.tag == "Red_Projectile" && this.gameObject.tag == "Red")
		{
			print("ow red");
			Destroy(gameObject);
			lm.EnemyDeaths ++;
		}
		
		if(hit.tag == "Blue_Projectile" && this.gameObject.tag == "Blue")
		{
			print("ow blue");
			Destroy(gameObject);
			lm.EnemyDeaths ++;
		}
		
		if(hit.tag == "Green_Projectile" && this.gameObject.tag == "Green")
		{
			print("ow green");
			Destroy(gameObject);
			lm.EnemyDeaths ++;
		}
		
	}


}
