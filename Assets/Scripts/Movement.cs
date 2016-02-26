using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour 
{
	Animator anim;
	public float moveSpeed;
	public float jumpPower;
	public bool isJumping = false;
	private bool isGrounded;


	public Transform target;
	public bool facingRight = true;
	void Start ()
	{
		anim = GetComponent<Animator>();

	}

	void Update ()
	{
		
		//anim.SetFloat("Speed", Mathf.Abs(0));
		//Settings for the parameters in the Animator Controller

		float h = Input.GetAxisRaw ("Horizontal");
		anim.SetFloat("Speed", Mathf.Abs(h)); 
		transform.Translate (new Vector3 (h* moveSpeed, 0, 0) * Time.deltaTime);

		if(h>0 && !facingRight)
		{
			Flip ();
			facingRight = true;

		}
		if(h<0 && facingRight)
		{
			Flip ();
			facingRight = false;

		}			

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

	void Flip()
	{
		Vector3 fscale = transform.localScale;
		fscale.x *= -1;
		transform.localScale = fscale;
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