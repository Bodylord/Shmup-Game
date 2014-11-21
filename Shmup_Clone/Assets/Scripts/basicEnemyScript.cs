using UnityEngine;
using System.Collections;

public class basicEnemyScript : MonoBehaviour {

	public Color[] enemyColors;


	public enum enemyType
	{
		Red,
		Blue,
		Green,
	}

	public enemyType enemyCurrent;

	public int randomNumber;

	public Transform playerShipAsTarget;

	private int id;

	private enemyTailScript SnakeTail;

	private LifeManager lm;

	//player bullet types for upgrades

	private Green_Ball GreenBall;
	private shootingScript RedBallrate;
	private spreadShotScript RedBallSpread;
	private Red_Ball RedBall;
	private Blue_Laser BlueLaser;

	// Use this for initialization
	void Start () {
		print ("my transform " + transform.position);
		randomNumber = Random.Range(0,3);

		gameObject.name = "Snake_Head " + GameObject.Find ("EnemySpawner").GetComponent<enemySpawning>().id;

		id = GameObject.Find ("EnemySpawner").GetComponent<enemySpawning>().id;

		gameObject.renderer.material.color = enemyColors[randomNumber];


		if(randomNumber == 0)
		{
			gameObject.tag = "Red";
			enemyCurrent = enemyType.Red;
		}
		if (randomNumber == 1)
		{
			gameObject.tag = "Blue";
			enemyCurrent = enemyType.Blue;
		}
		if (randomNumber == 2)
		{
			gameObject.tag = "Green";
			enemyCurrent = enemyType.Green;
		}

	}
	
	// Update is called once per frame
	void Update () {	

//		Quaternion rotation = Quaternion.LookRotation (playerShipAsTarget.transform.position - transform.position, transform.TransformDirection(playerShipAsTarget.position));
//		transform.rotation = new Quaternion(0, 0, rotation.z, rotation.w);

		Vector3 diff = playerShipAsTarget.position - transform.position;
		diff.Normalize();
		
		float rot = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler(0f, 0f, rot-90);

		transform.Translate (Vector3.down *3 * Time.deltaTime, Space.World);
	}

	void OnTriggerEnter2D (Collider2D hit)
	{

		lm = GameObject.Find("Game Manager").GetComponent<LifeManager>();
		RedBallrate = GameObject.FindObjectOfType<shootingScript>() as shootingScript;
		spreadShotScript[] RedBallSpread = GameObject.FindObjectsOfType<spreadShotScript>() as spreadShotScript[];

		if(hit.tag == "Red_Projectile" && this.gameObject.tag == "Red")
		{
			print("ow red");
			enemyTailScript[] tailScripts = GameObject.FindObjectsOfType<enemyTailScript>()  as enemyTailScript[];
			foreach (enemyTailScript t in tailScripts)
			{
				if (t.gameObject.name.Equals ("Snake Tail " + id))
				{
					Destroy(t.gameObject);
					lm.EnemyDeaths ++;
					RedBallrate.fireRate -= 0.02f;
					RedBallSpread[0].fireRate -= 0.02f;
					RedBallSpread[1].fireRate -= 0.02f;
					Red_Ball.Speed += 2f;
					Red_Ball.bulletWidth += 0.004f;
				}
			}
			lm.EnemyDeaths ++;
			RedBallrate.fireRate -= 0.02f;
			RedBallSpread[0].fireRate -= 0.02f;
			RedBallSpread[1].fireRate -= 0.02f;
			Red_Ball.Speed += 2f;
			Red_Ball.bulletWidth += 0.004f;
			Destroy(gameObject);

			//SnakeTail.gameObject.GetComponent<enemyTailScript>().isHeadDead = true;
		}
		
		if(hit.tag == "Blue_Projectile" && this.gameObject.tag == "Blue")
		{
			print("ow blue");
			enemyTailScript[] tailScripts = GameObject.FindObjectsOfType<enemyTailScript>()  as enemyTailScript[];
			foreach (enemyTailScript t in tailScripts)
			{
				if (t.gameObject.name.Equals ("Snake Tail " + id))
				{
					Blue_Laser.maxLaserScale += 0.02f;
					Blue_Laser.laserSpeed += 0.02f;
					Blue_Laser.laserWidth += 0.005f;
					lm.EnemyDeaths ++;
					Destroy(t.gameObject);

				}
			}
			Blue_Laser.maxLaserScale += 0.02f;
			Blue_Laser.laserSpeed += 0.02f;
			Blue_Laser.laserWidth += 0.005f;
			lm.EnemyDeaths ++;
			Destroy(gameObject);

		}
		
		if(hit.tag == "Green_Projectile" && this.gameObject.tag == "Green")
		{
			print("ow green");
			enemyTailScript[] tailScripts = GameObject.FindObjectsOfType<enemyTailScript>()  as enemyTailScript[];
			foreach (enemyTailScript t in tailScripts)
			{
				if (t.gameObject.name.Equals ("Snake Tail " + id))
				{
					Green_Ball.Speed += 0.05f;
					Green_Ball.explosionSize += 0.02f;
					Green_Ball.explosionSpeed += 0.04f;
					lm.EnemyDeaths ++;
					Destroy(t.gameObject);

				}
			}
			Green_Ball.Speed += 0.05f;
			Green_Ball.explosionSize += 0.02f;
			Green_Ball.explosionSpeed += 0.04f;
			lm.EnemyDeaths ++;
			Destroy(gameObject);


		}
	}
}