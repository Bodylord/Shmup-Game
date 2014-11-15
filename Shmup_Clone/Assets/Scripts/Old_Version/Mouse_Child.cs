using UnityEngine;
using System.Collections;

public class Mouse_Child : MonoBehaviour {

	

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		Ray ray = Camera.main.ScreenPointToRay ( Input.mousePosition );

		transform.position = new Vector2(ray.GetPoint(5f).x, ray.GetPoint(5f).y);
	
	}
}
