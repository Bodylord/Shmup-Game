using UnityEngine;
using System.Collections;

public class bossWeakPoint : MonoBehaviour {

	public Color[] enemyColors;
	public enum enemyType
	{
		Red,
		Blue,
		Green,
	}
	
	public enemyType enemyCurrent;

	public int randomNumber;
	public int randomNumberStage2;
	public int randomNumberStage3;

	// Use this for initialization
	void Start () {
	
		randomNumber = Random.Range(0,3);

		gameObject.renderer.material.color = enemyColors[randomNumber];

	}
	
	// Update is called once per frame
	void Update () {
	
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
		

	}


	void OnTriggerEnter2D (Collider2D hit)
	{
		
		if(hit.tag == "Red_Projectile" && this.gameObject.tag == "Red")
		{
			print("boss red hit");
			gameObject.GetComponent<SpriteRenderer>().enabled = false;
		}
		
		if(hit.tag == "Blue_Projectile" && this.gameObject.tag == "Blue")
		{
			print("boss blu hit");
			gameObject.GetComponent<SpriteRenderer>().enabled = false;
		}
		
		if(hit.tag == "Green_Projectile" && this.gameObject.tag == "Green")
		{
			print("boss gren hit");
			gameObject.GetComponent<SpriteRenderer>().enabled = false;
		}
	}
}
