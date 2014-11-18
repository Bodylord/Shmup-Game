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

	// Use this for initialization
	void Start () {

		randomNumber = Random.Range(0,3);

		gameObject.name = "Snake_Head " + GameObject.Find ("EnemySpawner").GetComponent<enemySpawning>().id;

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

		transform.Translate (Vector3.down *3 * Time.deltaTime, Space.World);
	}

	void OnTriggerEnter2D (Collider2D hit)
	{
		if(hit.tag == "Red_Projectile" && this.gameObject.tag == "Red")
		{
			print("ow red");
			Destroy(gameObject);
		}
		
		if(hit.tag == "Blue_Projectile" && this.gameObject.tag == "Blue")
		{
			print("ow blue");
			Destroy(gameObject);
		}
		
		if(hit.tag == "Green_Projectile" && this.gameObject.tag == "Green")
		{
			print("ow green");
			Destroy(gameObject);
		}
	}
}