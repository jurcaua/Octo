using UnityEngine;
using System.Collections;

public class BubbleDestruction : MonoBehaviour {

	private BubbleController b;

	void Start(){
		b = GameObject.FindGameObjectWithTag ("Player").GetComponent<BubbleController> ();
	}

	void OnDestroy(){
		b.activeBubbles.Remove (gameObject);
	}
}
