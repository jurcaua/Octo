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

		if (Input.GetKeyDown (KeyCode.W)) {
			jumping = true;

			vertical = 1;
			r.velocity = new Vector2(r.velocity.x, 0f);
			r.angularVelocity = 0f;
		} else {	
			jumping = false;

			vertical = 0;
		}
	}

	void FixedUpdate(){
		horizontal = Input.GetAxisRaw ("Horizontal");
		//vertical = Input.GetAxisRaw ("Vertical");

		vel = r.velocity.x;
		r.AddForce(transform.right * horizontal * speed);

		if(jumping){
			r.AddForce(transform.up * vertical * jumpHeight);
		}

		transform.rotation = Quaternion.Euler (0f, 0f, -r.velocity.x);
	}

	public void setJumping(bool toSet){
		jumping = toSet;
	}
}
