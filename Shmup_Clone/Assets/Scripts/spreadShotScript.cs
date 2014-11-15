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
	
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetKeyDown (KeyCode.LeftArrow))
		{
			shipCurrent = shipType.Red;
		}
		
		if (Input.GetKeyDown (KeyCode.DownArrow))
		{
			shipCurrent = shipType.Blue;
		}
		
		if (Input.GetKeyDown (KeyCode.RightArrow))
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
			Instantiate(shipAttacks[1], new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation);
		}
	}
	
	void GrenAtk()
	{
		if (GameObject.Find("GreenBall") == null)
		{
			Instantiate(shipAttacks[2], new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation);
		}
	}
	
}