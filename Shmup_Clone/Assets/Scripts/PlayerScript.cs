using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {


	public float Speed;


		// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetKey(KeyCode.W))
		{
			transform.Translate(Vector3.up * Speed);
		}

		if(Input.GetKey(KeyCode.A))
		{
			transform.Translate(Vector3.left * Speed);
		}

		if (Input.GetKey(KeyCode.S))
		{
			transform.Translate(Vector3.down * Speed);
		}

		if (Input.GetKey(KeyCode.D))
		{
			transform.Translate(Vector3.right * Speed);
		}
	}

}