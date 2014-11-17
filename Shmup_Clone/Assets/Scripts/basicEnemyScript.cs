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

		gameObject.name = "Snake_Head";

		gameObject.renderer.material.color = enemyColors[randomNumber];


		if(randomNumber == 0)
		{
			gameObject.tag = "Red";
			gameObject.name = "Snake_Head_Red";
			enemyCurrent = enemyType.Red;
		}
		if (randomNumber == 1)
		{
			gameObject.tag = "Blue";
			gameObject.name = "Snake_Head_Blue";
			enemyCurrent = enemyType.Blue;
		}
		if (randomNumber == 2)
		{
			gameObject.tag = "Green";
			gameObject.name = "Snake_Head_Green";
			enemyCurrent = enemyType.Green;
		}

	}
	
	// Update is called once per frame
	void Update () {	

		transform.Translate (Vector3.down *3 * Time.deltaTime, Space.Self);
	}

	void OnTriggerEnter(Collider hit)
	{
		if(hit.gameObject.tag == "Green")
		{
			print("ow");
			Destroy(gameObject);
		}
		
	}
}