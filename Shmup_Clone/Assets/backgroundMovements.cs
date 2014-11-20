using UnityEngine;
using System.Collections;

public class backgroundMovements : MonoBehaviour {

	public float Speed;

	public float maximumY;
	public Vector3 cullingSpot;
	public Vector3 respawnSpot;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
			if (gameObject.tag.Contains("Background"))
			{
				transform.Translate (Vector3.down *Speed * Time.deltaTime, Space.World);
			}

			if (gameObject.tag.Contains("Midground"))
			{
				transform.Translate (Vector3.down *Speed * Time.deltaTime, Space.World);
			}

			if (gameObject.tag.Contains("Foreground"))
			{
				transform.Translate (Vector3.down *Speed * Time.deltaTime, Space.World);
			}

			if (Input.GetKeyDown (KeyCode.X))
			{
				Speed += 30;

				if (gameObject.name.Contains("Stars"))
					{
						transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y * 10, transform.localScale.z);
					}
			}

			if (Input.GetKeyUp (KeyCode.X))
			{
				Speed -= 30;
				
				if (gameObject.name.Contains("Stars"))
				{
					transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y / 10, transform.localScale.z);
				}
			}
			
		}
	}