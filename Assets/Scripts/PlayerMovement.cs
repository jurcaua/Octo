using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float speed;
	public float jumpHeight;
	public float clickForce; // how strong each click is
	public float clickRadius; // how far away you can click from octo

	private Rigidbody2D r; 
	private SpriteRenderer s;
	private Animator a;

	private float horizontal;
	private float vertical;

	private bool jumping = false; // used for telling animator when to play jumping animation
	private float vel = 0f; // used for telling animator when to play moving animations

	// Use this for initialization
	void Start () {
		// get all the needed components
		r = GetComponent<Rigidbody2D> ();
		s = GetComponent<SpriteRenderer> ();
		a = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		// update animator values
		a.SetBool ("Jumping", jumping); 
		a.SetFloat ("Velocity", vel);

		Jump (); // check for jumping (with W key) (going away soon)
		Move (); // check for moving (clicks/touches)
	}

	// currently just used for WASD movement but thats going away soon
	void FixedUpdate(){
		horizontal = Input.GetAxisRaw ("Horizontal");
		//vertical = Input.GetAxisRaw ("Vertical");

		vel = r.velocity.x;
		r.AddForce(transform.right * horizontal * speed);

		if(jumping){
			r.AddForce(transform.up * vertical * jumpHeight);
		}

		// keeping this, rotation according to direction of velocity
		transform.rotation = Quaternion.Euler (0f, 0f, -r.velocity.x);
	}

	void Jump(){
		if (Input.GetKeyDown (KeyCode.W)) { // jump key is pressed?
			jumping = true; // tell animator

			vertical = 1; // going up
			r.velocity = new Vector2(r.velocity.x, 0f); // set velocity
			r.angularVelocity = 0f; // no spin
		} else {	
			jumping = false; // no longer jumping

			vertical = 0; // no up/down
		}
	}

	public void setJumping(bool toSet){
		jumping = toSet; // so we can set jumping outside of this script
	}

	void Move(){
		if (Input.GetMouseButtonDown(0)) {
			Vector3 clickPointTemp = Camera.main.ScreenToWorldPoint (Input.mousePosition); // get that position in the world
			Vector2 clickPoint = new Vector2 (clickPointTemp.x, clickPointTemp.y); // make it a vector2 cause everything else is a vector2

			Vector2 moveDirection = (r.position - clickPoint).normalized; // get the direction we need to move octo and normalize that vector
			float clickDistance = Vector2.Distance (r.position, clickPoint); // see how far away the user clicked from octo (to scale later)

			if (moveDirection.y >= 0) { // we cant accelerate octo back down
				jumping = true; // play the jumping animation
				r.AddForce (
					Mathf.Lerp
					(
						0, clickForce, (clickRadius - clickDistance) // between 0 and max clickforce, scaled by radius and distance
					)
					* moveDirection, ForceMode2D.Impulse); // the lerped power, in the right direction, and impluse forcemode
			}
		}
	}
}
