using UnityEngine;
using System.Collections;

public class Enemy_LookAt : MonoBehaviour {

	public Transform playerAsTarget;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		transform.LookAt(playerAsTarget);
	
	}
}
