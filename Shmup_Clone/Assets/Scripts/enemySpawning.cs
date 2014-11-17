using UnityEngine;
using System.Collections;

public class enemySpawning : MonoBehaviour {

	public GameObject snakePartLarge;
	public GameObject snakePartSmall;

	public Vector3[] spawnLocations;
	
	public bool headIsSpawned;

	public int id;


	// Use this for initialization
	void Start () {
		id = 0;
		headIsSpawned = false;
	
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown(KeyCode.Z))
		{
			if (headIsSpawned == false)
			{
				id++;
				createSnakeChain();
				
				print("hello");
				
				headIsSpawned = true;
			}
			
		}
		if (headIsSpawned == true)
		{
			StartCoroutine(delaySpawn(0.1f));
			StartCoroutine(delaySpawn(0.2f));
			StartCoroutine(delaySpawn(0.3f));
			StartCoroutine(delaySpawn(0.4f));
			headIsSpawned = false;
		}
		
		
	}

	void createSnakeChain()
	{
		//Creating snake head
		
		Instantiate(snakePartLarge, spawnLocations[0], transform.rotation);
		
	}
	
	IEnumerator delaySpawn(float enemySpacing)
	{
		
		yield return new WaitForSeconds(enemySpacing);
		
		Instantiate(snakePartSmall, spawnLocations[0], transform.rotation);
				
	}
}
