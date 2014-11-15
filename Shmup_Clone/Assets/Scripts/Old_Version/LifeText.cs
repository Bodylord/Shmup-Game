using UnityEngine;
using System.Collections;

public class LifeText : MonoBehaviour {

	public LifeManager dead;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		dead = GameObject.Find ("Game Manager").GetComponent<LifeManager>();
	
		guiText.text = "Lives " + dead.Lives;

	}
}
