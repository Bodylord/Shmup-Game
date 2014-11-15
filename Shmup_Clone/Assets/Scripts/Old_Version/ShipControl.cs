using UnityEngine;
using System.Collections;

public class ShipControl : MonoBehaviour {

	//ship restrictions
	public float shipSpeed;
	public float maxXdist = 4.6f;
	public float maxYdist = 5f;
	public GameObject shipPos;

	//bullet properties
	public GameObject Bullet;
	public float bulletspeed;
	public float nextFire;
	public float fireRate;
	
	
	// Use this for initialization
	void Start () {

		transform.position = Vector3.zero;
	
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKey(KeyCode.W))
		{
			transform.Translate(Vector3.up * shipSpeed);
		}

		if(Input.GetKey(KeyCode.A))
		{
			transform.Translate(Vector3.left * shipSpeed);
		}

		if(Input.GetKey(KeyCode.S))
		{
			transform.Translate(Vector3.down * shipSpeed);
		}

		if(Input.GetKey(KeyCode.D))
		{
			transform.Translate(Vector3.right * shipSpeed);
		}

		/*if (Input.GetKey(KeyCode.Space) && Time.time > nextFire)
		{
			nextFire = Time.time + fireRate;
			
			{
				GameObject bul = Instantiate (Bullet, new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation) as GameObject;
				
				bul.rigidbody.AddForce(Vector3.up * bulletspeed);
			}
		} 


		if (shipPos.transform.position.x > maxXdist){
			shipPos.transform.position.x = maxXdist;
		}

		if (shipPos.transform.position.x < -maxXdist){
			shipPos.transform.position.x = -maxXdist;
		}
		*/

	}
}
