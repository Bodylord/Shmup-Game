using UnityEngine;
using System.Collections;

public class Cannon_LookAt : MonoBehaviour {

	public Transform mouseherepls;


	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	

		transform.LookAt(mouseherepls.position);


	}
}