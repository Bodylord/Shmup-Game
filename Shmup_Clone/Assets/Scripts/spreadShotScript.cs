using UnityEngine;
using System.Collections;

public class spreadShotScript : MonoBehaviour {
	
	
	public float Speed;
	public float attackSpawn;
	
	//Bullet Delays + Speeds
	public float bulletspeed;
	public float nextFire;
	public float fireRate;
	
	//Arrays
	public GameObject[] shipAttacks;
	
	public enum shipType
	{
		Red,
		Blue,
		Green,
	}
	//Setting which shipType is active
	public shipType shipCurrent;
	
	public GameObject shipModel;

	private shootingScript colorState;
	
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		colorState = GameObject.Find ("mainBarrel").GetComponent<shootingScript>();

		if (colorState.shipCurrent == shootingScript.shipType.Red)
		{
			shipCurrent = shipType.Red;
		}
		
		if (colorState.shipCurrent == shootingScript.shipType.Blue)
		{
			shipCurrent = shipType.Blue;
		}
		
		if (colorState.shipCurrent == shootingScript.shipType.Green)
		{
			shipCurrent = shipType.Green;
		}
		
		// Ship shooting with different colors
		
		
		if (Input.GetKey (KeyCode.UpArrow))
		{
			if(shipCurrent == shipType.Red && Time.time > nextFire)
			{
				nextFire = Time.time + fireRate;
				RedAtk();
			}
			
			else if(shipCurrent == shipType.Green)
			{
				GrenAtk();				
			}
			
		}
		
		if (Input.GetKeyDown(KeyCode.UpArrow))
		{
			if(shipCurrent == shipType.Blue)
			{

				BluAtk();
			}
		}
		
	}
	
	void RedAtk()
	{
		Instantiate(shipAttacks[0], new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation);
	}
	
	void BluAtk()
	{
		if (GameObject.Find("BlueLaser") == null)
		{
			GameObject blulaser = Instantiate(shipAttacks[1], new Vector3(transform.position.x, transform.position.y + attackSpawn, transform.position.z), transform.rotation) as GameObject;
			
			blulaser.transform.parent = this.transform;
			
		}
	}
	
	void GrenAtk()
	{
		if (GameObject.Find("GreenBall") == null)
		{
			GameObject grenball = Instantiate(shipAttacks[2], new Vector3(transform.position.x, transform.position.y + attackSpawn, transform.position.z), transform.rotation) as GameObject;
			
			grenball.transform.parent = this.transform;
		}
	}
	
}