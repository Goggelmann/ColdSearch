using UnityEngine;
using System.Collections;



public class ShootStart : MonoBehaviour {

	public float velocity = 20f;
	// Use this for initialization
	void Start () 
	{
		Vector3 sp = Camera.main.WorldToScreenPoint(transform.position);
		Vector3 dir = (Input.mousePosition - sp).normalized;
		GetComponent<Rigidbody>().AddForce (gameObject.transform.forward * velocity);

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
