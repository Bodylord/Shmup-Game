using UnityEngine;
using System.Collections;

public class largeEnemyMovement : MonoBehaviour {

	public Color[] enemyColors;

	public enum enemyType
	{
		Red,
		Blue,
		Green,
	}
	
	public enemyType enemyCurrent;

	public int randomNumber;
	public float shipSpeed = 1f;

	public float Travelled = 0;
	public float LifeTime = 50f;

	private enemySpawning enemySpawn;
	private Green_Ball GreenBall;
	private shootingScript RedBallrate;
	private spreadShotScript RedBallSpread;
	private Red_Ball RedBall;
	private Blue_Laser BlueLaser;
	private LifeManager lm;

	// Use this for initialization
	void Start () {

		randomNumber = Random.Range(0,3);
		
		gameObject.renderer.material.color = enemyColors[randomNumber];

		gameObject.name = "Large_Enemy " + GameObject.Find ("EnemySpawner").GetComponent<enemySpawning>().largeId;
	}
	
	// Update is called once per frame
	void Update () {


		enemySpawn = GameObject.Find("EnemySpawner").GetComponent<enemySpawning>();

		largeEnemyMovement[] largeEnemyMovements = GameObject.FindObjectsOfType<largeEnemyMovement>()  as largeEnemyMovement[];
		foreach (largeEnemyMovement t in largeEnemyMovements)
		{
			if(t.gameObject.name.Equals ("Large_Enemy " + GameObject.Find ("EnemySpawner").GetComponent<enemySpawning>().largeId) && enemySpawn.randomLargeSpawner == 7)
			{
				transform.Translate (Vector3.left * shipSpeed * Time.deltaTime);
			}
			else if (t.gameObject.name.Equals ("Large_Enemy " + GameObject.Find ("EnemySpawner").GetComponent<enemySpawning>().largeId) && enemySpawn.randomLargeSpawner == 12)
			{
				transform.Translate (Vector3.right * shipSpeed * Time.deltaTime);
			}
		}
		//color tagging

		
		if (randomNumber == 0)
		{
			enemyCurrent = enemyType.Red;
			gameObject.tag = "Red";
		}
		
		if (randomNumber == 1)
		{
			enemyCurrent = enemyType.Blue;
			gameObject.tag = "Blue";
		}
		
		if (randomNumber == 2)
		{
			enemyCurrent = enemyType.Green;
			gameObject.tag = "Green";
		}

		// self-destruction
		Travelled += 0.01f;
		
		if (Travelled >= LifeTime)
		{
			StartCoroutine(FlyUpwards());
		}
	
	}

	void OnTriggerEnter2D (Collider2D hit)
	{
		enemySpawn = GameObject.Find("EnemySpawner").GetComponent<enemySpawning>();

		if(hit.tag == "Red_Projectile" && enemyCurrent == enemyType.Red)
		{
			print("ow big red");
			enemySpawn.largeEnemyDeaths ++;
			Destroy(gameObject);
		}
		
		if(hit.tag == "Blue_Projectile" && enemyCurrent == enemyType.Blue)
		{
			print("ow big blue");
			enemySpawn.largeEnemyDeaths ++;
			Destroy(gameObject);
			
		}
		
		if(hit.tag == "Green_Projectile" && enemyCurrent == enemyType.Green)
		{
			print("ow big green");
			enemySpawn.largeEnemyDeaths ++;
			Destroy(gameObject);
						
		}
	}

	IEnumerator FlyUpwards()
	{
		transform.Translate(Vector3.up * shipSpeed * Time.deltaTime);

		yield return new WaitForSeconds(2);

		Destroy(gameObject);
	}
}
