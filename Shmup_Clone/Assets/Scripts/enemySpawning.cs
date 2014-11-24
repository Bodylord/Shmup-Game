using UnityEngine;
using System.Collections;

public class enemySpawning : MonoBehaviour {

	public GameObject snakePartLarge;
	public GameObject snakePartSmall;
	public GameObject largeGuy;
	public GameObject Boss;

	public Vector3[] spawnLocations;
	public Animation sideAnimation;

	public int spawnPoint; 
	public int Speed = 5;

	public int[] largeEnemySpawnRange;
	public int largeEnemySpawnRandom;

	public int bossSpawnPoint = 24;


	public bool isHeadSpawned;
	public bool isSpawningEnemy;
	public bool isLargeEnemySpawned;
	public bool isBossSpawned;

	public int id;
	public int largeId;
	public int counter = 0;
	public int snakeTailLength;
	public int randomLargeSpawner;

	public float spawnTimer = 3f;

	public LifeManager lm;

	public int largeEnemyDeaths;


	// Use this for initialization
	void Start () {

		largeEnemyDeaths = 0;
		id = 0;
		largeId = 0;
		isHeadSpawned = false;
		isBossSpawned = false;
		isLargeEnemySpawned = false;


		largeEnemySpawnRange = new int[] { 7, 12};
	
	}
	
	// Update is called once per frame
	void Update () {

		lm = GameObject.Find("Game Manager").GetComponent<LifeManager>();

		//debug
		if (Input.GetKeyDown(KeyCode.Backspace))
		{
			spawnBoss();
		}
		
		if (largeEnemyDeaths >= 5 && !isBossSpawned)
		{
			print("spawning boss");
			spawnBoss();
			isBossSpawned = true;
		}

		if(!isBossSpawned)
		{
			if (!isSpawningEnemy)
			{
			StartCoroutine(spawnNormalEnemy(spawnTimer));
			}

			if ((lm.EnemyDeaths%5 == 0) && lm.EnemyDeaths > 0 && !isLargeEnemySpawned)
			{
				isLargeEnemySpawned = true;
				print("spawning large enemy");
				StartCoroutine(spawnLargeEnemy(spawnTimer + 3));
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


		if (isHeadSpawned == true)
		{
			StartCoroutine(delaySpawn(0.1f));
			StartCoroutine(delaySpawn(0.2f));
			StartCoroutine(delaySpawn(0.3f));
			StartCoroutine(delaySpawn(0.4f));
			isSpawningEnemy = false;
			isHeadSpawned = false;
		}
		
		
	}

	void createSnakeChain()
	{
		//Creating snake head
		spawnPoint = Random.Range (0, spawnLocations.Length);
		GameObject snakeHead = Instantiate(snakePartLarge, spawnLocations[spawnPoint], transform.rotation) as GameObject;
		Animator headAnim = snakeHead.GetComponentInChildren<Animator>();


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



	}




	void spawnBoss()
	{
		GameObject bossEnemy = Instantiate(Boss, spawnLocations[bossSpawnPoint], transform.rotation) as GameObject;
		isBossSpawned = false;
	}

	IEnumerator spawnLargeEnemy(float enemySpacing)
	{
		yield return new WaitForSeconds(enemySpacing);

		randomLargeSpawner = largeEnemySpawnRange[Random.Range (0, largeEnemySpawnRange.Length)];

		largeId ++;
		GameObject largeEnemy = Instantiate(largeGuy, spawnLocations[randomLargeSpawner], transform.rotation) as GameObject;

		isLargeEnemySpawned = false;
		
	}

	IEnumerator delaySpawn(float enemySpacing)
	{
		
		yield return new WaitForSeconds(enemySpacing);
		
		Instantiate(snakePartSmall, spawnLocations[0], transform.rotation);
				
	}

	IEnumerator spawnNormalEnemy(float enemySpawnTime)
	{
		isSpawningEnemy = true;

		yield return new WaitForSeconds(enemySpawnTime);

		if (isHeadSpawned == false)
			{
				id++;
				createSnakeChain();
				isHeadSpawned = true;
			}
	}
}
