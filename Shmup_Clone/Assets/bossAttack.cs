using UnityEngine;
using System.Collections;

public class bossAttack : MonoBehaviour {


	public GameObject lazer;
	private BossScript bossScript;

	public bool isLaserSpawned;

	// Use this for initialization
	void Start () {
	
		isLaserSpawned = false;

	}
	
	// Update is called once per frame
	void Update () {
	
		bossScript = GameObject.Find ("Boss").GetComponent<BossScript>();
	
		if(bossScript.isRotating == true && isLaserSpawned == false)
		{
			fireLazor();

			isLaserSpawned = true;
		}

	}

	void fireLazor()
	{
		GameObject blulaser = Instantiate(lazer, new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation) as GameObject;
		
		blulaser.transform.parent = this.transform;
	}
}
