using UnityEngine;
using System.Collections;

public class BoundsItem : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnCollisionEnter(Collision col) {
		if (col.gameObject.tag == "Bullet") {
			GameReference.soundManager.PlaySE (GameReference.soundManager.SEList [0]);
			GameReference.gameController.startScoreAnimation(false, gameObject.transform.position, 200);
			GameReference.ScoreManager.AddScore (200);
		}
	}
}
