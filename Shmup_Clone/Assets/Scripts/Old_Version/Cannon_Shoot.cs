using UnityEngine;
using System.Collections;

public class Cannon_Shoot : MonoBehaviour {

	public GameObject Bullet;
	
	public float bulletspeed;
	
	public float nextFire;
	public float fireRate;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
			
	//Input for shooting a bullet
		if (Input.GetMouseButton(1) && Time.time > nextFire)
		{
			nextFire = Time.time + fireRate;

			{
				Instantiate (Bullet, new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation);
					
				/*bul.rigidbody.AddForce(Vector3.up * bulletspeed);*/
			}
		}
	}


}
