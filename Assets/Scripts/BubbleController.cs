using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BubbleController : MonoBehaviour {

	public GameObject bubbles;
	public GameObject rightBubbleSpawn;
	public GameObject leftBubbleSpawn;

	public float xDev = 0.5f;
	public float yDev = 0.5f;
	public float floatDownSpeed = 0.5f;

	private float randX;
	private float randY;
	private Vector2 tempPos;

	private SpriteRenderer s;
	private Animator a;

	[HideInInspector] public List<GameObject> activeBubbles;

	// Use this for initialization
	void Start () {
		s = bubbles.GetComponent<SpriteRenderer> ();
		a = bubbles.GetComponent<Animator> ();

		activeBubbles = new List<GameObject> ();
	}
	
	// Update is called once per frame
	void Update () {
		for (int i = 0; i < activeBubbles.Count; i++) {
			if (activeBubbles [i].activeInHierarchy) {
				activeBubbles [i].transform.position = new Vector2 (activeBubbles [i].transform.position.x, activeBubbles [i].transform.position.y - floatDownSpeed * Time.deltaTime);
			} else {
				activeBubbles.RemoveAt (i);
				i--;
			}
		}
	}

	public void Bubbles(){
		randX = Random.Range (-xDev, xDev);
		randY = Random.Range (-yDev, yDev);
		tempPos = new Vector2 (rightBubbleSpawn.transform.position.x + randX, rightBubbleSpawn.transform.position.y + randY);

		GameObject rightBubbles = Instantiate (bubbles, tempPos, rightBubbleSpawn.transform.rotation, rightBubbleSpawn.transform) as GameObject;
		s.flipX = true;

		randX = Random.Range (-xDev, xDev);
		randY = Random.Range (-yDev, yDev);
		tempPos = new Vector2 (leftBubbleSpawn.transform.position.x + randX, leftBubbleSpawn.transform.position.y + randY);

		GameObject leftBubbles = Instantiate (bubbles, tempPos, leftBubbleSpawn.transform.rotation, leftBubbleSpawn.transform) as GameObject;
		s.flipX = false;

		activeBubbles.Add (rightBubbles);
		activeBubbles.Add (leftBubbles);

		Destroy (rightBubbles, 1f);
		Destroy (leftBubbles, 1f);
	}
}
