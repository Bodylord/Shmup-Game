using UnityEngine;
using System.Collections;

public class Enemy_Script : MonoBehaviour {

	//Enemy Stats
	public int HP;
	public int Armor;
	public int seekRange;
	public int shipCollisionDmg = 10;

	//enemy firerate
	public float timerLength = 1f;
	public float timer;

	//enemy lifeTime
	public float enemyLifetime = 50f;
	public float enemyTimer;

	//Enemy Score Given
	public int weakShipScore = 5;
	public int strongShipScore = 10;

	//references
	public GameObject self;
	public GameObject playerShip;
	public GameObject playerBullet;
	public GameObject Enemy_Bullet;


	public Bullet playershipBullet;
	public Player_HealthScript shipLife;
	public LifeManager dead;
	public ScoreGui Scoreherepls;
	public Enemy_Bullet enemyBullet;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		//timer for firing bullets
		if (timer < 0.0f)
		{
			//enemy shoot
			fireBullet();
			
			timer = timerLength;
		}
		timer -= Time.deltaTime;

		//timer for ship life time
		if (enemyTimer < 0.0f)
		{
			//Destroy(gameObject);
			
			enemyTimer = enemyLifetime;
		}
		enemyTimer -= Time.deltaTime;

		//enemy death, adding score and deathcount
		if (HP <= 0)
		{
			Scoreherepls = GameObject.Find ("Score GUI").GetComponent<ScoreGui>();			
			dead = GameObject.Find ("Game Manager").GetComponent<LifeManager>();

			Scoreherepls.AddScore(5);
			dead.EnemyDeaths++;
			Destroy(gameObject);

		}

	}

	public int MitigateDmg(int wedmgnow){
		if(wedmgnow > Armor)
		{
			return wedmgnow - Armor;
		}
	
		else
		{
			return 0;
		}
	}

	public void TakeDamage(int enemyDmg){

		int ActualDamage = MitigateDmg(enemyDmg);
		
		HP -= ActualDamage;
		}

	public void fireBullet(){

		//GameObject bul = Instantiate (Enemy_Bullet, new Vector3(transform.position.x, transform.position.y - 0.5f, transform.position.z), Quaternion.identity) as GameObject;
	}

	void OnTriggerEnter(Collider col)
		{

		if (col.gameObject.tag == "Player_Bullet")
			{
			
			//playershipBullet = GameObject.Find ("Bullet").GetComponent<Bullet>();

				TakeDamage(col.gameObject.GetComponent<Bullet>().playerDamage);
				
				print("ow");
			}

		if (col.gameObject.tag.Contains("Player_Ship"))
			{
			
			shipLife = GameObject.Find ("playerShip").GetComponent<Player_HealthScript>();

				shipLife.TakeDamage(shipCollisionDmg); 

				Destroy(gameObject);

				print("player hit!");

			}
	}
}