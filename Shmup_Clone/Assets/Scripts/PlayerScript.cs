using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {


//Ship Properties
	public int HP;
	public int Armor;
	public int shipCollisionDmg = 5;
	public float Speed;

//Initial HP when the Player ship respawns
	public int initHP = 10;

//Ship GameObject goes here
	public GameObject playerShip;

//Enemy's damaging Bullet
	public GameObject EnemyBullet;

//Lifemanager script
	public LifeManager lm;

//Player ship movement 'animation'
	public Sprite[] shipSpriteMovements;

		// Use this for initialization
	void Start () {
	
	gameObject.GetComponent<SpriteRenderer>().sprite = shipSpriteMovements[0];

	}
	
	// Update is called once per frame
	void Update () {
	

//Player Ship Controls
		if (Input.GetKey(KeyCode.W))
		{
			gameObject.GetComponent<SpriteRenderer>().sprite = shipSpriteMovements[1];
			transform.Translate(Vector3.up * Speed);
		}

		if(Input.GetKey(KeyCode.A))
		{
			gameObject.GetComponent<SpriteRenderer>().sprite = shipSpriteMovements[3];
			transform.Translate(Vector3.left * Speed);
		}

		if (Input.GetKey(KeyCode.S))
		{
			gameObject.GetComponent<SpriteRenderer>().sprite = shipSpriteMovements[2];
			transform.Translate(Vector3.down * Speed);
		}

		if (Input.GetKey(KeyCode.D))
		{
			gameObject.GetComponent<SpriteRenderer>().sprite = shipSpriteMovements[4];
			transform.Translate(Vector3.right * Speed);
		}

		if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.D))
		{
			gameObject.GetComponent<SpriteRenderer>().sprite = shipSpriteMovements[0];
		}

//Ship lives, damage and mitigating damage conditions
	if (HP <= 0)
		{
			
			lm = GameObject.Find ("Game Manager").GetComponent<LifeManager>();

			lm.Lives--;
			RespawnShip();

		}

	}

//Mitigating Damage function
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

//Taking Damage that called MitigateDmg function
	public void TakeDamage(int enemyDmg){

		int ActualDamage = MitigateDmg(enemyDmg);
		
		HP -= ActualDamage;
		}

//Respawning the Player ship
	public void RespawnShip(){

		HP = initHP;
		playerShip.transform.position = Vector3.zero ;
	}

//Colliding with the Enemy bullet and Enemy Ships causing Damage
	public void OnTriggerEnter2D (Collider2D col){

		if (col.gameObject.tag == "Enemy_Bullet")
		{
			TakeDamage(col.gameObject.GetComponent<Enemy_Bullet>().enemyDamage);

			print("player hit");
		}

		if (col.gameObject.tag == "Enemy")
			{
				
				/*shipLife = GameObject.Find ("enemyShipWeak").GetComponent<Enemy_Script>();

				shipLife.TakeDamage(shipCollisionDmg); */

				TakeDamage(col.gameObject.GetComponent<Enemy_Script>().shipCollisionDmg);
				
				print("player hit!");
				
			}
			
		}
}