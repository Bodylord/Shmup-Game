using UnityEngine;
using System.Collections;

public class playerHPcount : MonoBehaviour {

	public Player_HealthScript shipHealth;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		shipHealth = GameObject.Find ("playerShip").GetComponent<Player_HealthScript>();

		guiText.text = "HP " + shipHealth.HP;
	
	}
}
