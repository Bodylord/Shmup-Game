using UnityEngine;
using System.Collections;

public class BossScript : MonoBehaviour {

	public float spawnTravelDist;
	public float MovementSpeed = 2f;

	public Vector3 spawnPosition;
	public Vector3 bossMoveToScene;

	public Quaternion stageTwoRotation;

	public GameObject[] WeakPoints1;
	public GameObject[] WeakPoints2;

	public bool areWeakPoints1Dead;
	public bool areWeakPoints2Dead;
	public bool isRotating;
	public bool isMoving;

	private bossWeakPoint weakPoints;



	// Use this for initialization
	void Start () {

		gameObject.name = ("Boss");

		areWeakPoints1Dead = false;
		areWeakPoints2Dead = false;
		isRotating = false;
		isMoving = true;


	}
	
	// Update is called once per frame
	void Update () {

		if (isMoving = true)
		{
			moveToGameArea();
		}

		if((WeakPoints1[0].gameObject.GetComponent<SpriteRenderer>().enabled == false) &&
		   (WeakPoints1[1].gameObject.GetComponent<SpriteRenderer>().enabled == false) &&
		   (WeakPoints1[2].gameObject.GetComponent<SpriteRenderer>().enabled == false))
			{
				laserRotateBoss();
			}

		if((WeakPoints2[0].gameObject.GetComponent<SpriteRenderer>().enabled == false) &&
		   (WeakPoints2[1].gameObject.GetComponent<SpriteRenderer>().enabled == false) &&
		   (WeakPoints2[2].gameObject.GetComponent<SpriteRenderer>().enabled == false))
		{
			Destroy(gameObject);
		}
	
	}

	void moveToGameArea()
	{
		transform.position = Vector3.Lerp(transform.position, bossMoveToScene, MovementSpeed * Time.deltaTime);

		if (transform.position.y <= bossMoveToScene.y - 0.05f)
		{
			isMoving = false;
		}
	}

	void laserRotateBoss()
	{
		isRotating = true;
		//rotation movement
		transform.localRotation = Quaternion.Lerp(transform.localRotation, stageTwoRotation, 0.001f * Time.deltaTime);


	}
	
}