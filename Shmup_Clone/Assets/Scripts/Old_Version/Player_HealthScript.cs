using UnityEngine;
using System.Collections;

public class Player_HealthScript : MonoBehaviour {

	public int HP;
	public int Armor;
	public int shipCollisionDmg = 5;

	public GameObject playerShip;
	public GameObject EnemyBullet;
	public Bullet bulletscript;
	public Enemy_Bullet enemybullethere;
	public LifeManager lm;
	public Enemy_Script shipLife;

	private int initHP = 10;

	public bool canTakeDamage;

	// Use this for initialization
	void Start () {

		canTakeDamage = true;

		initHP = HP;

	}
	
	// Update is called once per frame
	void Update () {

		//killing player debug
		if(Input.GetKeyDown(KeyCode.Alpha1))
		{
			HP = 0;
		}


		if (HP <= 0)
		{
			
			lm = GameObject.Find ("Game Manager").GetComponent<LifeManager>();

			lm.Lives--;
			RespawnShip();

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

	public void RespawnShip(){

		HP = initHP;
		playerShip.transform.position = Vector3.zero;
		shipInvulnFlash();

		canTakeDamage = true;

	}

	public void OnTriggerEnter(Collider col){

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

	IEnumerator shipInvulnFlash()
		{
			
			canTakeDamage = false;

			yield return new WaitForSeconds(1);
			this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
			yield return new WaitForSeconds(1);
			this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
			yield return new WaitForSeconds(1);
			this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
			yield return new WaitForSeconds(1);
			this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
		}

	}
