using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class clearedCondidtionObjectPrefab : MonoBehaviour {

	SpriteRenderer sprite;
	string name;
	// Use this for initialization
	void Start () {
		sprite = gameObject.GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision col) {
		if (col.gameObject.tag == "Bullet") {
			name = sprite.sprite.name;
			GameReference.gameController._clearedObjectList.CheckSpriteName(name);
			GameReference.ScoreManager.AddScore(100);
			// スコアが3D空間上にスコアのUITextが表示される(敵にあったった時のスコアアニメーションを再生)
			GameReference.gameController.startScoreAnimation(false, gameObject.transform.position, 300);
		}
	}
}
