using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour 
{
	Animator anim;
	public float moveSpeed;
	public float jumpPower;
	public bool isJumping = false;
	private bool isGrounded;

	public bool rightWalk = false;
	public Transform target;

	void Start ()
	{
		anim = GetComponent<Animator>();

	}

	void Update ()
	{
		

		//Settings for the parameters in the Animator Controller
		if(Input.GetKey(KeyCode.A))
		{
			anim.SetFloat("SpeedLeft", Mathf.Abs(3F)); 
			anim.SetBool ("Left", true);
			transform.Translate (new Vector3 (moveSpeed, 0, 0) * Time.deltaTime);
			transform.rotation = Quaternion.Euler (0, -180, 0);
			rightWalk = true;

		}
		else
			anim.SetFloat ("SpeedLeft", Mathf.Abs (0F));
		
		if(Input.GetKey(KeyCode.D))
		{	
			anim.SetFloat("Speed", Mathf.Abs(3F));
			anim.SetBool ("Left", false);
			transform.Translate (new Vector3 (moveSpeed, 0, 0) * Time.deltaTime);
			transform.rotation = Quaternion.Euler (0, 0, 0);
			rightWalk = false;
		
		}
		else
			anim.SetFloat ("Speed", Mathf.Abs (0F));

		if(Input.GetKeyDown(KeyCode.Space))
		{
			if (isJumping == true)

			{
				anim.SetBool ("Jumping", true);
				GetComponent<Rigidbody>().AddForce (Vector2.up * jumpPower);

				isJumping = false; //Avoids Multible Jumps
			}
		}

	}




	void OnCollisionEnter (Collision col)
	{
		if (col.gameObject.tag == "Ground")
		{
			isJumping = true;
			anim.SetBool ("Jumping", false);
		}
	

	}
}