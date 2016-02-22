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
			Vector2 target = Camera.main.ScreenToWorldPoint( new Vector2(Input.mousePosition.x,  Input.mousePosition.y) );
			Vector2 myPos = new Vector2(transform.position.x,transform.position.y + 1);
			Vector2 direction = target - myPos;
			direction.Normalize();
			Quaternion rotation = Quaternion.Euler( 0, 0, Mathf.Atan2 ( direction.y, direction.x ) * Mathf.Rad2Deg );
			GameObject projectile = (GameObject) Instantiate( bullet, myPos, rotation);
			projectile.GetComponent<Rigidbody>().velocity = direction * velocity;
			canShoot = false;
			StartCoroutine (Reload (rateOfFire));
		}
	}
}
