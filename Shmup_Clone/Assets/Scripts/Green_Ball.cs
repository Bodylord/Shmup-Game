using UnityEngine;
using System.Collections;

public class Green_Ball : MonoBehaviour {

	public float Speed;
	public float explosionSize;
	public float explosionSpeed;
	public float destroydelay;

	public bool isLerping;

	// Use this for initialization
	void Start () {

		gameObject.name = "GreenBall";

		isLerping = false;
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKey(KeyCode.UpArrow) && !isLerping)
		{
		transform.Translate(Vector3.up * Speed * Time.deltaTime, Space.Self);
		}

		if (Input.GetKeyUp(KeyCode.UpArrow))
		{
			isLerping = true;
		}
	
	}

	void FixedUpdate()
	{
		if (isLerping)
		{
			transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(explosionSize, explosionSize, transform.localScale.z), explosionSpeed * Time.deltaTime);
			if (transform.localScale.x >= explosionSize - 0.05f)
			{
				StartCoroutine(delaydestroy());
			}
		}
	}

	IEnumerator delaydestroy()
	{
		yield return new WaitForSeconds(destroydelay);
		Destroy(this.gameObject);
	}	
}
