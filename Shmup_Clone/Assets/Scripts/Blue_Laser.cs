﻿using UnityEngine;
using System.Collections;

public class Blue_Laser : MonoBehaviour {


	public float maxLaserScale;
	public float laserSpeed; 
	public float destroydelay;

	public bool isLerping;

	// Use this for initialization
	void Start () {

		gameObject.name = "BlueLaser";

		isLerping = true;
	}
	
	// Update is called once per frame
	void Update () {
	}

	void FixedUpdate()
	{
		if (isLerping)
		{
			transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(transform.localScale.x, maxLaserScale, transform.localScale.z), laserSpeed * Time.deltaTime);
			if (transform.localScale.y >= maxLaserScale - 0.05f)
			{
				StartCoroutine(delaydestroy());
			}
		}
	}

	IEnumerator delaydestroy()
	{
		yield return new WaitForSeconds(destroydelay);
		Destroy(this.gameObject);
	}
}
