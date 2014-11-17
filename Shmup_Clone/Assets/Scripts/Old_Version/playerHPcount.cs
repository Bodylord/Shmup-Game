using UnityEngine;
using System.Collections;

public class playerHPcount : MonoBehaviour {

	public PlayerScript shipHealth;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		shipHealth = GameObject.Find ("playership").GetComponent<PlayerScript>();

		guiText.text = "HP " + shipHealth.HP;
	
	}
}
