using UnityEngine;
using System.Collections;

public class GunForBoss : MonoBehaviour {

	public GameObject bulletBoss;

	public float velocity = 20f;
	public float rateOfFire = 0.5f;
	public GameObject boss;

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
		Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
		Vector3 dir = Input.mousePosition - pos;
		float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;



		canShoot = false;
		if ( ((angle >= 120 && angle <= 180.0) || (angle <= -120.0 && angle >= -180.0))) {
			canShoot = true;
			StartCoroutine (Reload (rateOfFire));
		} else if (playerMovement.facingRight && ((angle >= 0 && angle <= 60.0) || (angle <= -0 && angle >= -60.0))) {
			canShoot = true;
			StartCoroutine (Reload (rateOfFire));
		}

		if (Input.GetMouseButtonDown(0)&& canShoot)
		{
			Vector2 target = Camera.main.ScreenToWorldPoint( new Vector2(Input.mousePosition.x,  Input.mousePosition.y) );
			Vector2 myPos = new Vector2(transform.position.x,transform.position.y + 1);
			Vector2 direction = target - myPos;
			direction.Normalize();
			Quaternion rotation = Quaternion.Euler( 0, 0, Mathf.Atan2 ( direction.y, direction.x ) * Mathf.Rad2Deg );
			GameObject projectile = (GameObject) Instantiate( bullet, myPos, rotation);
			projectile.GetComponent<Rigidbody2D>().velocity = direction * velocity;
			canShoot = false;
			StartCoroutine (Reload (rateOfFire));
		}




	}
}


