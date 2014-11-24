using UnityEngine;
using System.Collections;

public class backgroundMovements : MonoBehaviour {

	public float Speed;
	public float maxStretch = 20f;
	public float stretchRate = 15f;
	public Vector3 initScale;

	public float maximumY = 1f;
	public Vector3 cullingSpot;
	public Vector3 respawnSpot;

	// Use this for initialization
	void Start () {

		initScale = transform.localScale;
	
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

			if (Input.GetKey (KeyCode.X))
			{
				//Speed += 30;

				if (gameObject.name.Contains("Stars"))
					{
						transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(transform.localScale.x, maxStretch, transform.localScale.z), stretchRate * Time.deltaTime);
					}
			}

			if (!Input.GetKey (KeyCode.X))
			{
				//Speed -= 30;
				
				if (gameObject.name.Contains("Stars"))
				{
				transform.localScale = Vector3.Lerp(transform.localScale, initScale, stretchRate * Time.deltaTime);
				}
			}
			
		}
	}