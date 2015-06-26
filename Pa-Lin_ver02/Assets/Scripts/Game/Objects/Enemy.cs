using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnCollisionEnter(Collision col) {
		if (col.gameObject.tag == "Bullet") {
			GameReference.soundManager.PlaySE (GameReference.soundManager.SEList [0]);
			GameReference.ScoreManager.AddScore(100);
			// スコアが3D空間上にスコアのUITextが表示される(敵にあったった時のスコアアニメーションを再生)
			GameReference.gameController.startScoreAnimation(false, gameObject.transform.position, 100);
		}
	}
}
