using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	public float Speed = 10f;
	public float Travelled = 0;
	public float LifeTime = 10f;
	public int playerDamage;

	public GameObject Bullethere;
	public GameObject targetpls;
	public Vector3 bulletPos;
	public Vector3 target;

	// Use this for initialization

	void Start () {

	
		target = GameObject.Find("Mouse_Slave").transform.position;

		playerDamage = 10;


	}
	
	// Update is called once per frame
	void Update () {
	

		/*	Vector3 translation = Vector3.Normalize(target - transform.position) * Speed * Time.deltaTime;
			
			transform.Translate(translation);
			Travelled += translation.magnitude;
		*/

		transform.Translate(Vector3.up * Speed * Time.deltaTime, Space.Self);

		/*if(moving){
			Vector3 translation = Vector3.Lerp(bulletPos, target, Time.deltaTime);

			transform.Translate(translation);
			Travelled += translation.magnitude;
		}*/



		if (Travelled >= LifeTime)
		{
			Destroy(gameObject);
		}

	}

	void OnCollisionEnter (Collision col){
		Destroy(gameObject);
	}
}
