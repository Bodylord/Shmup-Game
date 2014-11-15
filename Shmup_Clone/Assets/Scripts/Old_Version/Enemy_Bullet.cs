using UnityEngine;
using System.Collections;

public class Enemy_Bullet : MonoBehaviour {
	
	public float Speed = 10f;
	public float Travelled = 0;
	public float LifeTime = 20f;
	public int enemyDamage;
	
	public Vector3 bulletPos;
	public Vector3 target;
	public GameObject Bullethere;
	public Player_HealthScript damage;

	
	private bool moving;
	
	// Use this for initialization
	
	void Start () {

		damage = GameObject.Find ("playerShip").GetComponent<Player_HealthScript>();
		target = GameObject.Find("playerShip").transform.position;
		
	}
	
	// Update is called once per frame
	void Update () {

			//Vector3 translation =  * Speed * Time.deltaTime;
			
			//transform.Translate(translation, Space.Self);
			//Travelled += translation.magnitude;		

		transform.Translate(Vector3.down * Speed * Time.deltaTime, Space.Self);
		
		if (Travelled >= LifeTime)
		{
			Destroy(gameObject);
		}
		
	}
	
	void OnCollisionEnter (Collision col){

		//Destroy(gameObject);
	}
}
