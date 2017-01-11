using UnityEngine;
using System.Collections;

public class GroundCheck : MonoBehaviour {

	private PlayerMovement p;

	// Use this for initialization
	void Start () {
		p = GetComponentInParent<PlayerMovement> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other){
		p.setJumping (false);
	}

	void OnTriggerExit2D(Collider2D other){
		p.setJumping (true);
	}
}
