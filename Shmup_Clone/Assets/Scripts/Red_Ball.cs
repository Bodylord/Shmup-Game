using UnityEngine;
using System.Collections;

public class Red_Ball : MonoBehaviour {

	public static float Speed = 5;
	public static float bulletWidth;

	public int currentLevel;

	// Use this for initialization
	void Start () {
	
		 

	}
	
	// Update is called once per frame
	void Update () {
	

		transform.localScale = new Vector3(transform.localScale.x + bulletWidth, transform.localScale.y, transform.localScale.z);

		transform.Translate(Vector3.up * Speed * Time.deltaTime, Space.Self);

		if (transform.position.y >= 7)
		{
			Destroy(gameObject);
		}

	}
}
