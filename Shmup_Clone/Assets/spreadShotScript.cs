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
	
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
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
		
		
	}
	
	void RedAtk()
	{
		Instantiate(shipAttacks[0], new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
	}
	
	void BluAtk()
	{
		if (GameObject.Find("BlueLaser") == null)
		{
			Instantiate(shipAttacks[1], new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
		}
	}
	
	void GrenAtk()
	{
		if (GameObject.Find("GreenBall") == null)
		{
			Instantiate(shipAttacks[2], new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
		}
	}
	
}