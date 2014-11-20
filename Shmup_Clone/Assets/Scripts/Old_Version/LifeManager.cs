using UnityEngine;
using System.Collections;

public class LifeManager : MonoBehaviour {
	
	public int Lives;
	public GameObject[] playerLife;
	public Player_HealthScript shipHP;

	public float timerLength;
	public float timer;
	public Vector3[] spawnLocations;
	public GameObject playerShip;
	public GameObject enemyWeak;
	public GameObject enemyStrong;

	public int EnemyCount;
	public int EnemyDeaths;

	// Use this for initialization
	void Start () {

		Lives = 3;

		//enemy respawn timer length
		timerLength = 10f;


	}
	
	// Update is called once per frame
	void Update () 
	{

		checkLives();

		if (timer < 0.0f)
		{
		}
		timer -= Time.deltaTime;



		if (EnemyDeaths == 500)
		{

		}
		
				
		
	}
	
	/*bool IsAlive(){
		if (Lives == 0) {

			print("u lose");
			//Resources.Load ("game_over screen");
		}
		else 
		{ 
			return true;
		}
		return false; 
		}
		*/

	public void checkLives()
	{
		switch (Lives) 
		{
		case 0:
			playerLife[0].SetActive(false);
			Application.LoadLevel("game_over screen");
			break;
			
		case 1:
			playerLife[1].SetActive(false);
			print ("1 life left");
			break;
			
		case 2:
			playerLife[2].SetActive(false);
			print ("2 life left");
			break;
			
		default:
			break;
			
		}
	}
}
