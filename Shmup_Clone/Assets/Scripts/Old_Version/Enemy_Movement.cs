using UnityEngine;
using System.Collections;

public class Enemy_Movement : MonoBehaviour {

	public float Speed;

	//Enemy Lifetime
	public float Travelled = 0;
	public float LifeTime = 10f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
			
		transform.Translate(0f, -Speed * Time.deltaTime, 0f);

		if (Travelled >= LifeTime)
		{
			Destroy(gameObject);
		}
	}
}
