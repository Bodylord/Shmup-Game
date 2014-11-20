using UnityEngine;
using System.Collections;

public class enemySpawning : MonoBehaviour {

	public GameObject snakePartLarge;
	public GameObject snakePartSmall;

	public Vector3[] spawnLocations;
	public Animation sideAnimation;
	public int spawnPoint; 

	public bool headIsSpawned;

	public int id;

	public int counter = 0;
	public int snakeTailLength;


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
				headIsSpawned = true;
			}
			
		}


		/*
		while (counter < snakeTailLength && headIsSpawned == true)
		{
			StartCoroutine(delaySpawn(0.1f));
			StartCoroutine(delaySpawn(0.2f));
			StartCoroutine(delaySpawn(0.3f));
			StartCoroutine(delaySpawn(0.4f));
			counter++;
			//headIsSpawned = false;

		}
		*/


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
		spawnPoint = Random.Range (0, spawnLocations.Length);
		GameObject snakeHead = Instantiate(snakePartLarge, spawnLocations[spawnPoint], transform.rotation) as GameObject;
		Animator headAnim = snakeHead.GetComponentInChildren<Animator>();

		print ("spawnPoint = " + spawnPoint + " spawn location  = " + spawnLocations[spawnPoint]);

		if (spawnPoint >= 0 && spawnPoint <= 6)
		{
			int[] topClips = { 1, 2, 5, 6 };
			headAnim.SetInteger ("pattern", topClips[Random.Range (0, topClips.Length)]);
		}


		if (spawnPoint >= 7 && spawnPoint <= 11)
		{
			int[] rightClips = {3};
			headAnim.SetInteger ("pattern", rightClips[Random.Range (0, rightClips.Length)]);
		}


		if (spawnPoint >= 12 && spawnPoint <= 16)
		{
			int[] leftClips = {3};
			headAnim.SetInteger ("pattern", leftClips[Random.Range (0, leftClips.Length)]);
		}

		if (spawnPoint >= 17 && spawnPoint <= 23)
		{
			int[] bottomClips = {4, 7};
			headAnim.SetInteger ("pattern", bottomClips[Random.Range (0, bottomClips.Length)]);
		}

		print("Animation "  + headAnim.GetInteger("pattern"));

	}
	
	IEnumerator delaySpawn(float enemySpacing)
	{
		
		yield return new WaitForSeconds(enemySpacing);
		
		Instantiate(snakePartSmall, spawnLocations[0], transform.rotation);
				
	}
}
