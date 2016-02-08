using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour {

	public GameObject bullet;
	public float velocity = 20f;
	public float rateOfFire = 0.5f;

	bool canShoot;


	//
	IEnumerator Reload(float delay)
	{
		yield return new WaitForSeconds (delay);
		canShoot = true;
	}

	// Use this for initialization
	void Start () {
		StartCoroutine (Reload (rateOfFire));
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0)&& canShoot)
		{
			GameObject tempBullet = Instantiate (bullet, transform.position, transform.rotation) as GameObject;
			Vector3 sp = Camera.main.WorldToScreenPoint(transform.position);
			Vector3 dir = (Input.mousePosition + sp).normalized;
			tempBullet.GetComponent<Rigidbody2D>().velocity = (gameObject.transform.right * velocity);
			canShoot = false;
			StartCoroutine (Reload (rateOfFire));
		}
	}
}
