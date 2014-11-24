using UnityEngine;
using System.Collections;

public class test_Fire : MonoBehaviour {

	public GameObject Bullet;
	public float bulletspeed;
	public float nextFire;
	public float fireRate;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetKey(KeyCode.Space) && Time.time > nextFire)
		{
			nextFire = Time.time + fireRate;
			
			{
				//GameObject bul = Instantiate (Bullet, new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation) as GameObject;
				
				/*bul.rigidbody.AddForce(Vector3.up * bulletspeed);*/
			}
		}

	}
}
