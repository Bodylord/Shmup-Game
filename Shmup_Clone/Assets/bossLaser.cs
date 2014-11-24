using UnityEngine;
using System.Collections;

public class bossLaser : MonoBehaviour {

	//Laser Properties

	public static float maxLaserScale = 100f;
	public static float laserSpeed = 0.5f; 
	public float destroydelay = 1000f;
	public static float laserWidth = 0;
	
	public bool isLerping;
	public bool isWider;

	private BossScript bossScript;

	// Use this for initialization
	void Start () {

		gameObject.name = "Boss Laser";

		isLerping = true;
	
	}
	
	// Update is called once per frame
	void Update () {
	
		transform.localScale = new Vector3(transform.localScale.x + laserWidth, transform.localScale.y, transform.localScale.z);

	}

	void FixedUpdate()
	{
		bossScript = GameObject.Find ("Boss").GetComponent<BossScript>();

		if (isLerping)
		{
			transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(transform.localScale.x, maxLaserScale, transform.localScale.z), laserSpeed * Time.deltaTime);

			isLerping = false;

			if (bossScript.gameObject.transform.localScale.z >= bossScript.stageTwoRotation.z - 60)
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
