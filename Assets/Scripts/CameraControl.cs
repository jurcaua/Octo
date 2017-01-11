using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {

	public GameObject player;
	public float centerDeviation = 5f;

	private Camera camera;

	// Use this for initialization
	void Start () {
		camera = GetComponent<Camera> ();
	}
	
	// Update is called once per frame
	void Update () {
		camera.transform.position = new Vector3 
			(
				player.transform.position.x, 
				player.transform.position.y + centerDeviation, 
				camera.transform.position.z
			);
	}
}
