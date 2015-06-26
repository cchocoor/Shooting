using UnityEngine;
using System.Collections;

public class ScoreUpItem : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision col) {
		if (col.gameObject.tag == "Bullet") {
			GameReference.soundManager.PlaySE (GameReference.soundManager.SEList[1]);
			GameReference.gameController.startScoreAnimation(true, gameObject.transform.position, 200);
			GameReference.ScoreManager.AddScore (200);
		}
	}
}
