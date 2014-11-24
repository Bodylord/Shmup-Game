using UnityEngine;
using System.Collections;

public class shootingScript : MonoBehaviour {
	
	
	public float Speed;
	public float attackSpawn;
	
	//Bullet Delays + Speeds
	public float bulletspeed;
	public float nextFire;
	public float fireRate;
	
	//Arrays
	public SpriteRenderer[] muzzleTypes;
	public GameObject[] shipAttacks;
	public Color[] shipColors;
	public GameObject[] Barrels;
	
	public enum shipType
	{
		Red,
		Blue,
		Green,
	}
	//Setting which shipType is active

	public shipType shipCurrent;
	
	public GameObject shipModel;

	private Green_Ball GreenBall;
	private shootingScript RedBallrate;
	private spreadShotScript RedBallSpread;
	private Red_Ball RedBall;
	private Blue_Laser BlueLaser;
	
	
	// Use this for initialization
	void Start () {

		shipCurrent = shipType.Red;
		shipModel.gameObject.GetComponent<SpriteRenderer>().color = shipColors[0];
		
	}
	
	// Update is called once per frame
	void Update () {

		RedBallrate = GameObject.FindObjectOfType<shootingScript>() as shootingScript;
		spreadShotScript[] RedBallSpread = GameObject.FindObjectsOfType<spreadShotScript>() as spreadShotScript[];
		
		if (Input.GetKeyDown (KeyCode.LeftArrow))
		{
			shipCurrent = shipType.Red;
			shipModel.gameObject.GetComponent<SpriteRenderer>().color = shipColors[0];
		}
		
		if (Input.GetKeyDown (KeyCode.DownArrow))
		{
			shipCurrent = shipType.Blue;
			shipModel.gameObject.GetComponent<SpriteRenderer>().color = shipColors[1];
		}
		
		if (Input.GetKeyDown (KeyCode.RightArrow))
		{
			shipCurrent = shipType.Green;
			shipModel.gameObject.GetComponent<SpriteRenderer>().color = shipColors[2];
		}
		
		// Ship shooting with different colors
		
		
		if (Input.GetKey (KeyCode.UpArrow))
		{
			if(shipCurrent == shipType.Red && Time.time > nextFire)
			{
				nextFire = Time.time + fireRate;
				muzzleTypes[0].enabled = true;
				RedAtk();
			}
			
			else if(shipCurrent == shipType.Green)
			{
				muzzleTypes[2].enabled = true;
				GrenAtk();
				
			}
			
		}
		
		if (Input.GetKeyDown(KeyCode.UpArrow))
		{
			if(shipCurrent == shipType.Blue)
			{
				muzzleTypes[1].enabled = true;
				BluAtk();
			}
		}
		
		if (Input.GetKeyUp (KeyCode.UpArrow))
		{
			muzzleTypes[0].enabled = false;
			muzzleTypes[1].enabled = false;
			muzzleTypes[2].enabled = false;
		}
		

		//Spread shot debug key
		if (Input.GetKeyDown(KeyCode.Space))
		{
			Barrels[0].gameObject.GetComponent<spreadShotScript>().enabled = true;

			Barrels[1].gameObject.GetComponent<spreadShotScript>().enabled = true;
		}

		//Weapon Steroids debug

		//red
		if(Input.GetKeyDown (KeyCode.Alpha1))
		{
			RedBallrate.fireRate -= 1f;
			RedBallSpread[0].fireRate -= 1f;
			RedBallSpread[1].fireRate -= 1f;
			Red_Ball.Speed += 5f;
			Red_Ball.bulletWidth += 1f;
		}

		//blue
		if(Input.GetKeyDown (KeyCode.Alpha2))
		{
			Blue_Laser.maxLaserScale += 1f;
			Blue_Laser.laserSpeed += 1f;
			Blue_Laser.laserWidth += 1f;
		}

		//green
		if(Input.GetKeyDown (KeyCode.Alpha3))
		{
			Green_Ball.Speed += 1f;
			Green_Ball.explosionSize += 1f;
			Green_Ball.explosionSpeed += 1f;
		}

	}
	
	void RedAtk()
	{
		Instantiate(shipAttacks[0], new Vector3(transform.position.x, transform.position.y + attackSpawn, transform.position.z), Quaternion.identity);
	}
	
	void BluAtk()
	{
		if (GameObject.Find("BlueLaser") == null)
		{
			GameObject blulaser = Instantiate(shipAttacks[1], new Vector3(transform.position.x, transform.position.y + attackSpawn, transform.position.z), Quaternion.identity) as GameObject;

			blulaser.transform.parent = this.transform;

		}
	}
	
	void GrenAtk()
	{
		if (GameObject.Find("GreenBall") == null)
		{
			GameObject grenball = Instantiate(shipAttacks[2], new Vector3(transform.position.x, transform.position.y + attackSpawn, transform.position.z), Quaternion.identity) as GameObject;

			grenball.transform.parent = this.transform;
		}
	}
	
}