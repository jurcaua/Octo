using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float speed;
	public float jumpHeight;

	private Rigidbody2D r;
	private SpriteRenderer s;
	private Animator a;

	private float horizontal;
	private float vertical;

	private bool jumping = false;
	private float vel = 0f;

	// Use this for initialization
	void Start () {
		r = GetComponent<Rigidbody2D> ();
		s = GetComponent<SpriteRenderer> ();
		a = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		a.SetBool ("Jumping", jumping);
		a.SetFloat ("Velocity", vel);
	}

	void FixedUpdate(){
		horizontal = Input.GetAxisRaw ("Horizontal");
		vertical = Input.GetAxisRaw ("Vertical");

		vel = r.velocity.x;

		r.AddForce(transform.right * horizontal * speed);
		if(!jumping){
			r.AddForce(transform.up * vertical * jumpHeight);
		}
	}

	public void setJumping(bool toSet){
		jumping = toSet;
	}
}
